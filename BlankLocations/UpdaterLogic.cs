using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace BlankLocations
{
    public class UpdaterLogic
    {
        public SortedDictionary<string, string> locations = new SortedDictionary<string, string>();
        public List<Tuple<string, string, string, string>> blanks =
            new List<Tuple<string, string, string, string>>();
        public List<Tuple<string, string, string, string>> calculatedBlanks =
            new List<Tuple<string, string, string, string>>();
        public string[,] wsRange;
        private BranchSetup_Add.ProgressBarForm progressBarForm;
        public UpdaterLogic(BranchSetup_Add.ProgressBarForm pbf, bool test = false)
        {
            this.progressBarForm = pbf;
            try
            {
                ExcelFile.PopulateG05(test);
                progressBarForm.IncrementProgressBar(40);
                wsRange = ExcelFile.ReadRange();
                if (!G05DataIsValid())
                {
                    throw new InvalidDataException();
                    //close stuff
                }
                progressBarForm.IncrementProgressBar(10);
                ExtractExcelDataIntoLocationsAndBlanks();
            }
            catch (Exception)
            {
                MessageBox.Show("There appears to be a problem with your excel spreadsheet", "error", MessageBoxButtons.OK);
                throw;
            }
            
        }
        public void OperationCaller()
        {
            progressBarForm.SetProgressBar(80);
            CalculateBlankValues();
            Populate_calculatedBlanks_Shrink_Blanks();
            ExcelFile.CreateExportFile();
            progressBarForm.IncrementProgressBar(10);
            bool useCalculated = true;
            ExcelFile.WriteToExcel(WriteRange(useCalculated), useCalculated, this);
            ExcelFile.WriteToExcel(WriteRange(!useCalculated), !useCalculated, this);
            ExcelFile.export_wb.Application.Visible = true;
            ExcelFile.Cleanup();
        }
        public void ExtractExcelDataIntoLocationsAndBlanks()
        {
            for (int r = 1; r <= wsRange.GetUpperBound(0); r++)
            {
                string PN = wsRange[r, 0];
                string location = wsRange[r, 2];
                if (location != "")
                {
                    locations.Add(PN, location);
                }
                else
                {
                    blanks.Add(Tuple.Create(PN, wsRange[r, 1], location, wsRange[r, 3]));
                }
            }
        }
        private void CalculateBlankValues()
        {
            for (int i = 0; i < blanks.Count; i++)
            {
                var blank = blanks[i];
                if (blank.Item1.Length < 3)
                {
                    continue;
                }
                locations.Add(blank.Item1, blank.Item3);
                string productGroup = blank.Item1.Substring(0, 3);
                KeyValuePair<string, string> before, after;
                if (!ReturnAdjacentPairs(blank, productGroup, out before, out after))
                {
                    continue;
                }
                if (areValidAdjacentPairs(blank, productGroup, before, after, out string location))
                {
                    if (!BranchSpecificData.eliminatedLocations.Contains(location))
                    {
                        var currentItem = blanks.ElementAt(i);
                        var replacement = Tuple.Create(currentItem.Item1, currentItem.Item2,
                            location, currentItem.Item4);
                        blanks.RemoveAt(i);
                        blanks.Insert(i, replacement);
                    }
                }
                locations.Remove(blanks[i].Item1);
            }
        }

        private bool areValidAdjacentPairs(Tuple<string, string, string, string> blank, 
            string productGroup, KeyValuePair<string, string> before,
            KeyValuePair<string, string> after, out string location)
        {
            if (before.Value == after.Value)
            {
                location = before.Value;
                return true;
            }
            else if (before.Key.Substring(0, 3) != productGroup && after.Value == blank.Item3)
            {
                location = after.Value;
                return true;
            }
            else if (after.Key.Substring(0, 3) != productGroup && before.Value == blank.Item3)
            {
                location = before.Value;
                return true;
            }
            else
            {
                location = null;
                return false;
            }
        }

        private bool ReturnAdjacentPairs(Tuple<string, string, string, string> blank, 
            string productGroup, out KeyValuePair<string, string> before, 
            out KeyValuePair<string, string> after)
        {
            var currentPosition = ReturnPositionInDictionary(blank.Item1);
            bool requiresSameLastDigit = BranchSpecificData.
                lastDigitChanges.Contains(productGroup);
            string lastDigit = blank.Item1.Substring(blank.Item1.Length - 1, 1);
            int increment = 0;
            do
            {
                increment--;
                if (currentPosition + increment < 0)
                {
                    before = new KeyValuePair<string, string>("555", "555");
                    after = new KeyValuePair<string, string>("444", "444");
                    return false;
                }
                if (isCorrectValue(currentPosition, increment,
                    requiresSameLastDigit, lastDigit, out before))
                {
                    break;
                }
            } while (increment > -50);

            long locationsCount = locations.Count;
            increment = 0;
            do
            {
                increment++;
                if (increment + currentPosition >= locationsCount)
                {
                    after = new KeyValuePair<string, string>("444", "444");
                    return false;
                }
                if (isCorrectValue(currentPosition, increment,
                    requiresSameLastDigit, lastDigit, out after))
                {
                    break;
                }
            } while (increment < 50);
            return true;
        }

        private bool isCorrectValue(int currentPosition, int increment, 
            bool requiresSameLastDigit, string lastDigit, 
            out KeyValuePair<string, string> pair)
        {
            pair = ReturnPreviousAndNextValues(currentPosition, + increment);
            if (pair.Key == null)
            {
                //return null; I'm up to here...
            }
            if (requiresSameLastDigit)
            {
                bool matchesLastDigit = pair.Key.
                    Substring(pair.Key.Length - 1, 1) == lastDigit;
                if (matchesLastDigit)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private KeyValuePair<string, string>ReturnPreviousAndNextValues
            (int currentPosition, int movePosition)
        {
            var pair = locations.ElementAtOrDefault(currentPosition + movePosition);
            return pair;
        }
        public string[,] WriteRange(bool calculated)
        {
            string[,] writeString;
            int count = 1;
            if (calculated)
            {
                writeString = new string[calculatedBlanks.Count + 1, 2];
                writeString[0, 0] = "Product Code";
                writeString[0, 1] = "Bin Location";

                foreach (var line in calculatedBlanks)
                {
                    writeString[count, 0] = line.Item1;
                    writeString[count, 1] = line.Item3;
                    count++;
                }
            }
            else
            {
                writeString = new string[blanks.Count + 1, 4];
                writeString[0, 0] = "Product Code";
                writeString[0, 1] = "Stock Quantity";
                writeString[0, 2] = "Bin Location";
                writeString[0, 3] = "Stock Full Descrip'n";

                foreach (var line in blanks)
                {
                    writeString[count, 0] = line.Item1;
                    writeString[count, 1] = line.Item2;
                    writeString[count, 2] = line.Item3;
                    writeString[count, 3] = line.Item4;
                    count++;
                }
            }
            return writeString;
        }
        private void Populate_calculatedBlanks_Shrink_Blanks()
        {
            for (int i = 0; i < blanks.Count; i++)
            {
                if (blanks[i].Item3 != "")
                {
                    calculatedBlanks.Add(blanks[i]);
                    blanks.RemoveAt(i);
                    i--;
                }
            }
        }
        private int ReturnPositionInDictionary(string currentBlank)
        {
            int count = 0;
            foreach (var item in locations)
            {
                if (item.Key == currentBlank)
                {
                    return count;
                }
                count++;
            }
            return 0;
        }
        public List<string> GetDistinctLocations()
        {
            List<string> distinctList = this.locations.Values.Distinct().ToList();
            distinctList.Sort();
            return distinctList;
        }

        public List<string> GetDistinctProductGroups()
        {
            List<string> parts = new List<string>();
            string lastAddedPart = null;
            foreach (var part in locations)
            {
                if (part.Key.Length > 3)
                {
                    if (lastAddedPart != part.Key.Substring(0, 3))
                    {
                        if (!parts.Contains(part.Key.Substring(0, 3)))
                        {
                            parts.Add(part.Key.Substring(0, 3));
                            lastAddedPart = part.Key.Substring(0, 3);
                        }
                    }
                }
            }
            return parts;
        }
        private bool G05DataIsValid()
        {
            for (int i = 1; i < wsRange.GetUpperBound(0); i++)
            {
                string c1 = wsRange[i, 0];
                if (c1.Length > 50)
                {
                    return false;
                }
                string c2 = wsRange[i, 1];
                if (!int.TryParse(c2, out int temp))
                {
                    return false;
                }
                string c3 = wsRange[i, 2];
                if (c3.Length > 10)
                {
                    return false;
                }
            }
            return true;
        }
        public void CleanUp()
        {
            locations.Clear();
            blanks.Clear();
            calculatedBlanks.Clear();
            ExcelFile.Cleanup();
        }
    }
}
