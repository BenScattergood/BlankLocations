using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankLocations
{
    public static class UpdaterLogic
    {
        public static SortedDictionary<string, string> locations = new SortedDictionary<string, string>();
        public static List<Tuple<string, string, string, string>> blanks =
            new List<Tuple<string, string, string, string>>();
        public static List<Tuple<string, string, string, string>> calculatedBlanks =
            new List<Tuple<string, string, string, string>>();
        public static string[,] wsRange;
        public static void Init(string fileName = "_Test")
        {
            ExcelFile.PopulateG05(fileName);
            wsRange = ExcelFile.ReadRange();
            ExtractExcelDataIntoLocationsAndBlanks();
        }
        public static void OperationCaller()
        {
            CalculateBlankValues();
            Populate_calculatedBlanks_Shrink_Blanks();
            ExcelFile.CreateExportFile();
            bool useCalculated = true;
            ExcelFile.WriteToExcel(WriteRange(useCalculated), useCalculated);
            ExcelFile.WriteToExcel(WriteRange(!useCalculated), !useCalculated);
            ExcelFile.export_wb.Application.Visible = true;
            ExcelFile.Cleanup();
        }
        public static void ExtractExcelDataIntoLocationsAndBlanks()
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
        private static void CalculateBlankValues()
        {
            for (int i = 0; i < blanks.Count; i++)
            {
                var blank = blanks[i];
                locations.Add(blank.Item1, blank.Item3);
                KeyValuePair<string, string> before, after;
                ReturnAdjacentPairs(blank, out before, out after);

                try
                {
                    if (before.Value == after.Value)
                    {
                        var currentItem = blanks.ElementAt(i);
                        var replacement = Tuple.Create(currentItem.Item1, currentItem.Item2,
                            after.Value, currentItem.Item4);
                        blanks.RemoveAt(i);
                        blanks.Insert(i, replacement);
                    }
                }
                catch (Exception e)
                {

                }
                
                locations.Remove(blanks[i].Item1);
            }

        }

        private static void ReturnAdjacentPairs(Tuple<string, string, string, string> blank, out KeyValuePair<string, string> before, out KeyValuePair<string, string> after)
        {
            var currentPosition = ReturnPositionInDictionary(blank.Item1);
            string productGroup = blank.Item1.Substring(0, 3);
            bool requiresSameLastDigit = BranchSpecificData.
                lastDigitChanges.Contains(productGroup);
            string lastDigit = blank.Item1.Substring(blank.Item1.Length - 1, 1);
            int increment = 0;
            do
            {
                increment--;
                if (isCorrectValue(currentPosition, increment,
                    requiresSameLastDigit, lastDigit, out before))
                {
                    break;
                }
            } while (increment > -50);

            increment = 0;
            do
            {
                increment++;
                if (isCorrectValue(currentPosition, increment,
                    requiresSameLastDigit, lastDigit, out after))
                {
                    break;
                }
            } while (increment < 50);
        }

        private static bool isCorrectValue(int currentPosition, int increment, 
            bool requiresSameLastDigit, string lastDigit, 
            out KeyValuePair<string, string> pair)
        {
            pair = ReturnPreviousAndNextValues(currentPosition, + increment);
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

        private static KeyValuePair<string, string>ReturnPreviousAndNextValues
            (int currentPosition, int movePosition)
        {
            var pair = locations.ElementAtOrDefault(currentPosition + movePosition);
            return pair;
        }
        public static string[,] WriteRange(bool calculated)
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
        private static void Populate_calculatedBlanks_Shrink_Blanks()
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
        private static int ReturnPositionInDictionary(string currentBlank)
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
        public static List<string> GetDistinctLocations()
        {
            List<string> distinctList = UpdaterLogic.locations.Values.Distinct().ToList();
            distinctList.Sort();
            return distinctList;
        }
        public static void CleanUp()
        {
            locations.Clear();
            blanks.Clear();
            calculatedBlanks.Clear();
            
        }
    }
}
