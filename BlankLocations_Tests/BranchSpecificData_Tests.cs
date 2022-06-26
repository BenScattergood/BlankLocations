using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlankLocations;
using System.Security.Cryptography;

namespace BlankLocations_Tests
{
    [TestClass]
    public class BranchSpecificData_Tests
    {
        [TestInitialize]
        public void Init()
        {
            BranchSpecificData.folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)  + $@"\C#\ECP\Tests";
            BranchSpecificData.eliminatedLocations.Add("11B02");
            BranchSpecificData.eliminatedLocations.Add("11C03");
            BranchSpecificData.eliminatedLocations.Add("11F04");
            BranchSpecificData.eliminatedLocations.Add("11F05");
            BranchSpecificData.eliminatedLocations.Add("11F09");
            BranchSpecificData.eliminatedLocations.Add("11F10");
            BranchSpecificData.SaveToFile();

        }

        [TestMethod]
        public void ReadDataFromFile_SecurityCheckFail_Test()
        {
            Assert.ThrowsException<CryptographicException>(() => BranchSpecificData.ReadDataFromFile("SecurityCheck1.txt"));
            Assert.ThrowsException<FileNotFoundException>(() => BranchSpecificData.ReadDataFromFile("SecuityCheck2.txt"));
        }
    }
}
