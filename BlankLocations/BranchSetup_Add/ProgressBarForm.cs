using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlankLocations.BranchSetup_Add
{
    public partial class ProgressBarForm : Form
    {
        public ProgressBarForm()
        {
            InitializeComponent();
        }

        public void IncrementProgressBar(int value)
        {
            this.progressBar1.Value += value;
        }

        public void SetProgressBar(int value)
        {
            this.progressBar1.Value = value;

        }
    }
}
