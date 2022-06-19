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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.clb_lastDigitChanges = new System.Windows.Forms.CheckedListBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lb_lastDigitChanges = new System.Windows.Forms.ListBox();
            this.lb_eliminatedLocations = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.clb_locations = new System.Windows.Forms.CheckedListBox();
            this.bs_eliminatedLocations = new System.Windows.Forms.BindingSource(this.components);
            this.bs_lastDigitChanges = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(1130, 693);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1122, 667);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Blank Locations Updater";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.clb_lastDigitChanges);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.lb_lastDigitChanges);
            this.panel1.Controls.Add(this.lb_eliminatedLocations);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.clb_locations);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1116, 661);
            this.panel1.TabIndex = 2;
            // 
            // clb_lastDigitChanges
            // 
            this.clb_lastDigitChanges.CheckOnClick = true;
            this.clb_lastDigitChanges.FormattingEnabled = true;
            this.clb_lastDigitChanges.Location = new System.Drawing.Point(340, 317);
            this.clb_lastDigitChanges.Name = "clb_lastDigitChanges";
            this.clb_lastDigitChanges.Size = new System.Drawing.Size(167, 199);
            this.clb_lastDigitChanges.TabIndex = 8;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(461, 556);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(633, 426);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lb_lastDigitChanges
            // 
            this.lb_lastDigitChanges.FormattingEnabled = true;
            this.lb_lastDigitChanges.Location = new System.Drawing.Point(903, 399);
            this.lb_lastDigitChanges.Name = "lb_lastDigitChanges";
            this.lb_lastDigitChanges.Size = new System.Drawing.Size(120, 95);
            this.lb_lastDigitChanges.TabIndex = 4;
            // 
            // lb_eliminatedLocations
            // 
            this.lb_eliminatedLocations.FormattingEnabled = true;
            this.lb_eliminatedLocations.Location = new System.Drawing.Point(717, 131);
            this.lb_eliminatedLocations.Name = "lb_eliminatedLocations";
            this.lb_eliminatedLocations.Size = new System.Drawing.Size(120, 95);
            this.lb_eliminatedLocations.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(553, 203);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // clb_locations
            // 
            this.clb_locations.CheckOnClick = true;
            this.clb_locations.FormattingEnabled = true;
            this.clb_locations.Location = new System.Drawing.Point(330, 112);
            this.clb_locations.Name = "clb_locations";
            this.clb_locations.Size = new System.Drawing.Size(167, 199);
            this.clb_locations.TabIndex = 0;
            // 
            // BlankLocationsUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1130, 693);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BlankLocationsUpdater";
            this.Text = "BlankLocationsReport";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BlankLocationsUpdater_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.CheckedListBox clb_lastDigitChanges;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lb_lastDigitChanges;
        private System.Windows.Forms.ListBox lb_eliminatedLocations;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckedListBox clb_locations;
    }
}