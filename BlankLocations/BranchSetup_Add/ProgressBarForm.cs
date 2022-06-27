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
        public ProgressBarForm(Point location, Size size)
        {
            InitializeComponent();
            //var newLocation_X = (size.Height / 2) + location.X;
            //var newLoation_Y = (size.Width / 2) + location.Y;
            //this.Location = new Point(newLocation_X, newLoation_Y);
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
