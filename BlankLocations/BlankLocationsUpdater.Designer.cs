namespace BlankLocations
{
    partial class BlankLocationsUpdater
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlankLocationsUpdater));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPopulate = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.tbFinalWords = new System.Windows.Forms.TextBox();
            this.tbHowTo = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbLastDigitChanges = new System.Windows.Forms.TextBox();
            this.btnAdd_LastDigitChanges = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_lastDigitChanges = new System.Windows.Forms.ListBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tbRemovedLocations = new System.Windows.Forms.TextBox();
            this.btnAdd_RemovedLocations = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_eliminatedLocations = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbBranchSetup = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bs_eliminatedLocations = new System.Windows.Forms.BindingSource(this.components);
            this.bs_lastDigitChanges = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_eliminatedLocations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_lastDigitChanges)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1287, 1056);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1279, 1030);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Blank Locations Updater";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnPopulate);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1273, 1024);
            this.panel1.TabIndex = 2;
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // btnPopulate
            // 
            this.btnPopulate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPopulate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPopulate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPopulate.FlatAppearance.BorderSize = 2;
            this.btnPopulate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPopulate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPopulate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPopulate.ImageIndex = 3;
            this.btnPopulate.ImageList = this.imageList1;
            this.btnPopulate.Location = new System.Drawing.Point(13, 127);
            this.btnPopulate.Margin = new System.Windows.Forms.Padding(2);
            this.btnPopulate.Name = "btnPopulate";
            this.btnPopulate.Size = new System.Drawing.Size(117, 29);
            this.btnPopulate.TabIndex = 2;
            this.btnPopulate.Text = "     Populate";
            this.btnPopulate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPopulate.UseVisualStyleBackColor = false;
            this.btnPopulate.TabIndexChanged += new System.EventHandler(this.btnPopulate_TabStopChanged);
            this.btnPopulate.Click += new System.EventHandler(this.btnPopulate_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-organize-64.png");
            this.imageList1.Images.SetKeyName(1, "icons8-plus-64.png");
            this.imageList1.Images.SetKeyName(2, "icons8-scroll-48.png");
            this.imageList1.Images.SetKeyName(3, "icons8-edit-graph-report-48.png");
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.btnLaunch);
            this.panel3.Controls.Add(this.tbFinalWords);
            this.panel3.Controls.Add(this.tbHowTo);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Location = new System.Drawing.Point(5, 161);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1268, 863);
            this.panel3.TabIndex = 11;
            // 
            // btnLaunch
            // 
            this.btnLaunch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLaunch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLaunch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLaunch.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLaunch.FlatAppearance.BorderSize = 2;
            this.btnLaunch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLaunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaunch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLaunch.ImageIndex = 3;
            this.btnLaunch.ImageList = this.imageList1;
            this.btnLaunch.Location = new System.Drawing.Point(1141, 804);
            this.btnLaunch.Margin = new System.Windows.Forms.Padding(2);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(117, 29);
            this.btnLaunch.TabIndex = 0;
            this.btnLaunch.Text = "     Launch";
            this.btnLaunch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLaunch.UseVisualStyleBackColor = false;
            this.btnLaunch.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // tbFinalWords
            // 
            this.tbFinalWords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFinalWords.BackColor = System.Drawing.SystemColors.Window;
            this.tbFinalWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFinalWords.Location = new System.Drawing.Point(8, 777);
            this.tbFinalWords.Multiline = true;
            this.tbFinalWords.Name = "tbFinalWords";
            this.tbFinalWords.ReadOnly = true;
            this.tbFinalWords.Size = new System.Drawing.Size(1105, 81);
            this.tbFinalWords.TabIndex = 19;
            this.tbFinalWords.TabStop = false;
            // 
            // tbHowTo
            // 
            this.tbHowTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHowTo.BackColor = System.Drawing.SystemColors.Window;
            this.tbHowTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHowTo.Location = new System.Drawing.Point(8, 3);
            this.tbHowTo.Multiline = true;
            this.tbHowTo.Name = "tbHowTo";
            this.tbHowTo.ReadOnly = true;
            this.tbHowTo.Size = new System.Drawing.Size(1255, 58);
            this.tbHowTo.TabIndex = 18;
            this.tbHowTo.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.tbLastDigitChanges);
            this.panel4.Controls.Add(this.btnAdd_LastDigitChanges);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.lb_lastDigitChanges);
            this.panel4.Location = new System.Drawing.Point(845, 73);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(419, 698);
            this.panel4.TabIndex = 16;
            // 
            // tbLastDigitChanges
            // 
            this.tbLastDigitChanges.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLastDigitChanges.BackColor = System.Drawing.SystemColors.Window;
            this.tbLastDigitChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLastDigitChanges.Location = new System.Drawing.Point(11, 39);
            this.tbLastDigitChanges.Multiline = true;
            this.tbLastDigitChanges.Name = "tbLastDigitChanges";
            this.tbLastDigitChanges.ReadOnly = true;
            this.tbLastDigitChanges.Size = new System.Drawing.Size(395, 130);
            this.tbLastDigitChanges.TabIndex = 19;
            this.tbLastDigitChanges.TabStop = false;
            // 
            // btnAdd_LastDigitChanges
            // 
            this.btnAdd_LastDigitChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd_LastDigitChanges.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAdd_LastDigitChanges.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd_LastDigitChanges.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAdd_LastDigitChanges.FlatAppearance.BorderSize = 2;
            this.btnAdd_LastDigitChanges.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd_LastDigitChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd_LastDigitChanges.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd_LastDigitChanges.ImageIndex = 1;
            this.btnAdd_LastDigitChanges.ImageList = this.imageList1;
            this.btnAdd_LastDigitChanges.Location = new System.Drawing.Point(289, 664);
            this.btnAdd_LastDigitChanges.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd_LastDigitChanges.Name = "btnAdd_LastDigitChanges";
            this.btnAdd_LastDigitChanges.Size = new System.Drawing.Size(117, 29);
            this.btnAdd_LastDigitChanges.TabIndex = 2;
            this.btnAdd_LastDigitChanges.Text = "     Add...";
            this.btnAdd_LastDigitChanges.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd_LastDigitChanges.UseVisualStyleBackColor = false;
            this.btnAdd_LastDigitChanges.Click += new System.EventHandler(this.btnAdd_LastDigitChanges_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.MidnightBlue;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(419, 27);
            this.label6.TabIndex = 1;
            this.label6.Text = "Last Digit Changes";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_lastDigitChanges
            // 
            this.lb_lastDigitChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_lastDigitChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_lastDigitChanges.FormattingEnabled = true;
            this.lb_lastDigitChanges.ItemHeight = 15;
            this.lb_lastDigitChanges.Location = new System.Drawing.Point(11, 175);
            this.lb_lastDigitChanges.Name = "lb_lastDigitChanges";
            this.lb_lastDigitChanges.Size = new System.Drawing.Size(395, 484);
            this.lb_lastDigitChanges.TabIndex = 4;
            this.lb_lastDigitChanges.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.panel5.Controls.Add(this.tbRemovedLocations);
            this.panel5.Controls.Add(this.btnAdd_RemovedLocations);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.lb_eliminatedLocations);
            this.panel5.Location = new System.Drawing.Point(8, 73);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(419, 698);
            this.panel5.TabIndex = 15;
            // 
            // tbRemovedLocations
            // 
            this.tbRemovedLocations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRemovedLocations.BackColor = System.Drawing.SystemColors.Window;
            this.tbRemovedLocations.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRemovedLocations.Location = new System.Drawing.Point(11, 39);
            this.tbRemovedLocations.Multiline = true;
            this.tbRemovedLocations.Name = "tbRemovedLocations";
            this.tbRemovedLocations.ReadOnly = true;
            this.tbRemovedLocations.Size = new System.Drawing.Size(395, 130);
            this.tbRemovedLocations.TabIndex = 7;
            this.tbRemovedLocations.TabStop = false;
            // 
            // btnAdd_RemovedLocations
            // 
            this.btnAdd_RemovedLocations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd_RemovedLocations.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAdd_RemovedLocations.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd_RemovedLocations.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAdd_RemovedLocations.FlatAppearance.BorderSize = 2;
            this.btnAdd_RemovedLocations.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd_RemovedLocations.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd_RemovedLocations.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd_RemovedLocations.ImageIndex = 1;
            this.btnAdd_RemovedLocations.ImageList = this.imageList1;
            this.btnAdd_RemovedLocations.Location = new System.Drawing.Point(289, 664);
            this.btnAdd_RemovedLocations.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd_RemovedLocations.Name = "btnAdd_RemovedLocations";
            this.btnAdd_RemovedLocations.Size = new System.Drawing.Size(117, 29);
            this.btnAdd_RemovedLocations.TabIndex = 1;
            this.btnAdd_RemovedLocations.Text = "     Add...";
            this.btnAdd_RemovedLocations.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd_RemovedLocations.UseVisualStyleBackColor = false;
            this.btnAdd_RemovedLocations.Click += new System.EventHandler(this.btnAdd_RemovedLocations_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.MidnightBlue;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(419, 27);
            this.label4.TabIndex = 1;
            this.label4.Text = "Removed Locations";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_eliminatedLocations
            // 
            this.lb_eliminatedLocations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_eliminatedLocations.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_eliminatedLocations.FormattingEnabled = true;
            this.lb_eliminatedLocations.ItemHeight = 15;
            this.lb_eliminatedLocations.Location = new System.Drawing.Point(11, 175);
            this.lb_eliminatedLocations.Name = "lb_eliminatedLocations";
            this.lb_eliminatedLocations.Size = new System.Drawing.Size(395, 484);
            this.lb_eliminatedLocations.TabIndex = 0;
            this.lb_eliminatedLocations.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.tbBranchSetup);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(5, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1263, 109);
            this.panel2.TabIndex = 10;
            // 
            // tbBranchSetup
            // 
            this.tbBranchSetup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBranchSetup.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbBranchSetup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBranchSetup.Location = new System.Drawing.Point(8, 34);
            this.tbBranchSetup.Multiline = true;
            this.tbBranchSetup.Name = "tbBranchSetup";
            this.tbBranchSetup.ReadOnly = true;
            this.tbBranchSetup.Size = new System.Drawing.Size(1245, 65);
            this.tbBranchSetup.TabIndex = 3;
            this.tbBranchSetup.TabStop = false;
            this.tbBranchSetup.Text = "If this is the first time running the report, or you would like to make changes t" +
    "o the existing setup, then run the report in \'Branch Setup\' mode.   Otherwise, o" +
    "pen the report in \'Launch\' mode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.MidnightBlue;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1263, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Branch Setup";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BlankLocationsUpdater
            // 
            this.AcceptButton = this.btnPopulate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1287, 1056);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BlankLocationsUpdater";
            this.Text = "BlankLocationsReport";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_eliminatedLocations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_lastDigitChanges)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bs_eliminatedLocations;
        private System.Windows.Forms.BindingSource bs_lastDigitChanges;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbBranchSetup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnAdd_LastDigitChanges;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lb_lastDigitChanges;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnAdd_RemovedLocations;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lb_eliminatedLocations;
        private System.Windows.Forms.Button btnPopulate;
        private System.Windows.Forms.TextBox tbHowTo;
        private System.Windows.Forms.TextBox tbRemovedLocations;
        private System.Windows.Forms.TextBox tbLastDigitChanges;
        private System.Windows.Forms.TextBox tbFinalWords;
        private System.Windows.Forms.Button btnLaunch;
    }
}