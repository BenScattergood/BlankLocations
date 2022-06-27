using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            this.WindowState = FormWindowState.Maximized;
            Size panelSize = splitContainer1.Panel2.Size;
            LoadForm(new NoReportSelected(panelSize));
            //var size = this.Size.Height - menuStrip1.Size.Height -
            //    toolStrip1.Size.Height - label2.Size.Height;
            //splitContainer1.Size = new Size(splitContainer1.Size.Width, size);
            
        }
        public void LoadForm(object Form)
        {    
            RemoveControls();
            
            var f = (Form)Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(f);
            this.splitContainer1.Panel2.Tag = f;
            f.Show();
        }

        private void RemoveControls()
        {
            for (int i = splitContainer1.Panel2.Controls.Count; i > 0; i--)
            {
                this.splitContainer1.Panel2.Controls.RemoveAt(0);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.splitContainer1.SplitterDistance = 261;
        }
        

        private void tsBtnClose_Click(object sender, EventArgs e)
        {
            var temp = splitContainer1.SplitterDistance;
            if (blankLocationUpdater == null)
            {
                return;
            }
            blankLocationUpdater.Cleanup();
            blankLocationUpdater.Close();
            Size panelSize = splitContainer1.Panel2.Size;
            LoadForm(new NoReportSelected(panelSize));
            blankLocationUpdater = null;
        }

        private void ReportsDesktop_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirm Exit",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) 
            {
                e.Cancel = true;
                return;
            } 
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
            blankLocationUpdater = null;
            var form2 = new BlankLocationsUpdaterRunOptions();
            var filter = new Filter(this.Size, this.Location);
            filter.Show();
            form2.ShowDialog();
            
            if (form2.DialogResult == DialogResult.OK)
            {
                BranchSetup_Add.ProgressBarForm progressBarForm = new BranchSetup_Add.ProgressBarForm();
                if (form2.Launch)
                {
                    filter.Close();
                    progressBarForm.Show();
                    Size panelSize = splitContainer1.Panel2.Size;
                    blankLocationUpdater = new BlankLocationsUpdater(panelSize, this.label2,
                        this, progressBarForm);
                    try
                    {
                        blankLocationUpdater.OpenReport();
                        blankLocationUpdater.currentVersionLogic.OperationCaller();
                    }
                    catch (Exception)
                    {
                        blankLocationUpdater = null;
                        filter.Close();
                        progressBarForm.Close();
                        return;
                    }
                    
                    LoadForm(blankLocationUpdater);
                    progressBarForm.SetProgressBar(100);
                    var f2 = new BranchSetup_Add.LaunchedScreen(panelSize,
                        blankLocationUpdater.currentVersionLogic.calculatedBlanks.Count,
                        blankLocationUpdater.currentVersionLogic.blanks.Count, this.label2);
                    progressBarForm.Close();
                    filter.Close();
                    LoadForm(f2);
                }
                else if (form2.BranchSetup)
                {
                    Size panelSize = splitContainer1.Panel2.Size;
                    blankLocationUpdater = new BlankLocationsUpdater(panelSize, this.label2,
                        this, progressBarForm);
                    filter.Close();
                    LoadForm(blankLocationUpdater);
                }   
            }
            else
            {
                filter.Close();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
