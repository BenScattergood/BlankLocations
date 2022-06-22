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

        public BlankLocationsUpdater(Size panelSize, Label lb2)
        {
            InitializeComponent();
            panel1.Size = panelSize;
            this.panelSize = panelSize;
            this.lb2 = lb2;
            OpenReport();
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
        private void btnAdd_LastDigitChanges_Click(object sender, EventArgs e)
        {
            var form2 = new BranchSetup_Add.LastDigitChanges(currentVersionLogic.GetDistinctProductGroups());
            form2.ShowDialog();
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
            form2.ShowDialog();
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
