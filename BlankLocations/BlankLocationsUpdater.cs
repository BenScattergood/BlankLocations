using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
        private BranchSetup_Add.ProgressBarForm progressBarForm;
        private bool reportOpened = false;

        public BlankLocationsUpdater(Size panelSize, Label lb2,
            ReportsDesktop rd, BranchSetup_Add.ProgressBarForm pgf)
        {
            InitializeComponent();
            this.progressBarForm = pgf;
            progressBarForm.IncrementProgressBar(10);
            panel1.Size = panelSize;
            this.panelSize = panelSize;
            this.lb2 = lb2;
            this.rd = rd;
            //I need the name of this file
            tbBranchSetup.Text = "This report uses a G05 report (Id: BR_UREPG05P.rep)," +
                " you may need to add this to your reports desktop. Export the " +
                "report without filling in the parameters. Save the report to your" +
                " desktop inside a folder named exactly 'Blank Locations'." +
                Environment.NewLine + "Click the 'populate' button below";
            panel3.Hide();
            btnPopulate.Focus();
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
            var filter = new Filter(rd.Size, rd.Location);
            progressBarForm = new BranchSetup_Add.ProgressBarForm();
            filter.Show();
            progressBarForm.SetProgressBar(0);
            progressBarForm.Show();
            progressBarForm.IncrementProgressBar(20);
            try
            {
                currentVersionLogic.OperationCaller();
            }
            catch (Exception)
            {
                progressBarForm.Hide();
                progressBarForm.SetProgressBar(0);
                filter.Close();
                return;
            }
            
            var f2 = new BranchSetup_Add.LaunchedScreen(panelSize,
                currentVersionLogic.calculatedBlanks.Count,
                currentVersionLogic.blanks.Count, this.lb2);
            filter.Close();
            progressBarForm.Close();
            LoadForm(f2);
        }
        public void OpenReport()
        {
            try
            {
                currentVersionLogic = new UpdaterLogic(progressBarForm);
                BranchSpecificData.ReadDataFromFile();
            }
            catch (InvalidDataException)
            {
                MessageBox.Show("Your G05 spreadsheet data appears to be invalid", "Error", MessageBoxButtons.OK);
                currentVersionLogic = null;
                throw new InvalidDataException();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("There appears to be a problem with your saved Data," +
                        " you will need to setup your branch via 'Branch Setup' mode again", "Error", MessageBoxButtons.OK);
                currentVersionLogic = null;
                throw new FileNotFoundException();
            }
            catch (CryptographicException)
            {
                MessageBox.Show("There appears to be a problem with your saved Data," +
                        " you will need to setup your branch via 'Branch Setup' mode again", "Error", MessageBoxButtons.OK);
                currentVersionLogic = null;
                throw new CryptographicException();
            }
            
            progressBarForm.IncrementProgressBar(10);
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

        private void panel1_Resize(object sender, EventArgs e)
        {
            this.panelSize = panel1.Size;
        }

        private void btnPopulate_Click(object sender, EventArgs e)
        {
            if (reportOpened)
            {
                return;
            }
            reportOpened = true;
            Filter filter = new Filter(rd.Size, rd.Location);
            filter.Show();
            progressBarForm.Show();
            try
            {
                OpenReport();
            }
            catch (Exception)
            {
                reportOpened = false;
                filter.Close();
                progressBarForm.Hide();
                progressBarForm.SetProgressBar(0);
                return;
            }
            
            progressBarForm.Close();
            filter.Close();
            panel3.Show();
            PopulateTextBoxes();
            btnPopulate.BackColor = btnAdd_RemovedLocations.BackColor;
            this.AcceptButton = btnLaunch;
            btnLaunch.Focus();
        }

        private void PopulateTextBoxes()
        {
            tbHowTo.Text = "This report calculates bin locations based on the " +
                            " locations of the part numbers preceding and following each blank location." +
                            "  If the bin location of the preceding number matches the" +
                            " location of the following number, it will provide a location. " +
                            " Otherwise, it will remain empty since the part could be placed in either bay." +
                            " It also takes into" +
                            " consideration your data input below, which will be saved to your" +
                            " device." + Environment.NewLine;

            tbRemovedLocations.Text = "Click the add button below to add and remove locations." +
                "Select all locations that contain part numbers that do not flow in part number" +
                " order. For example, shop items or exhausts. This will depend on how your branch " +
                "is setup";

            tbLastDigitChanges.Text = "Click the add button below to add and remove product codes. " +
                " Select all product codes that do run in part number order, however, they are seperated" +
                " by their last digit. For example, parts located in brand order e.g. bays of Valeo wiper blades " +
                "followed by Bosch, followed by Starline. For these items," +
                " the report will only look for the preceding and following part numbers that are a" +
                " member of the same brand (have the same last digit)." + Environment.NewLine;

            tbFinalWords.Text = "Please note that if oil is located by brand, each location will need to be removed, " +
                "because the last digit of each number determines the size, not the brand. Also, if your" +
                " oil is located in part number order, then it will need to be added to the 'last digit changes'" +
                " section, since barrells will be stored in other places." + Environment.NewLine + "Click 'launch'" +
                " below to export the file to Excel. Sheet1 will contain the completed locations, sheet2 will contain" +
                " the remaining blanks that will need to be checked manually";
        }

        private void btnPopulate_TabStopChanged(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.Cyan;
        }

        public void Cleanup()
        {
            if (currentVersionLogic == null)
            {
                return;
            }
            currentVersionLogic.CleanUp();
        }
    }
}
