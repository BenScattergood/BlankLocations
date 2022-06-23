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
    public partial class LaunchedScreen : Form
    {
        private int supplied;
        private int required;
        private Label lb2;
        public LaunchedScreen(Size panelSize, int supplied, int required, Label lb2)
        {
            InitializeComponent();
            this.Size = panelSize;
            this.supplied = supplied;
            this.required = required;
            this.lb2 = lb2;
        }

        private void LaunchedScreen_Load(object sender, EventArgs e)
        {
            DataGridViewColumn column = dataGridView1.Columns[0];
            column.Width = 160;
            
            dataGridView1.Rows.Add(
                new object[]
                {
                    "General",
                    ""
                }
                );
            dataGridView1.Rows.Add(
                new object[]
                {
                    "Status",
                    "Completed"
                }
                );
            dataGridView1.Rows.Add(
                new object[]
                {
                    "Output",
                    "Export"
                }
                );
            dataGridView1.Rows.Add(
                new object[]
                {
                    "",
                    ""
                }
                );
            dataGridView1.Rows.Add(
                new object[]
                {
                    "Table Access",
                    ""
                }
                );
            dataGridView1.Rows.Add(
                new object[]
                {
                    "Locations Supplied",
                    supplied
                }
                );
            dataGridView1.Rows.Add(
                new object[]
                {
                    "Locations Required",
                    required
                }
                );
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                row.Height = 20;
            }
            dataGridView1.Rows[0].DefaultCellStyle.Font = new Font(
                "Microsoft Sans Serif",8, FontStyle.Bold);
            dataGridView1.Rows[4].DefaultCellStyle.Font = new Font(
                "Microsoft Sans Serif", 8, FontStyle.Bold);
            lb2.Text = $@"Report completed, locations supplied {supplied} - required {required}";
        }
    }
}
