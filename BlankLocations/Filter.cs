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
    public partial class Filter : Form
    {
        public Filter(Size size, Point location)
        {
            InitializeComponent();
            this.Location = location;
            this.Size = size;
            this.BackColor = Color.Black;
            //this.ForeColor = Color.Black;
            this.Opacity = 0.25;
        }
    }
}
