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
        public static void CalculateBlankLocationValues()
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
                locations.Add(blanks[i].Item1, blanks[i].Item3);
                int currentPosition = ReturnPositionInDictionary(blanks[i].Item1);
                var previous = locations.ElementAtOrDefault(currentPosition - 1);
                var next = locations.ElementAtOrDefault(currentPosition + 1);
                if (previous.Value == next.Value)
                {
                    var currentItem = blanks.ElementAt(i);
                    var replacement = Tuple.Create(currentItem.Item1, currentItem.Item2,
                        next.Value, currentItem.Item4);
                    blanks.RemoveAt(i);
                    blanks.Insert(i, replacement);
                }
                locations.Remove(blanks[i].Item1);
            }
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
