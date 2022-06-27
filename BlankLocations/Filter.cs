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
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(size.Width - 15, size.Height - 8);
            this.Location = new Point(location.X + 8, location.Y);
            this.BackColor = Color.WhiteSmoke;
            this.Opacity = 0.30;
        }
    }
}
