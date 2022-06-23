using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace BlankLocations
{
    public static class BranchSpecificData
    {
        public static List<string> eliminatedLocations = new List<string>();
        public static List<string> lastDigitChanges = new List<string>();
        public static string folderPath;
        private static string saveData_eliminatedLocations = "eliminatedLocations";
        private static string saveData_lastDigitChanges = "lastDigitChanges";
        private static string GetFilePath(string fileName) => folderPath + $@"\{fileName}";

        public static void SaveToFile()
        {
            SaveDataToFile();
            byte[] myHash = ReturnSecurityHash();
            File.WriteAllBytes(GetFilePath("SecurityCheck.txt"), myHash);
        }

        private static byte[] ReturnSecurityHash()
        {
            byte[] myFileData = File.ReadAllBytes(GetFilePath("savedData.txt"));
            byte[] myHash = MD5.Create().ComputeHash(myFileData);
            return myHash;
        }

        private static void SaveDataToFile()
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
            File.WriteAllLines(GetFilePath("savedData.txt"), Data);
        }

        public static void ReadDataFromFile()
        {
            eliminatedLocations.Clear();
            lastDigitChanges.Clear();
            try
            {
                if (File.Exists(GetFilePath("savedData.txt")))
                {
                    byte[] newHash = ReturnSecurityHash();
                    if (File.Exists(GetFilePath("SecurityCheck.txt")))
                    {
                        byte[] oldHash = File.ReadAllBytes(GetFilePath("SecurityCheck.txt"));
                        if (!HashesDoMatch(oldHash, newHash))
                        {
                            throw new CryptographicException();
                        }
                    }
                    else
                    {
                        throw new FileNotFoundException();
                    }
                    ExtractDataFromFile();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There appears to be a problem with your branch Data," +
                    " you will need to setup your branch via 'Branch Setup' mode again");
                ClearSavedData();
            }   
        }
        private static bool HashesDoMatch(byte[] oldHash, byte[] newHash)
        {
            for (int i = 0; i < oldHash.Count(); i++)
            {
                if (oldHash[i] != newHash[i])
                {
                    return false;
                }
            }
            return true;
        }
        private static void ExtractDataFromFile()
        {
            string[] cData = File.ReadAllLines(GetFilePath("savedData.txt"));
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
        public static void ClearSavedData()
        {
            string[] Data = new string[0];
            File.WriteAllLines(GetFilePath("savedData.txt"), Data);
            File.WriteAllLines(GetFilePath("SecurityCheck.txt"), Data);
        }
    }

    
}
