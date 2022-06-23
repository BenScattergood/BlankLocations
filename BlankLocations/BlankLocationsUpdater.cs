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
    public partial class BlankLocationsUpdater : Form
    {
        public UpdaterLogic currentVersionLogic;
        private Size panelSize;
        private Label lb2;
        private ReportsDesktop rd;

        public BlankLocationsUpdater(Size panelSize, Label lb2,
            ReportsDesktop rd)
        {
            InitializeComponent();
            panel1.Size = panelSize;
            this.panelSize = panelSize;
            this.lb2 = lb2;
            this.rd = rd;
            OpenReport();
        }
        public void LoadForm(object Form)
        {
            RemoveControls();
            Form f = (Form)Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.Controls.Add(f);
            this.Tag = f;
            f.Show();
        }

        public void RemoveControls()
        {
            for (int i = this.Controls.Count; i > 0; i--)
            {
                this.Controls.RemoveAt(0);
            }
        }

        private void btnAdd_LastDigitChanges_Click(object sender, EventArgs e)
        {
            var form2 = new BranchSetup_Add.LastDigitChanges(currentVersionLogic.GetDistinctProductGroups());
            var filter = new Filter(rd.Size, rd.Location);
            filter.Show();
            form2.ShowDialog();
            filter.Close();
            if (form2.DialogResult == DialogResult.OK)
            {
                BranchSpecificData.lastDigitChanges.Clear();
                foreach (var item in form2.lastDigitChanges)
                {
                    BranchSpecificData.lastDigitChanges.Add(item);
                }
                UpdateBindingSource();
                BranchSpecificData.SaveToFile();
            }
        }
        private void btnAdd_RemovedLocations_Click(object sender, EventArgs e)
        {
            var form2 = new BranchSetup_Add.RemoveLocations(currentVersionLogic.GetDistinctLocations());
            var filter = new Filter(rd.Size, rd.Location);
            filter.Show();
            form2.ShowDialog();
            filter.Close();
            if (form2.DialogResult == DialogResult.OK)
            {
                BranchSpecificData.eliminatedLocations.Clear();
                foreach (var item in form2.removedLocations)
                {
                    BranchSpecificData.eliminatedLocations.Add(item);
                }
                UpdateBindingSource();
                BranchSpecificData.SaveToFile();
            }
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            currentVersionLogic.OperationCaller();
            var f2 = new BranchSetup_Add.LaunchedScreen(panelSize,
                currentVersionLogic.calculatedBlanks.Count,
                currentVersionLogic.blanks.Count, this.lb2);
            LoadForm(f2);
        }
        public void OpenReport()
        {
            currentVersionLogic = new UpdaterLogic("");
            BranchSpecificData.ReadDataFromFile();
            UpdateBindingSource();
        }
        public void UpdateBindingSource()
        {
            bs_eliminatedLocations.DataSource = BranchSpecificData.eliminatedLocations;
            lb_eliminatedLocations.DataSource = bs_eliminatedLocations;
            bs_eliminatedLocations.ResetBindings(false);

            bs_lastDigitChanges.DataSource = BranchSpecificData.lastDigitChanges;
            lb_lastDigitChanges.DataSource = bs_lastDigitChanges;
            bs_lastDigitChanges.ResetBindings(false);
        }
        private void BlankLocationsUpdater_FormClosing(object sender, FormClosingEventArgs e)
        {
            currentVersionLogic.CleanUp();
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            this.panelSize = panel1.Size;
        }
    }
}
