using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BlankLocations
{
    public static class BranchSpecificData
    {
        public static List<string> eliminatedLocations = new List<string>();
        public static List<string> lastDigitChanges = new List<string>();
        public static string folderPath;
        private static string saveData_eliminatedLocations = "eliminatedLocations";
        private static string saveData_lastDigitChanges = "lastDigitChanges";

        public static void SaveToFile()
        {
            List<string> cData = new List<string>();
            cData.Add(saveData_eliminatedLocations);
            foreach (var item in eliminatedLocations)
            {
                cData.Add(item);
            }
            cData.Add(saveData_lastDigitChanges);
            foreach (var item in lastDigitChanges)
            {
                cData.Add(item);
            }

            string[] Data = new string[cData.Count];
            int i = 0;
            foreach (var item in cData)
            {
                Data[i] = item;
                i++;
            }
            File.WriteAllLines(folderPath + $@"\savedData.txt",Data);
        }

        public static void ReadDataFromFile()
        {
            string filePath = folderPath + $@"\savedData.txt";
            eliminatedLocations.Clear();
            lastDigitChanges.Clear();
            if (File.Exists(filePath))
            {
                string[] cData = File.ReadAllLines(filePath);
                bool passedlastDigitMark = false;

                foreach (var line in cData)
                {
                    if (passedlastDigitMark == true)
                    {
                        lastDigitChanges.Add(line);
                    }
                    else if (line == saveData_lastDigitChanges)
                    {
                        passedlastDigitMark = true;
                    }
                    else
                    {
                        if (line != saveData_eliminatedLocations)
                        {
                            eliminatedLocations.Add(line);
                        }
                    }
                    
                }
            }
            
        }
        public static void ClearSavedData()
        {
            string[] Data = new string[0];
            File.WriteAllLines(folderPath + $@"\savedData.txt", Data);
        }
    }

    
}
