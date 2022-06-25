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
    public partial class LastDigitChanges : Form
    {
        public List<string> lastDigitChanges = new List<string>();
        public LastDigitChanges(List<string> productGroups)
        {
            InitializeComponent();
            AddItemsToclb_lastDigitChanges(productGroups);
            btnOk.Focus();
        }
        private void AddItemsToclb_lastDigitChanges(List<string> productGroups)
        {
            clb_lastDigitChanges.Items.Clear();
            foreach (var location in productGroups)
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
        private void LastDigitChanges_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateLastDigitChanges();
        }
        private void UpdateLastDigitChanges()
        {
            lastDigitChanges.Clear();
            BranchSpecificData.lastDigitChanges.Clear();
            for (int i = 0; i < clb_lastDigitChanges.Items.Count; i++)
            {
                if (clb_lastDigitChanges.GetItemChecked(i))
                {
                    var item = clb_lastDigitChanges.Items[i];
                    lastDigitChanges.Add(item.ToString());
                }
            }
            BranchSpecificData.lastDigitChanges.Sort();
        }
    }
}
