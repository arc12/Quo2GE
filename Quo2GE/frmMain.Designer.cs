namespace Quo2GE
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.txtBaseURL = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMainTitle = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnOutput = new System.Windows.Forms.Button();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabPage = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.poiListBox = new System.Windows.Forms.CheckedListBox();
            this.grpPoiFolder = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlColour = new System.Windows.Forms.Panel();
            this.btnChangeColour = new System.Windows.Forms.Button();
            this.contentType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFolderTitle = new System.Windows.Forms.TextBox();
            this.btnOpenPOIs = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.grpRouteFolder = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlRouteColour = new System.Windows.Forms.Panel();
            this.btnRouteColour = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRouteTitle = new System.Windows.Forms.TextBox();
            this.routeListBox = new System.Windows.Forms.CheckedListBox();
            this.btnOpenRoutes = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.grpGeoFolder = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlGeoColour = new System.Windows.Forms.Panel();
            this.btnGeoColour = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtGeoTitle = new System.Windows.Forms.TextBox();
            this.geoListBox = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpenGeo = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.KML = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrefixes = new System.Windows.Forms.TextBox();
            this.txtKml = new System.Windows.Forms.TextBox();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.pnlLeft.SuspendLayout();
            this.tabs.SuspendLayout();
            this.tabPage.SuspendLayout();
            this.grpPoiFolder.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grpRouteFolder.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.grpGeoFolder.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.txtBaseURL);
            this.pnlLeft.Controls.Add(this.label17);
            this.pnlLeft.Controls.Add(this.label14);
            this.pnlLeft.Controls.Add(this.txtMainTitle);
            this.pnlLeft.Controls.Add(this.btnExport);
            this.pnlLeft.Controls.Add(this.btnAbout);
            this.pnlLeft.Controls.Add(this.btnOutput);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(473, 84);
            this.pnlLeft.TabIndex = 0;
            // 
            // txtBaseURL
            // 
            this.txtBaseURL.Location = new System.Drawing.Point(83, 57);
            this.txtBaseURL.Name = "txtBaseURL";
            this.txtBaseURL.Size = new System.Drawing.Size(311, 20);
            this.txtBaseURL.TabIndex = 6;
            this.txtBaseURL.Text = "http://www.hilltop-cottage.info/vt/";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 60);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "Base URL";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(8, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 17);
            this.label14.TabIndex = 4;
            this.label14.Text = "Main Title";
            // 
            // txtMainTitle
            // 
            this.txtMainTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMainTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMainTitle.Location = new System.Drawing.Point(83, 6);
            this.txtMainTitle.Name = "txtMainTitle";
            this.txtMainTitle.Size = new System.Drawing.Size(311, 23);
            this.txtMainTitle.TabIndex = 3;
            this.txtMainTitle.Text = "Google Earth Geo";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(190, 33);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(109, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.Location = new System.Drawing.Point(400, 6);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(69, 23);
            this.btnAbout.TabIndex = 2;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(83, 33);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(101, 23);
            this.btnOutput.TabIndex = 0;
            this.btnOutput.Text = "Set Output Folder";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabPage);
            this.tabs.Controls.Add(this.tabPage2);
            this.tabs.Controls.Add(this.tabPage3);
            this.tabs.Controls.Add(this.tabPage1);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 84);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(473, 278);
            this.tabs.TabIndex = 3;
            // 
            // tabPage
            // 
            this.tabPage.Controls.Add(this.label15);
            this.tabPage.Controls.Add(this.poiListBox);
            this.tabPage.Controls.Add(this.grpPoiFolder);
            this.tabPage.Controls.Add(this.btnOpenPOIs);
            this.tabPage.Location = new System.Drawing.Point(4, 22);
            this.tabPage.Name = "tabPage";
            this.tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage.Size = new System.Drawing.Size(465, 252);
            this.tabPage.TabIndex = 0;
            this.tabPage.Text = "Points of Interest";
            this.tabPage.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 41);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "POI Sets";
            // 
            // poiListBox
            // 
            this.poiListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.poiListBox.FormattingEnabled = true;
            this.poiListBox.Location = new System.Drawing.Point(9, 58);
            this.poiListBox.Name = "poiListBox";
            this.poiListBox.Size = new System.Drawing.Size(113, 184);
            this.poiListBox.TabIndex = 9;
            this.poiListBox.SelectedIndexChanged += new System.EventHandler(this.poiListBox_SelectedIndexChanged);
            // 
            // grpPoiFolder
            // 
            this.grpPoiFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPoiFolder.Controls.Add(this.label5);
            this.grpPoiFolder.Controls.Add(this.pnlColour);
            this.grpPoiFolder.Controls.Add(this.btnChangeColour);
            this.grpPoiFolder.Controls.Add(this.contentType);
            this.grpPoiFolder.Controls.Add(this.label3);
            this.grpPoiFolder.Controls.Add(this.label4);
            this.grpPoiFolder.Controls.Add(this.txtFolderTitle);
            this.grpPoiFolder.Enabled = false;
            this.grpPoiFolder.Location = new System.Drawing.Point(128, 58);
            this.grpPoiFolder.Name = "grpPoiFolder";
            this.grpPoiFolder.Size = new System.Drawing.Size(329, 186);
            this.grpPoiFolder.TabIndex = 8;
            this.grpPoiFolder.TabStop = false;
            this.grpPoiFolder.Text = "Folder Properties";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Colour";
            // 
            // pnlColour
            // 
            this.pnlColour.BackColor = System.Drawing.Color.Black;
            this.pnlColour.Location = new System.Drawing.Point(27, 143);
            this.pnlColour.Name = "pnlColour";
            this.pnlColour.Size = new System.Drawing.Size(94, 23);
            this.pnlColour.TabIndex = 9;
            // 
            // btnChangeColour
            // 
            this.btnChangeColour.Location = new System.Drawing.Point(136, 143);
            this.btnChangeColour.Name = "btnChangeColour";
            this.btnChangeColour.Size = new System.Drawing.Size(94, 25);
            this.btnChangeColour.TabIndex = 8;
            this.btnChangeColour.Text = "Change Colour";
            this.btnChangeColour.UseVisualStyleBackColor = true;
            this.btnChangeColour.Click += new System.EventHandler(this.btnChangeColour_Click);
            // 
            // contentType
            // 
            this.contentType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.contentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.contentType.FormattingEnabled = true;
            this.contentType.Location = new System.Drawing.Point(27, 91);
            this.contentType.Name = "contentType";
            this.contentType.Size = new System.Drawing.Size(294, 21);
            this.contentType.TabIndex = 6;
            this.contentType.SelectionChangeCommitted += new System.EventHandler(this.contentType_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Title";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Content Type";
            // 
            // txtFolderTitle
            // 
            this.txtFolderTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolderTitle.Location = new System.Drawing.Point(27, 41);
            this.txtFolderTitle.Name = "txtFolderTitle";
            this.txtFolderTitle.Size = new System.Drawing.Size(294, 20);
            this.txtFolderTitle.TabIndex = 4;
            this.txtFolderTitle.Leave += new System.EventHandler(this.txtFolderTitle_Leave);
            // 
            // btnOpenPOIs
            // 
            this.btnOpenPOIs.Location = new System.Drawing.Point(9, 6);
            this.btnOpenPOIs.Name = "btnOpenPOIs";
            this.btnOpenPOIs.Size = new System.Drawing.Size(113, 23);
            this.btnOpenPOIs.TabIndex = 0;
            this.btnOpenPOIs.Text = "Load KML";
            this.btnOpenPOIs.UseVisualStyleBackColor = true;
            this.btnOpenPOIs.Click += new System.EventHandler(this.btnOpenPOIs_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.grpRouteFolder);
            this.tabPage2.Controls.Add(this.routeListBox);
            this.tabPage2.Controls.Add(this.btnOpenRoutes);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(465, 252);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Routes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 41);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 10;
            this.label16.Text = "Route Sets";
            // 
            // grpRouteFolder
            // 
            this.grpRouteFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRouteFolder.Controls.Add(this.label9);
            this.grpRouteFolder.Controls.Add(this.label6);
            this.grpRouteFolder.Controls.Add(this.pnlRouteColour);
            this.grpRouteFolder.Controls.Add(this.btnRouteColour);
            this.grpRouteFolder.Controls.Add(this.label7);
            this.grpRouteFolder.Controls.Add(this.label8);
            this.grpRouteFolder.Controls.Add(this.txtRouteTitle);
            this.grpRouteFolder.Enabled = false;
            this.grpRouteFolder.Location = new System.Drawing.Point(127, 58);
            this.grpRouteFolder.Name = "grpRouteFolder";
            this.grpRouteFolder.Size = new System.Drawing.Size(310, 184);
            this.grpRouteFolder.TabIndex = 9;
            this.grpRouteFolder.TabStop = false;
            this.grpRouteFolder.Text = "Folder Properties";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(22, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Route";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Colour";
            // 
            // pnlRouteColour
            // 
            this.pnlRouteColour.BackColor = System.Drawing.Color.Black;
            this.pnlRouteColour.Location = new System.Drawing.Point(25, 145);
            this.pnlRouteColour.Name = "pnlRouteColour";
            this.pnlRouteColour.Size = new System.Drawing.Size(94, 23);
            this.pnlRouteColour.TabIndex = 9;
            // 
            // btnRouteColour
            // 
            this.btnRouteColour.Location = new System.Drawing.Point(125, 145);
            this.btnRouteColour.Name = "btnRouteColour";
            this.btnRouteColour.Size = new System.Drawing.Size(94, 25);
            this.btnRouteColour.TabIndex = 8;
            this.btnRouteColour.Text = "Change Colour";
            this.btnRouteColour.UseVisualStyleBackColor = true;
            this.btnRouteColour.Click += new System.EventHandler(this.btnRouteColour_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Title";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Content Type";
            // 
            // txtRouteTitle
            // 
            this.txtRouteTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRouteTitle.Location = new System.Drawing.Point(25, 41);
            this.txtRouteTitle.Name = "txtRouteTitle";
            this.txtRouteTitle.Size = new System.Drawing.Size(273, 20);
            this.txtRouteTitle.TabIndex = 4;
            this.txtRouteTitle.Leave += new System.EventHandler(this.txtRouteTitle_Leave);
            // 
            // routeListBox
            // 
            this.routeListBox.FormattingEnabled = true;
            this.routeListBox.Location = new System.Drawing.Point(11, 59);
            this.routeListBox.Name = "routeListBox";
            this.routeListBox.Size = new System.Drawing.Size(110, 184);
            this.routeListBox.TabIndex = 1;
            this.routeListBox.SelectedIndexChanged += new System.EventHandler(this.routeListBox_SelectedIndexChanged);
            // 
            // btnOpenRoutes
            // 
            this.btnOpenRoutes.Location = new System.Drawing.Point(11, 6);
            this.btnOpenRoutes.Name = "btnOpenRoutes";
            this.btnOpenRoutes.Size = new System.Drawing.Size(110, 23);
            this.btnOpenRoutes.TabIndex = 0;
            this.btnOpenRoutes.Text = "Load KML";
            this.btnOpenRoutes.UseVisualStyleBackColor = true;
            this.btnOpenRoutes.Click += new System.EventHandler(this.btnOpenRoutes_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.grpGeoFolder);
            this.tabPage3.Controls.Add(this.geoListBox);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.btnOpenGeo);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(465, 252);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Geo Structures";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // grpGeoFolder
            // 
            this.grpGeoFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGeoFolder.Controls.Add(this.label10);
            this.grpGeoFolder.Controls.Add(this.label11);
            this.grpGeoFolder.Controls.Add(this.pnlGeoColour);
            this.grpGeoFolder.Controls.Add(this.btnGeoColour);
            this.grpGeoFolder.Controls.Add(this.label12);
            this.grpGeoFolder.Controls.Add(this.label13);
            this.grpGeoFolder.Controls.Add(this.txtGeoTitle);
            this.grpGeoFolder.Enabled = false;
            this.grpGeoFolder.Location = new System.Drawing.Point(133, 60);
            this.grpGeoFolder.Name = "grpGeoFolder";
            this.grpGeoFolder.Size = new System.Drawing.Size(307, 184);
            this.grpGeoFolder.TabIndex = 10;
            this.grpGeoFolder.TabStop = false;
            this.grpGeoFolder.Text = "Folder Properties";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(22, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Geo Feature";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Colour";
            // 
            // pnlGeoColour
            // 
            this.pnlGeoColour.BackColor = System.Drawing.Color.Black;
            this.pnlGeoColour.Location = new System.Drawing.Point(25, 145);
            this.pnlGeoColour.Name = "pnlGeoColour";
            this.pnlGeoColour.Size = new System.Drawing.Size(94, 23);
            this.pnlGeoColour.TabIndex = 9;
            // 
            // btnGeoColour
            // 
            this.btnGeoColour.Location = new System.Drawing.Point(125, 145);
            this.btnGeoColour.Name = "btnGeoColour";
            this.btnGeoColour.Size = new System.Drawing.Size(94, 25);
            this.btnGeoColour.TabIndex = 8;
            this.btnGeoColour.Text = "Change Colour";
            this.btnGeoColour.UseVisualStyleBackColor = true;
            this.btnGeoColour.Click += new System.EventHandler(this.btnGeoColour_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Title";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Content Type";
            // 
            // txtGeoTitle
            // 
            this.txtGeoTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGeoTitle.Location = new System.Drawing.Point(25, 41);
            this.txtGeoTitle.Name = "txtGeoTitle";
            this.txtGeoTitle.Size = new System.Drawing.Size(276, 20);
            this.txtGeoTitle.TabIndex = 4;
            this.txtGeoTitle.Leave += new System.EventHandler(this.txtGeoTitle_Leave);
            // 
            // geoListBox
            // 
            this.geoListBox.FormattingEnabled = true;
            this.geoListBox.Location = new System.Drawing.Point(11, 60);
            this.geoListBox.Name = "geoListBox";
            this.geoListBox.Size = new System.Drawing.Size(116, 184);
            this.geoListBox.TabIndex = 7;
            this.geoListBox.SelectedIndexChanged += new System.EventHandler(this.geoListBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Geo Sets";
            // 
            // btnOpenGeo
            // 
            this.btnOpenGeo.Location = new System.Drawing.Point(11, 6);
            this.btnOpenGeo.Name = "btnOpenGeo";
            this.btnOpenGeo.Size = new System.Drawing.Size(106, 25);
            this.btnOpenGeo.TabIndex = 0;
            this.btnOpenGeo.Text = "Load KML";
            this.btnOpenGeo.UseVisualStyleBackColor = true;
            this.btnOpenGeo.Click += new System.EventHandler(this.btnOpenGeo_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.KML);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtPrefixes);
            this.tabPage1.Controls.Add(this.txtKml);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(465, 252);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "(Debug Info)";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // KML
            // 
            this.KML.AutoSize = true;
            this.KML.Location = new System.Drawing.Point(8, 8);
            this.KML.Name = "KML";
            this.KML.Size = new System.Drawing.Size(29, 13);
            this.KML.TabIndex = 3;
            this.KML.Text = "KML";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Waypoint/Track Prefixes";
            // 
            // txtPrefixes
            // 
            this.txtPrefixes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrefixes.Location = new System.Drawing.Point(8, 224);
            this.txtPrefixes.Name = "txtPrefixes";
            this.txtPrefixes.Size = new System.Drawing.Size(427, 20);
            this.txtPrefixes.TabIndex = 1;
            // 
            // txtKml
            // 
            this.txtKml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKml.Location = new System.Drawing.Point(6, 24);
            this.txtKml.Multiline = true;
            this.txtKml.Name = "txtKml";
            this.txtKml.Size = new System.Drawing.Size(429, 181);
            this.txtKml.TabIndex = 0;
            // 
            // folderDialog
            // 
            this.folderDialog.RootFolder = System.Environment.SpecialFolder.Personal;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "KML files|*.kml";
            this.openFileDialog.Title = "Open KML File";
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 362);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.pnlLeft);
            this.Name = "frmMain";
            this.Text = "Quo 2 Google Earth";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.tabPage.ResumeLayout(false);
            this.tabPage.PerformLayout();
            this.grpPoiFolder.ResumeLayout(false);
            this.grpPoiFolder.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.grpRouteFolder.ResumeLayout(false);
            this.grpRouteFolder.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.grpGeoFolder.ResumeLayout(false);
            this.grpGeoFolder.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabPage;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnOpenPOIs;
        private System.Windows.Forms.Button btnOpenRoutes;
        private System.Windows.Forms.Button btnOpenGeo;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPrefixes;
        private System.Windows.Forms.TextBox txtKml;
        private System.Windows.Forms.Label KML;
        private System.Windows.Forms.CheckedListBox geoListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.CheckedListBox poiListBox;
        private System.Windows.Forms.GroupBox grpPoiFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlColour;
        private System.Windows.Forms.Button btnChangeColour;
        private System.Windows.Forms.ComboBox contentType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFolderTitle;
        private System.Windows.Forms.GroupBox grpRouteFolder;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlRouteColour;
        private System.Windows.Forms.Button btnRouteColour;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRouteTitle;
        private System.Windows.Forms.CheckedListBox routeListBox;
        private System.Windows.Forms.GroupBox grpGeoFolder;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pnlGeoColour;
        private System.Windows.Forms.Button btnGeoColour;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtGeoTitle;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMainTitle;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtBaseURL;
        private System.Windows.Forms.Label label17;
    }
}

