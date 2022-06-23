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
        public static _excel.Application G05 = null;
        public static _excel.Application export = null;
        public static _excel.Workbooks G05_books = null;
        public static _excel.Workbooks export_books = null;
        public static _excel.Workbook G05_wb = null;
        public static _excel.Workbook export_wb = null;
        public static _excel.Sheets export_sheets = null;
        public static _excel.Worksheet G05_ws1 = null;
        public static _excel.Worksheet export_ws1 = null;
        public static _excel.Worksheet export_ws2 = null;
        public static dynamic cell1 = null;
        public static dynamic cell2 = null;
        public static Range range = null;

        public static bool G05isOpen = false;

        public static void PopulateG05(string fileName = "_Test")
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            BranchSpecificData.folderPath = path + $@"\C#\ECP";
            G05_path = BranchSpecificData.folderPath + $@"\Stock_Listed_By_PN" + fileName + ".xlsx";
            try
            {
                try
                {
                    G05 = new _excel.Application();
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show($"Unable To Access Excel Application \n {e.Message}");
                    throw;
                }

                G05_books = G05.Workbooks;
                try
                {
                    G05_wb = G05_books.Open(G05_path);
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show($"File not found \n {e.Message}");
                    throw;
                }
                try
                {
                    G05_ws1 = G05_wb.Worksheets[1];
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show($"There was a problem with the file \n {e.Message}");
                    throw;
                }
            }
            catch
            {
                CloseG05();
                Cleanup();
            }
        }
        private static void CloseG05()
        {
            G05_wb.Close();
            G05.Quit();
        }
        public static string[,] ReadRange()
        {
            cell1 = G05_ws1.Cells[1, 1];
            cell2 = G05_ws1.Cells[300000, 4];
            range = (Range)G05_ws1.Range[cell1, cell2];
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
            CloseG05();
            Cleanup();
            return returnString;
        }
        private static int LinesInFile(object[,] holder)
        {
            int count = 0;
            for (int i = 1; i <= 300000; i++)
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
            export_books = export.Workbooks;
            export_wb = export_books.Add();
            export_sheets = export_wb.Sheets;
            int count = export_wb.Sheets.Count;
            var temp = export_wb.Sheets[count];
            export_sheets.Add(After: temp);
            export_ws1 = export_wb.Worksheets[1];
            export_ws2 = export_wb.Worksheets[2];
        }

        public static void WriteToExcel(string[,] writeString, bool calculated,
            UpdaterLogic currentVersion)
        {
            if (calculated)
            {
                cell1 = export_ws1.Cells[1, 1];
                int count = currentVersion.calculatedBlanks.Count + 1;
                cell2 = export_ws1.Cells[count,2];
                range = (Range)export_ws1.Range[cell1,cell2];
            }
            else
            {
                cell1 = export_ws2.Cells[1, 1];
                int count = currentVersion.blanks.Count + 1;
                cell2 = export_ws2.Cells[count, 4];
                range = (Range)export_ws2.Range[cell1, cell2];
            }

            range.Value2 = writeString;
        }
        public static void Cleanup()
        {
            if (cell1 != null) Marshal.ReleaseComObject(cell1);
            if (cell2 != null) Marshal.ReleaseComObject(cell2);
            if (range != null) Marshal.ReleaseComObject(range);
            if (G05_ws1 != null) Marshal.ReleaseComObject(G05_ws1);
            if (G05_wb != null) Marshal.ReleaseComObject(G05_wb);
            if (G05_books != null) Marshal.ReleaseComObject(G05_books);
            if (G05 != null) Marshal.ReleaseComObject(G05);
        }
        public static void KillExcel()
        {
            //Process[] excelProcs = Process.GetProcessesByName("EXCEL");
            //foreach (Process proc in excelProcs)
            //{
            //    if (String.IsNullOrEmpty(proc.MainWindowTitle))
            //    {
            //        proc.Kill();
            //        Console.WriteLine();
            //    }
                
            //}
        }
    }
}
