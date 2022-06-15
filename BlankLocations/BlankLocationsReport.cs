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
            G05.PopulateG05();
            GetDistinctLocations();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEliminatedLocations();
            
        }
        private void AddItemsToListBox(List<string> locations)
        {
            foreach (var location in locations)
            {
                checkedListBox1.Items.Add(location);
            }
        }

        private void UpdateEliminatedLocations()
        {
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
        }

        public void GetDistinctLocations()
        {
            List<string> distinctList = G05.locations.Values.Distinct().ToList();
            distinctList.Sort();
            AddItemsToListBox(distinctList);
            Console.WriteLine();
        }
    }
}
