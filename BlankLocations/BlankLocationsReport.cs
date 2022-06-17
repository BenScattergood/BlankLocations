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
        private void AddItemsTocheckedListBox(List<string> locations)
        {
            clb_locations.Items.Clear();
            foreach (var location in locations)
            {
                clb_locations.Items.Add(location);
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //add error handling
            BranchSpecificData.lastDigitChanges.Add(tbLastDigitChanges.Text);
            BranchSpecificData.lastDigitChanges.Sort();
            UpdateBindingSource();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            UpdaterLogic.OperationCaller();
        }

        private void btnOpenReport_Click(object sender, EventArgs e)
        {
            UpdaterLogic.Init("");
            AddItemsTocheckedListBox(UpdaterLogic.GetDistinctLocations());
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
