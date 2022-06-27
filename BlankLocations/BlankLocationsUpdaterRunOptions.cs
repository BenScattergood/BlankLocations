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
            textBox1.Text = "If this is the first time running the report," +
                " or you would like to make changes to the existing setup, " +
                "then run the report in 'Branch Setup' mode. Otherwise, " +
                "download the G05 report and then open " +
                "the report in 'Launch' mode.";
            rbLaunch.Checked = true;
            btnOk.Focus();
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

        private void BlankLocationsUpdaterRunOptions_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine();
        }
    }
}
