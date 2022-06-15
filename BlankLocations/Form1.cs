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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toolStrip1.Renderer = new MySR();
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this button will run the report");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var temp = this.Size;
            Console.WriteLine();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
        }
        public void LoadForm(object Form)
        {
            for (int i = panel1.Controls.Count; i > 0; i--)
            {
                this.panel1.Controls.RemoveAt(0);
            }
            Form f = (Form)Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(f);
            this.panel1.Tag = f;
            f.Show();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            Size panelSize = panel1.Size;
            LoadForm(new BlankLocationsReport(panelSize));
        }
    }
    
}
