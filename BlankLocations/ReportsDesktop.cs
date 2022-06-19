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
    public partial class ReportsDesktop : Form
    {
        public BlankLocationsUpdater blankLocationUpdater;
        public ReportsDesktop()
        {
            InitializeComponent();
            toolStrip1.Renderer = new MySR();
            Size panelSize = splitContainer1.Panel2.Size;
            LoadForm(new NoReportSelected(panelSize));
        }
        public void LoadForm(object Form)
        {
            for (int i = splitContainer1.Panel2.Controls.Count; i > 0; i--)
            {
                this.splitContainer1.Panel2.Controls.RemoveAt(0);
            }
            var f = (Form)Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(f);
            this.splitContainer1.Panel2.Tag = f;
            f.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
        }
        

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (blankLocationUpdater != null)
            {
                MessageBox.Show("Report already running");
            }
            var form2 = new BlankLocationsUpdaterRunOptions();
            form2.ShowDialog();
            if (form2.DialogResult == DialogResult.OK)
            {
                Size panelSize = splitContainer1.Panel2.Size;
                blankLocationUpdater = new BlankLocationsUpdater(panelSize);
                LoadForm(blankLocationUpdater);
            }   
        }

        private void tsBtnClose_Click(object sender, EventArgs e)
        {
            if (blankLocationUpdater == null)
            {
                return;
            }
            blankLocationUpdater.currentVersionLogic.CleanUp();
            blankLocationUpdater.Close();
            Size panelSize = splitContainer1.Panel2.Size;
            LoadForm(new NoReportSelected(panelSize));
            blankLocationUpdater = null;
        }
    }
    
}
