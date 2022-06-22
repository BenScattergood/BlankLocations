using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlankLocations
{
    public partial class BlankLocationsUpdaterRunOptions : Form
    {
        public bool BranchSetup;
        public bool Launch;
        public BlankLocationsUpdaterRunOptions()
        {
            InitializeComponent();
            btnOk.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void BlankLocationsUpdaterRunOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (rbBranchSetup.Checked)
            {
                BranchSetup = true;
            }
            else if (rbLaunch.Checked)
            {
                Launch = true;
            }
            else
            {
                BranchSetup = false;
                Launch = false;
            }
        }
    }
}
