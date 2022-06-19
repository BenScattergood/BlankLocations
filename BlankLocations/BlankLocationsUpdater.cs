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
        public BlankLocationsUpdater(Size panelSize)
        {
            InitializeComponent();
            panel1.Size = panelSize;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEliminatedLocations();
            UpdateBindingSource();
            BranchSpecificData.SaveToFile();
        }
        private void AddItemsToclb_locations(List<string> locations)
        {
            clb_locations.Items.Clear();
            foreach (var location in locations)
            {
                clb_locations.Items.Add(location);
            }
            foreach (string location in BranchSpecificData.eliminatedLocations)
            {
                for (int i = 0; i < clb_locations.Items.Count; i++)
                {
                    if (clb_locations.Items[i].ToString() == location)
                    {
                        clb_locations.SetItemChecked(i, true);
                    }
                }
            }
        }
        private void AddItemsToclb_lastDigitChanges(List<string> locations)
        {
            clb_lastDigitChanges.Items.Clear();
            foreach (var location in locations)
            {
                clb_lastDigitChanges.Items.Add(location);
            }
            foreach (string PN in BranchSpecificData.lastDigitChanges)
            {
                for (int i = 0; i < clb_lastDigitChanges.Items.Count; i++)
                {
                    if (clb_lastDigitChanges.Items[i].ToString() == PN)
                    {
                        clb_lastDigitChanges.SetItemChecked(i, true);
                    }
                }
            }
        }
        private void UpdateEliminatedLocations()
        {
            BranchSpecificData.eliminatedLocations.Clear();
            for (int i = 0; i < clb_locations.Items.Count; i++)
            {
                if (clb_locations.GetItemChecked(i))
                {
                    var item = clb_locations.Items[i];
                    if (!BranchSpecificData.eliminatedLocations.Contains(item.ToString()))
                    {
                        BranchSpecificData.eliminatedLocations.Add(item.ToString());
                    }
                }
            }
            BranchSpecificData.eliminatedLocations.Sort();
        }
        private void UpdateLastDigitChanges()
        {
            BranchSpecificData.lastDigitChanges.Clear();
            for (int i = 0; i < clb_lastDigitChanges.Items.Count; i++)
            {
                if (clb_lastDigitChanges.GetItemChecked(i))
                {
                    var item = clb_lastDigitChanges.Items[i];
                    if (!BranchSpecificData.lastDigitChanges.Contains(item.ToString()))
                    {
                        BranchSpecificData.lastDigitChanges.Add(item.ToString());
                    }
                }
            }
            BranchSpecificData.lastDigitChanges.Sort();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            UpdateLastDigitChanges();
            UpdateBindingSource();
            BranchSpecificData.SaveToFile();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            currentVersionLogic.OperationCaller();
        }
        public void OpenReport()
        {
            currentVersionLogic = new UpdaterLogic("");
            BranchSpecificData.ReadDataFromFile();
            AddItemsToclb_locations(currentVersionLogic.GetDistinctLocations());
            AddItemsToclb_lastDigitChanges(currentVersionLogic.GetDistinctProductGroups());
            
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
    }
}
