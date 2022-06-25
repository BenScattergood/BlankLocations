using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlankLocations.BranchSetup_Add
{
    public partial class RemoveLocations : Form
    {
        public List<string> removedLocations = new List<string>();
        public RemoveLocations(List<string> locations)
        {
            InitializeComponent();
            AddItemsToclb_locations(locations);
            btnOk.Focus();
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
        private void RemoveLocations_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateEliminatedLocations();
        }
        private void UpdateEliminatedLocations()
        {
            removedLocations.Clear();
            BranchSpecificData.eliminatedLocations.Clear();
            for (int i = 0; i < clb_locations.Items.Count; i++)
            {
                if (clb_locations.GetItemChecked(i))
                {
                    var item = clb_locations.Items[i];
                    removedLocations.Add(item.ToString());
                }
            }
            BranchSpecificData.eliminatedLocations.Sort();
        }
    }
}
