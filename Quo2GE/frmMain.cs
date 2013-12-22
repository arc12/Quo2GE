using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
namespace Quo2GE
{
    public partial class frmMain : Form
    {
        frmAbout fAbout;
        XmlDocument poiKml;
        XmlDocument routeKml;
        XmlDocument geoKml;
        String[] poiTypes = { "Site", "Landmark", "Viewpoint" };

        public frmMain()
        {
            InitializeComponent();
        }
        #region Top-level form event handlers
        private void frmMain_Load(object sender, EventArgs e)
        {
            fAbout = new frmAbout();
            //tabs.Enabled = false;//tabs will be disabled until an output folder is selected
            openFileDialog.InitialDirectory = @"C:\Users\Adam\Desktop";//temp for testing. delete this line and uncomment previous when finished

            contentType.Items.AddRange(poiTypes);
        }
        private void btnAbout_Click(object sender, EventArgs e)
        {
            fAbout.ShowDialog();
        }
        private void btnOutput_Click(object sender, EventArgs e)
        {
            DialogResult folderResult = folderDialog.ShowDialog();
            if (folderResult == DialogResult.OK)
            {
                //default the file open folder to be the output folder
                openFileDialog.InitialDirectory = folderDialog.SelectedPath;
                //enable the tabs for inputting.
                tabs.Enabled = true;
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            exportCleanKml();
            exportAllProcessed();
            File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"gm.html"), 
                        Path.Combine(folderDialog.SelectedPath,"gm.html"));

        }

        #endregion

        #region Methods to do stuff

        /// <summary>
        /// loads a KML file and strips stuff we don't want.
        /// This means that waypoints, routes and style elements may be deleted, as per the arguments.
        /// And that (always):
        /// a) TimeStamp and TimeSpan data is removed
        /// b) Waypoints associated with tracks(routes) are removed, i.e. kml folder with name=Points
        /// c) remove are comments, and folder-level description elements
        /// </summary>
        /// <param name="fileName">kml file to load</param>
        /// <param name="extract">keep the waypoints, routes or all</param>
        /// <returns>a cleaned KML file</returns>
        private XmlDocument loadAndCleanKML(string fileName, kmlType extract, bool keepStyle)
        {

            XmlDocument kml = new XmlDocument();
            kml.Load(fileName);

            //Instantiate an XmlNamespaceManager object to allow us to use namespaced XPath 
            XmlNamespaceManager xmlnsManager = new XmlNamespaceManager(kml.NameTable);
            xmlnsManager.AddNamespace("kml", "http://www.opengis.net/kml/2.2");
            xmlnsManager.AddNamespace("gx", "http://www.google.com/kml/ext/2.2");


            if (extract != kmlType.WAYPOINT && extract != kmlType.ANY)
            {
                //remove waypoints. Quo puts these in a folder named Waypoints.
                XmlNode node = kml.SelectSingleNode("//kml:Folder[kml:name='Waypoints']", xmlnsManager);
                if (node != null)
                {
                    node.ParentNode.RemoveChild(node);
                }
            }

            if (extract != kmlType.ROUTE && extract != kmlType.ANY)
            {
                //remove routes. Quo puts these in a folder named Tracks.
                XmlNode node = kml.SelectSingleNode("//kml:Folder[kml:name='Tracks']", xmlnsManager);
                if(node != null){   
                    node.ParentNode.RemoveChild(node);
                }
            }

            if (!keepStyle)
            {
                //style info lives in Style or StyleMap elements
                XmlNodeList styleNodes = kml.SelectNodes("//kml:Style | //kml:StyleMap", xmlnsManager);
                foreach (XmlNode node in styleNodes)
                {
                    node.ParentNode.RemoveChild(node);
                }
            }

            //remove waypoints from tracks
            XmlNodeList trackPointNodes = kml.SelectNodes("//kml:Folder[kml:name='Tracks']/kml:Folder/kml:Folder[kml:name='Points']", xmlnsManager);
            foreach (XmlNode node in trackPointNodes)
            {
                node.ParentNode.RemoveChild(node);
            }

            //remove comments
            XmlNodeList commentNodes = kml.SelectNodes("//comment()");
            foreach (XmlNode node in commentNodes)
            {
                node.ParentNode.RemoveChild(node);
            }

            //remove TimeSpan (occurs in both namespaces) and TimeStamp (only expected on waypoints)
            XmlNodeList timeNodes = kml.SelectNodes("//kml:TimeSpan | //gx:TimeSpan | //kml:TimeStamp", xmlnsManager);
            foreach (XmlNode node in timeNodes)
            {
                node.ParentNode.RemoveChild(node);
            }

            //remove Folder/descriptions, since these are not useful
            XmlNodeList foldescNodes = kml.SelectNodes("//kml:Folder/kml:description", xmlnsManager);
            foreach (XmlNode node in foldescNodes)
            {
                node.ParentNode.RemoveChild(node);
            }
            return kml;      
            
        }

        /// <summary>
        /// Extract the prefixes used in track or waypoint names
        /// </summary>
        /// <param name="kml">the KML</param>
        /// <param name="prefixOf">what kind of entity to get the prefixes for</param>
        /// <param name="separator">the character that separates a prefix from the index</param>
        /// <returns>CSV of prefixes</returns>
        private String findPrefixes(XmlDocument kml, kmlType prefixOf, char separator)
        {
            StringBuilder prefixes = new StringBuilder();
            String lastPrefix = "";
            //Instantiate an XmlNamespaceManager object to allow us to use namespaced XPath 
            XmlNamespaceManager xmlnsManager = new XmlNamespaceManager(kml.NameTable);
            xmlnsManager.AddNamespace("kml", "http://www.opengis.net/kml/2.2");
            //all waypoint or track names
            String xPath="";
            switch (prefixOf)
            {
                case kmlType.WAYPOINT:
                    xPath = "//kml:Folder[kml:name='Waypoints']/kml:Placemark/kml:name";
                    break;
                case kmlType.ROUTE:
                    xPath = "//kml:Folder[kml:name='Tracks']/kml:Folder/kml:name";
                    break;
            }
            XmlNodeList names = kml.SelectNodes(xPath, xmlnsManager);
            foreach(XmlNode name in names){
                String thisPrefix = name.InnerText.Split(separator)[0];
                if (thisPrefix != lastPrefix)
                {
                    if (lastPrefix != "")
                    {
                        prefixes.Append("," + thisPrefix);
                    }
                    else
                    {
                        prefixes = new StringBuilder(thisPrefix);
                    }
                    lastPrefix = thisPrefix;
                }
            }
            return prefixes.ToString();
        }

        /// <summary>
        /// Save cleaned KML. This has no grouping, styling or aggregation,
        /// it is just the cleaned versions of the input files
        /// </summary>
        private void exportCleanKml()
        {
            //this is for testing - simply export the cleaned kml
            if (poiKml != null)
            {
                poiKml.Save(Path.Combine(folderDialog.SelectedPath, "cleanPOI.kml"));
            }
            if (routeKml != null)
            {
                routeKml.Save(Path.Combine(folderDialog.SelectedPath, "cleanRoutes.kml"));
            }
            if (geoKml != null)
            {
                geoKml.Save(Path.Combine(folderDialog.SelectedPath, "cleanGeo.kml"));
            }
        }

        /// <summary>
        /// This does aggregation, grouping and styling according to user-specified settings
        /// before saving the single KML file intended for GE plugin
        /// </summary>
        private void exportAllProcessed(){

            //create an empty enclosing KML file before processing each of the three cleaned
            //input types according to whatever checkbox and folder property settings have been
            // made by the user
            XmlDocument allKml = new XmlDocument();
            StringBuilder kmlShell = new StringBuilder();
            kmlShell.AppendLine("<kml xmlns=\"http://www.opengis.net/kml/2.2\" xmlns:gx=\"http://www.google.com/kml/ext/2.2\">");
            kmlShell.AppendLine("<Document>");
            kmlShell.AppendLine("<name>"+txtMainTitle.Text+"</name>");
            kmlShell.AppendLine("</Document>");
            kmlShell.AppendLine("</kml>");
            allKml.LoadXml(kmlShell.ToString());
            //Instantiate an XmlNamespaceManager object to allow us to use namespaced XPath 
            XmlNamespaceManager xmlnsManager = new XmlNamespaceManager(allKml.NameTable);
            xmlnsManager.AddNamespace("kml", "http://www.opengis.net/kml/2.2");
            //adding nodes starts here:
            XmlNode Document = allKml.SelectSingleNode("//kml:Document", xmlnsManager);

            // ADD STYLES
            // - for points of interest
            foreach(object o in poiListBox.CheckedItems){
                FolderInfo fi = (FolderInfo)o;
                XmlNode cursor = Document.AppendChild(allKml.CreateElement("Style", "http://www.opengis.net/kml/2.2"));
                XmlAttribute id = allKml.CreateAttribute("id");
                id.Value = "wptStyle_"+fi.Prefix;
                cursor.Attributes.Append(id);
                cursor = cursor.AppendChild(allKml.CreateElement("IconStyle", "http://www.opengis.net/kml/2.2"));
                XmlNode colour = allKml.CreateElement("color", "http://www.opengis.net/kml/2.2");
                colour.InnerText=fi.argbColour;
                cursor.AppendChild(colour);
                XmlNode icon = allKml.CreateElement("Icon", "http://www.opengis.net/kml/2.2");
                XmlNode href = allKml.CreateElement("href", "http://www.opengis.net/kml/2.2");
                href.InnerText = "http://maps.google.com/mapfiles/kml/pal4/icon61.png";
                icon.AppendChild(href);
                cursor = cursor.AppendChild(icon);
            }
            // - for routes
            foreach (object o in routeListBox.CheckedItems)
            {
                FolderInfo fi = (FolderInfo)o;
                XmlNode cursor = Document.AppendChild(allKml.CreateElement("Style", "http://www.opengis.net/kml/2.2"));
                XmlAttribute id = allKml.CreateAttribute("id");
                id.Value = "lineStyle_" + fi.Prefix;
                cursor.Attributes.Append(id);
                cursor = cursor.AppendChild(allKml.CreateElement("LineStyle", "http://www.opengis.net/kml/2.2"));
                XmlNode colour = allKml.CreateElement("color", "http://www.opengis.net/kml/2.2");
                colour.InnerText = fi.argbColour;
                cursor.AppendChild(colour);
                XmlNode width = allKml.CreateElement("width", "http://www.opengis.net/kml/2.2");
                width.InnerText = "3";
                cursor.AppendChild(width);
            }
            // - for geo features
            foreach (object o in geoListBox.CheckedItems)
            {
                FolderInfo fi = (FolderInfo)o;
                XmlNode cursor = Document.AppendChild(allKml.CreateElement("Style", "http://www.opengis.net/kml/2.2"));
                XmlAttribute id = allKml.CreateAttribute("id");
                id.Value = "lineStyle_" + fi.Prefix;
                cursor.Attributes.Append(id);
                cursor = cursor.AppendChild(allKml.CreateElement("LineStyle", "http://www.opengis.net/kml/2.2"));
                XmlNode colour = allKml.CreateElement("color", "http://www.opengis.net/kml/2.2");
                colour.InnerText = fi.argbColour;
                cursor.AppendChild(colour);
                XmlNode width = allKml.CreateElement("width", "http://www.opengis.net/kml/2.2");
                width.InnerText = "6";
                cursor.AppendChild(width);
            }
            //
            // ADD FOLDERS
            // - for POIs, there are 2 levels: POI type then prefix sets within that type.
            // ... parent folders for the POI Types
            foreach(String poiType in poiTypes){
                Document.AppendChild(CreateNamedFolder(allKml,poiType));
            }
            // ... loop over checked prefix list, adding to the correct parent folder
            foreach (object o in poiListBox.CheckedItems)
            {
                FolderInfo fi = (FolderInfo)o;
                XmlNode cursor = allKml.SelectSingleNode("//kml:Folder[kml:name='"+ fi.POItype +"']", xmlnsManager);
                cursor = cursor.AppendChild(CreateNamedFolder(allKml, fi.Title));
                //loop over all of the POIs checking for matches with the current prefix
                // and adjusting the style to match the previous ids for this prefix before inserting
                foreach (XmlNode poi in poiKml.SelectNodes("//kml:Folder[kml:name='Waypoints']//kml:Placemark", xmlnsManager))
                {
                    String poiName = poi.SelectSingleNode("kml:name", xmlnsManager).InnerText;
                    if (poiName.IndexOf(fi.Prefix) == 0)
                    {
                        XmlNode poiImported = allKml.ImportNode(poi, true);
                        poiImported.SelectSingleNode("//kml:styleUrl", xmlnsManager).InnerText = "#wptStyle_" + fi.Prefix;
                        cursor.AppendChild(poiImported);
                    }
                }
            }
            // - for Routes, there is one folder for each prefix within a "Routes" folder
            XmlNode routeFolder = Document.AppendChild(CreateNamedFolder(allKml, "Routes"));
            foreach (object o in routeListBox.CheckedItems)
            {
                FolderInfo fi = (FolderInfo)o;
                XmlNode cursor2 = routeFolder.AppendChild(CreateNamedFolder(allKml, fi.Title));
                //loop over all of the Routes checking for matches with the current prefix
                // and adjusting the style to match the previous ids for this prefix before inserting
                foreach (XmlNode route in routeKml.SelectNodes("//kml:Folder[kml:name='Tracks']//kml:Folder//kml:Placemark", xmlnsManager))
                {
                    String routeName = route.ParentNode.SelectSingleNode("kml:name", xmlnsManager).InnerText;//! the name is in the parent folder
                    if (routeName.IndexOf(fi.Prefix) == 0)
                    {
                        XmlNode routeImported = allKml.ImportNode(route, true);
                        routeImported.SelectSingleNode("//kml:styleUrl", xmlnsManager).InnerText = "#lineStyle_" + fi.Prefix;
                        cursor2.AppendChild(routeImported);
                    }
                }
            }
            // - for Geo Features, same as for Routes
            XmlNode geoFolder = Document.AppendChild(CreateNamedFolder(allKml, "Geo Features"));
            foreach (object o in geoListBox.CheckedItems)
            {
                FolderInfo fi = (FolderInfo)o;
                XmlNode cursor2 = geoFolder.AppendChild(CreateNamedFolder(allKml, fi.Title));
                //loop over all of the Routes checking for matches with the current prefix
                // and adjusting the style to match the previous ids for this prefix before inserting
                foreach (XmlNode geo in geoKml.SelectNodes("//kml:Folder[kml:name='Tracks']//kml:Folder//kml:Placemark", xmlnsManager))
                {
                    String geoName = geo.ParentNode.SelectSingleNode("kml:name", xmlnsManager).InnerText;
                    if (geoName.IndexOf(fi.Prefix) == 0)
                    {
                        XmlNode geoImported = allKml.ImportNode(geo, true);
                        geoImported.SelectSingleNode("//kml:styleUrl", xmlnsManager).InnerText = "#lineStyle_" + fi.Prefix;
                        cursor2.AppendChild(geoImported);
                    }
                }
            }

            allKml.Save(Path.Combine(folderDialog.SelectedPath, "allSets.kml"));

            //
            // - now write out the config.js file that is used for dynamic controls creation.
            //
            System.IO.StreamWriter file = new System.IO.StreamWriter(Path.Combine(folderDialog.SelectedPath, "config.js"));
            file.WriteLine("var title='"+txtMainTitle.Text+"';");
            file.WriteLine("var kmlHref='allSets.kml';");
            //viewpoints
            file.WriteLine("// locations of viewpoints. data is lat, lon, bearing (from vp)");
            XmlNode F = allKml.SelectSingleNode("//kml:Folder[kml:name='Viewpoint']", xmlnsManager);
            if (F.ChildNodes.Count<=1)//there is always a <name> child
            {
                file.WriteLine("var viewpoints = null;");
            }
            else
            {
                file.Write("var viewpoints = {");
                XmlNodeList placemarks = F.SelectNodes("./kml:Folder/kml:Placemark",xmlnsManager);
                bool comma=false;
                foreach (XmlNode p in placemarks)
                {
                    String name = p.SelectSingleNode("kml:name",xmlnsManager).InnerText;
                    String[] coords = p.SelectSingleNode("./kml:Point/kml:coordinates", xmlnsManager).InnerText.Split(',');// note long, lat, height
                    //the default heading is North,
                    // but it may be over-ridden by specifying @WPT-001 in the viewpoint decription
                    int heading = 0;
                    String desc = p.SelectSingleNode("kml:description", xmlnsManager).InnerText;
                    int i1 = desc.IndexOf('@')+1;
                    if (i1 >= 1)
                    {
                        String lookAt = "";
                        int i2 = desc.IndexOf(' ', i1);
                        if (i2 > i1)
                        {
                            lookAt = desc.Substring(i1, i2 - i1);//from @ to next space
                        }
                        else
                        {
                            lookAt = desc.Substring(i1);//from @ to end of string (no following space)
                        }
                        XmlNode lookAtNode = allKml.SelectSingleNode("//kml:Placemark[kml:name='" + lookAt + "']/kml:Point/kml:coordinates", xmlnsManager);
                        if (lookAtNode != null)
                        {
                            String[] lookAtCoords = lookAtNode.InnerText.Split(',');
                            heading = calcHeading(Convert.ToDouble(lookAtCoords[0]), Convert.ToDouble(lookAtCoords[1]), 
                                Convert.ToDouble(coords[0]), Convert.ToDouble(coords[1]));
                        }
                    }
                    file.WriteLine(comma ? "," : "");
                    file.Write(String.Format("\t\"{0}\":[{2},{1},{3}]", name, coords[0], coords[1], heading));
                    comma = true;
                }
                file.WriteLine("};");
            }
            // field sites
            file.WriteLine("// sites to visit. data is lat, lon	");
            F = allKml.SelectSingleNode("//kml:Folder[kml:name='Site']", xmlnsManager);
            if (!F.HasChildNodes)
            {
                file.WriteLine("var sites = null;");
            }
            else
            {
                file.Write("var sites = {");
                XmlNodeList placemarks = F.SelectNodes("./kml:Folder/kml:Placemark", xmlnsManager);
                bool comma = false;
                foreach (XmlNode p in placemarks)
                {
                    String name = p.SelectSingleNode("kml:name", xmlnsManager).InnerText;
                    String[] coords = p.SelectSingleNode("./kml:Point/kml:coordinates", xmlnsManager).InnerText.Split(',');// note long, lat, height
                    file.WriteLine(comma ? "," : "");
                    file.Write(String.Format("\t\"{0}\":[{2},{1}]", name, coords[0], coords[1]));
                    comma = true;
                }
                file.WriteLine("};");
            }

            //visibility is toggled for all folders. 
            file.WriteLine("// visibility and colour key. data is folder name, colour");
            file.Write("var visibility = [");
            bool vcomma = false;
            doVisibilityJS(file, allKml, "Viewpoint", ref vcomma);
            doVisibilityJS(file, allKml, "Site", ref vcomma);
            doVisibilityJS(file, allKml, "Landmark", ref vcomma);
            doVisibilityJS(file, allKml, "Routes", ref vcomma);
            doVisibilityJS(file, allKml, "Geo Features", ref vcomma);
            file.WriteLine("];");//end of visibility

            file.Close();

            MessageBox.Show("Saved to " + folderDialog.SelectedPath);
        }

        //NB: this is VERY rough and ready calculation. Actually VERY wrong but simple to point us roughly right dirn
        private int calcHeading(double toX, double toY, double fromX, double fromY){
            double angRad = Math.Atan2(toY-fromY, toX-fromX);
            int angDeg = (int)(180 * angRad / Math.PI);
            //convert to conventional headings
            angDeg = 90 - angDeg;
            if (angDeg >= 360) angDeg -= 360;
            if (angDeg <0) angDeg += 360;
            return (int)angDeg;
        }

        private void doVisibilityJS(System.IO.StreamWriter outFile, XmlDocument doc, String parentFolder, ref bool comma)
        {
            XmlNamespaceManager xmlnsManager = new XmlNamespaceManager(doc.NameTable);
            xmlnsManager.AddNamespace("kml", "http://www.opengis.net/kml/2.2");
            XmlNode F = doc.SelectSingleNode("//kml:Folder[kml:name='"+parentFolder+"']", xmlnsManager);
            if (F.ChildNodes.Count > 1)//there is always a <name> child
            {
                XmlNodeList folders = F.SelectNodes("./kml:Folder", xmlnsManager);
                foreach (XmlNode f in folders)
                {
                    String name = f.SelectSingleNode("kml:name", xmlnsManager).InnerText;
                    // get the colour, noting that it is BGR in KML
                    String style = f.SelectSingleNode("kml:Placemark/kml:styleUrl", xmlnsManager).InnerText.Substring(1);
                    String colBGR = doc.SelectSingleNode("//kml:Style[@id='" + style + "']//kml:color", xmlnsManager).InnerText.Substring(2);
                    String colRGB = colBGR.Substring(4, 2) + colBGR.Substring(2, 2) + colBGR.Substring(0, 2);
                    outFile.WriteLine(comma ? "," : "");
                    outFile.Write(String.Format("\t[\"{0}\",\"#{1}\"]", name, colRGB));
                    comma = true;
                }
            }
        }

        private XmlNode CreateNamedFolder(XmlDocument kml, String name){
            XmlNode f = kml.CreateElement("Folder", "http://www.opengis.net/kml/2.2");
            XmlNode n = kml.CreateElement("name", "http://www.opengis.net/kml/2.2");
            n.InnerText=name;
            f.AppendChild(n);
            return f;
        }
        #endregion

        #region POI tab Controls
        private void btnOpenPOIs_Click(object sender, EventArgs e)
        {
            DialogResult fileResult = openFileDialog.ShowDialog();
            if (fileResult == DialogResult.OK)
            {
                //get and clean the KML and write out to the debug tab
                poiKml = loadAndCleanKML(openFileDialog.FileName, kmlType.WAYPOINT, true);
                txtKml.Text = poiKml.InnerXml;
                //get the prefixes, write to debug tab and initialise the checkbox list
                String poiPrefixes = findPrefixes(poiKml, kmlType.WAYPOINT, '-');
                txtPrefixes.Text = poiPrefixes;
                foreach (String p in poiPrefixes.Split(','))
                {
                    poiListBox.Items.Add(new FolderInfo(p,"Site", Color.Black), true);
                }
                grpPoiFolder.Enabled = true;
                poiListBox.SelectedIndex = 0;
            }
        }
        private void poiListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FolderInfo selItem = (FolderInfo)poiListBox.Items[poiListBox.SelectedIndex];
            txtFolderTitle.Text = selItem.Title;
            for (int i = 0; i<contentType.Items.Count; i++)
            {
                if (contentType.Items[i].ToString() == selItem.POItype)
                {
                    contentType.SelectedIndex = i;
                    break;
                }
            }
            pnlColour.BackColor = selItem.Colour;
        }
        private void txtFolderTitle_Leave(object sender, EventArgs e)
        {
            ((FolderInfo)poiListBox.Items[poiListBox.SelectedIndex]).Title = txtFolderTitle.Text;
        }
        private void contentType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (contentType.SelectedIndex > -1)
            {
                String s = contentType.Items[contentType.SelectedIndex].ToString();
                ((FolderInfo)poiListBox.Items[poiListBox.SelectedIndex]).POItype = s;
            }
        }
        private void btnChangeColour_Click(object sender, EventArgs e)
        {
            DialogResult colResult = colorDialog.ShowDialog();
            if (colResult == DialogResult.OK)
            {
                pnlColour.BackColor = colorDialog.Color;
                ((FolderInfo)poiListBox.Items[poiListBox.SelectedIndex]).Colour = colorDialog.Color;
            }
        }
        #endregion

        #region ROUTE tab Controls
        private void btnOpenRoutes_Click(object sender, EventArgs e)
        {
            DialogResult fileResult = openFileDialog.ShowDialog();
            if (fileResult == DialogResult.OK)
            {
                routeKml = loadAndCleanKML(openFileDialog.FileName, kmlType.ROUTE, true);
                txtKml.Text = routeKml.InnerXml;
                String routePrefixes = findPrefixes(routeKml, kmlType.ROUTE, ' ');
                txtPrefixes.Text = routePrefixes;
                foreach (String p in routePrefixes.Split(','))
                {
                    routeListBox.Items.Add(new FolderInfo(p, "Route", Color.Red), true);
                }
                grpRouteFolder.Enabled = true;
                routeListBox.SelectedIndex = 0;
            }
        }
        private void routeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FolderInfo selItem = (FolderInfo)routeListBox.Items[routeListBox.SelectedIndex];
            txtRouteTitle.Text = selItem.Title;
            pnlRouteColour.BackColor = selItem.Colour;
        }
        private void txtRouteTitle_Leave(object sender, EventArgs e)
        {
            ((FolderInfo)routeListBox.Items[routeListBox.SelectedIndex]).Title = txtRouteTitle.Text;
        }
        private void btnRouteColour_Click(object sender, EventArgs e)
        {
            DialogResult colResult = colorDialog.ShowDialog();
            if (colResult == DialogResult.OK)
            {
                pnlRouteColour.BackColor = colorDialog.Color;
                ((FolderInfo)routeListBox.Items[routeListBox.SelectedIndex]).Colour = colorDialog.Color;
            }
        }
        #endregion

        #region GEO tab Controls    
        private void btnOpenGeo_Click(object sender, EventArgs e)
        {
            DialogResult fileResult = openFileDialog.ShowDialog();
            if (fileResult == DialogResult.OK)
            {
                geoKml = loadAndCleanKML(openFileDialog.FileName, kmlType.ROUTE, true);
                txtKml.Text = geoKml.InnerXml;
                String geoPrefixes = findPrefixes(geoKml, kmlType.ROUTE, ' ');
                txtPrefixes.Text = geoPrefixes;
                foreach (String p in geoPrefixes.Split(','))
                {
                    geoListBox.Items.Add(new FolderInfo(p, "Geo Features", Color.Blue), true);
                }
                grpGeoFolder.Enabled = true;
                geoListBox.SelectedIndex = 0;
            }
        }
        private void geoListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FolderInfo selItem = (FolderInfo)geoListBox.Items[geoListBox.SelectedIndex];
            txtGeoTitle.Text = selItem.Title;
            pnlGeoColour.BackColor = selItem.Colour;
        }
        private void txtGeoTitle_Leave(object sender, EventArgs e)
        {
            ((FolderInfo)geoListBox.Items[geoListBox.SelectedIndex]).Title = txtGeoTitle.Text;
        }
        private void btnGeoColour_Click(object sender, EventArgs e)
        {
            DialogResult colResult = colorDialog.ShowDialog();
            if (colResult == DialogResult.OK)
            {
                pnlGeoColour.BackColor = colorDialog.Color;
                ((FolderInfo)geoListBox.Items[geoListBox.SelectedIndex]).Colour = colorDialog.Color;
            }
        }
        #endregion


    }

    #region Classes and Enumerations
    public enum kmlType
    {
        WAYPOINT,
        ROUTE,
        ANY
    }
    public class FolderInfo
    {
        public String Prefix;
        public String Title;
        // POItype must be a fixed list, assumed to be from Site,Viewpoint,Landmark as per the poiTypes variable in class frmMain
        public String POItype;
        public Color Colour;

        public override String ToString()
        {
            return Prefix;
        }

        public String argbColour
        {
            get
            {
                //the color picker does not use alpha, so Colour.A is always FF.
                //hard-code 99 for a slightly-transparent alternative
                //Note kml colour order is BGR !!!!!!!!!!!!!!!!!!
                return string.Format("99{0:X2}{1:X2}{2:X2}", Colour.B, Colour.G, Colour.R);
            }
        }

        public FolderInfo(String prefix, String typ, Color col){
            Prefix = prefix;
            Title = prefix;
            POItype = typ;
            Colour = col;
        }

        public FolderInfo()
        {
        }
    }
    #endregion

}
