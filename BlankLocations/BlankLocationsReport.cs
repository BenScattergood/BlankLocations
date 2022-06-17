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
    public partial class BlankLocationsReport : Form
    {
        public BlankLocationsReport(Size panelSize)
        {
            InitializeComponent();
            panel1.Size = panelSize;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEliminatedLocations();
            UpdateBindingSource();
        }
        private void AddItemsToclb_locations(List<string> locations)
        {
            clb_locations.Items.Clear();
            foreach (var location in locations)
            {
                clb_locations.Items.Add(location);
            }
        }
        private void AddItemsToclb_lastDigitChanges(List<string> locations)
        {
            clb_lastDigitChanges.Items.Clear();
            foreach (var location in locations)
            {
                clb_lastDigitChanges.Items.Add(location);
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
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            UpdaterLogic.OperationCaller();
        }

        private void btnOpenReport_Click(object sender, EventArgs e)
        {
            UpdaterLogic.Init("");
            AddItemsToclb_locations(UpdaterLogic.GetDistinctLocations());
            AddItemsToclb_lastDigitChanges(UpdaterLogic.GetDistinctProductGroups());
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
    }
}
