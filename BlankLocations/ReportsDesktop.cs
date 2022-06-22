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
            this.WindowState = FormWindowState.Maximized;
            //var size = this.Size.Height - menuStrip1.Size.Height -
            //    toolStrip1.Size.Height - label2.Size.Height;
            //splitContainer1.Size = new Size(splitContainer1.Size.Width, size);
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
        }
        

        private void tsBtnClose_Click(object sender, EventArgs e)
        {
            if (blankLocationUpdater == null)
            {
                return;
            }
            blankLocationUpdater.Close();
            Size panelSize = splitContainer1.Panel2.Size;
            LoadForm(new NoReportSelected(panelSize));
            blankLocationUpdater = null;
        }

        private void ReportsDesktop_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (blankLocationUpdater == null)
            {
                return;
            }
            blankLocationUpdater.Close();
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (!treeView1.Nodes[0].IsSelected)
            {
                return;
            }
            if (blankLocationUpdater != null)
            {
                MessageBox.Show("Report already running");
                return;
            }
            var form2 = new BlankLocationsUpdaterRunOptions();
            form2.ShowDialog();
            if (form2.DialogResult == DialogResult.OK)
            {
                if (form2.Launch)
                {
                    Size panelSize = splitContainer1.Panel2.Size;
                    blankLocationUpdater = new BlankLocationsUpdater(panelSize, this.label2);
                    blankLocationUpdater.currentVersionLogic.OperationCaller();
                    LoadForm(blankLocationUpdater);
                    var f2 = new BranchSetup_Add.LaunchedScreen(panelSize,
                        blankLocationUpdater.currentVersionLogic.calculatedBlanks.Count,
                        blankLocationUpdater.currentVersionLogic.blanks.Count,this.label2);
                    LoadForm(f2);
                    Console.WriteLine();
                }
                else if (form2.BranchSetup)
                {
                    Size panelSize = splitContainer1.Panel2.Size;
                    blankLocationUpdater = new BlankLocationsUpdater(panelSize, this.label2);
                    LoadForm(blankLocationUpdater);
                    // loading bar here...
                }
                
            }
        }
    }
    
}
