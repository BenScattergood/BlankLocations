using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _excel = Microsoft.Office.Interop.Excel;

namespace BlankLocations
{
    public class G05
    {
        public static string path = "";
        public static Application excel = new _excel.Application();
        public static Workbook wb;
        public static Worksheet ws1;
        public static Worksheet ws2;
        public static Worksheet ws3;
        public static string[,] wsRange;
        public static SortedDictionary<string, string> locations = new SortedDictionary<string, string>();
        public static List<Tuple<string, string, string, string>> blanks =
            new List<Tuple<string, string, string, string>>();
        public static List<Tuple<string, string, string, string>> calculatedBlanks =
            new List<Tuple<string, string, string, string>>();

        public static void PopulateG05(string fileName = "_Test")
        {
            path = $@"C:\Users\Ben\Desktop\C#\ECP\Stock_Listed_By_PN" + fileName + ".xlsx";
            excel = new _excel.Application();
            wb = excel.Workbooks.Open(path);
            ws1 = wb.Worksheets[1];
            wsRange = ReadRange();
            ExtractExcelDataIntoLocationsAndBlanks();
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
        private static int LinesInFile(object[,] holder)
        {
            int count = 0;
            for (int i = 1; i <= 30000; i++)
            {
                if (holder[i, 1] == null)
                {
                    return count;
                }
                else
                {
                    count++;
                }
            }
            return count;
        }
        public static string[,] ReadRange()
        {
            Range range = (Range)ws1.Range[ws1.Cells[1, 1], ws1.Cells[30000, 4]];
            object[,] holder = range.Value2;
            int linesInFile = LinesInFile(holder);
            string[,] returnString = new string[linesInFile, 4];
            string strTemp = "";
            for (int r = 1; r <= linesInFile; r++)
            {
                for (int c = 1; c <= 4; c++)
                {
                    var temp = holder[r, c];
                    if (temp == null)
                    {
                        strTemp = "";
                    }
                    else
                    {
                        strTemp = temp.ToString();
                    }
                    returnString[r - 1, c - 1] = strTemp;
                }
            }
            return returnString;
        }
        public static void WriteToExcel(string[,] writeString, bool calculated)
        {
            Range range = null;
            if (calculated)
            {
                range = (Range)ws2.Range[ws2.Cells[1, 1],
                    ws2.Cells[calculatedBlanks.Count + 1, 2]];
            }
            else
            {
                range = (Range)ws3.Range[ws3.Cells[1, 1],
                    ws3.Cells[blanks.Count + 1, 4]];
            }

            range.Value2 = writeString;
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
        public static void CalculateBlankLocationValues()
        {
            CalculateBlankValues();
            Populate_calculatedBlanks_Shrink_Blanks();
            CreateNewSheets();
            WriteToExcel(WriteRange(true), true);
            WriteToExcel(WriteRange(false), false);
            excel.Application.Visible = true;
        }
        public static void CreateNewSheets()
        {
            ws2 = wb.Worksheets.Add(After: ws1);
            ws3 = wb.Worksheets.Add(After: ws2);
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
        public static void Cleanup()
        {
            locations.Clear();
            blanks.Clear();
            calculatedBlanks.Clear();

            excel.DisplayAlerts = false;
            wb.Save();
            wb.Close();
            excel.Quit();
        }
    }
}
