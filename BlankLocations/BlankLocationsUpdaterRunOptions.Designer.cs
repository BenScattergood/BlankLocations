namespace BlankLocations
{
    partial class BlankLocationsUpdaterRunOptions
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
            this.rbBranchSetup = new System.Windows.Forms.RadioButton();
            this.rbLaunch = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbBranchSetup
            // 
            this.rbBranchSetup.AutoSize = true;
            this.rbBranchSetup.Location = new System.Drawing.Point(112, 77);
            this.rbBranchSetup.Name = "rbBranchSetup";
            this.rbBranchSetup.Size = new System.Drawing.Size(90, 17);
            this.rbBranchSetup.TabIndex = 0;
            this.rbBranchSetup.TabStop = true;
            this.rbBranchSetup.Text = "Branch Setup";
            this.rbBranchSetup.UseVisualStyleBackColor = true;
            // 
            // rbLaunch
            // 
            this.rbLaunch.AutoSize = true;
            this.rbLaunch.Location = new System.Drawing.Point(112, 109);
            this.rbLaunch.Name = "rbLaunch";
            this.rbLaunch.Size = new System.Drawing.Size(61, 17);
            this.rbLaunch.TabIndex = 1;
            this.rbLaunch.TabStop = true;
            this.rbLaunch.Text = "Launch";
            this.rbLaunch.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(126, 175);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(237, 175);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // BlankLocationsUpdaterRunOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 256);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.rbLaunch);
            this.Controls.Add(this.rbBranchSetup);
            this.Name = "BlankLocationsUpdaterRunOptions";
            this.Text = "BlankLocationsUpdaterRunOptions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbBranchSetup;
        private System.Windows.Forms.RadioButton rbLaunch;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}