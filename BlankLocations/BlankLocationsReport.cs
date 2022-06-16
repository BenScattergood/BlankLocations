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
            AddItemsToListBox();
        }
        private void AddItemsToListBox()
        {
            listBox1.Items.Clear();
            foreach (var location in BranchSpecificData.eliminatedLocations)
            {
                listBox1.Items.Add(location);
            }
        }
        private void AddItemsTocheckedListBox(List<string> locations)
        {
            checkedListBox1.Items.Clear();
            foreach (var location in locations)
            {
                checkedListBox1.Items.Add(location);
            }
        }
        private void UpdateEliminatedLocations()
        {
            BranchSpecificData.eliminatedLocations.Clear();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    var item = checkedListBox1.Items[i];
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
            lbLastDigitChanges.Items.Add(tbLastDigitChanges.Text);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            
            UpdaterLogic.CalculateBlankLocationValues();
        }

        private void btnOpenReport_Click(object sender, EventArgs e)
        {
            UpdaterLogic.Init("");
            AddItemsTocheckedListBox(UpdaterLogic.GetDistinctLocations());
        }
    }
}
