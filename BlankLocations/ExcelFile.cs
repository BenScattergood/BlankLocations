using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _excel = Microsoft.Office.Interop.Excel;

namespace BlankLocations
{
    public static class ExcelFile
    {
        public static string G05_path = "";
        public static Application G05 = new _excel.Application();
        public static Application export = new _excel.Application();
        public static Workbook G05_wb;
        public static Workbook export_wb;
        public static Worksheet G05_ws1;
        public static Worksheet export_ws1;
        public static Worksheet export_ws2;


        public static void PopulateG05(string fileName = "_Test")
        {
            G05_path = $@"C:\Users\Ben\Desktop\C#\ECP\Stock_Listed_By_PN" + fileName + ".xlsx";
            G05 = new _excel.Application();
            var workbooks = G05.Workbooks;
            G05_wb = workbooks.Open(G05_path);
            G05_ws1 = G05_wb.Worksheets[1];
        }
        public static string[,] ReadRange()
        {
            Range range = (Range)G05_ws1.Range[G05_ws1.Cells[1, 1], G05_ws1.Cells[30000, 4]];
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
            Marshal.ReleaseComObject(range);
            return returnString;
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
        public static void CreateExportFile()
        {
            export = new _excel.Application();
            export_wb = export.Workbooks.Add();
            export_wb.Worksheets.Add(After: export_wb.Sheets[export_wb.Sheets.Count]);
            export_ws1 = export_wb.Worksheets[1];
            export_ws2 = export_wb.Worksheets[2];
        }
        
        public static void WriteToExcel(string[,] writeString, bool calculated)
        {
            Range range = null;
            if (calculated)
            {
                range = (Range)export_ws1.Range[export_ws1.Cells[1, 1],
                    export_ws1.Cells[UpdaterLogic.calculatedBlanks.Count + 1, 2]];
            }
            else
            {
                range = (Range)export_ws2.Range[export_ws2.Cells[1, 1],
                    export_ws2.Cells[UpdaterLogic.blanks.Count + 1, 4]];
            }

            range.Value2 = writeString;
        }
        public static void Cleanup()
        {
            G05_wb.Close();
            //Marshal.ReleaseComObject(G05_wb);
            //Marshal.ReleaseComObject(G05.Workbooks);
            //Marshal.ReleaseComObject(G05);
            Process[] excelProcs = Process.GetProcessesByName("EXCEL");
            foreach (Process proc in excelProcs)
            {
                if (String.IsNullOrEmpty(proc.MainWindowTitle))
                {
                    proc.Kill();
                    Console.WriteLine();
                }
                
            }
        }
    }
}
