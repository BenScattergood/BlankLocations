using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using BlankLocations;

namespace BlankLocations_Tests
{
    [TestClass]
    public class UpdaterLogic_Tests
    {
        UpdaterLogic current;
        [TestInitialize]
        public void Init()
        {
            var pbf = new BlankLocations.BranchSetup_Add.ProgressBarForm();
            current = new UpdaterLogic(pbf, true);
            BranchSpecificData.ClearSavedData();
        }

        [TestMethod]
        public void wsRange_Test()
        {
            string[,] temp = current.wsRange;
            Assert.AreEqual("11J17", temp[1, 2]);
            Assert.AreNotEqual("11J16", temp[1, 2]);
            Assert.AreEqual("VAN.WB65", temp[16140, 0]);
        }

        [TestMethod]
        public void ExtractExcelDataIntoLocationsAndBlanks_Test()
        {
            Assert.AreEqual(current.locations["SEAVS7006V206"], "11S01");
            Assert.AreEqual(current.blanks[3].Item1, "101330518");
        }

        [TestMethod]
        public void CalculateBlankLocationValues_Test()
        {
            BranchSpecificData.lastDigitChanges.Add("627");
            BranchSpecificData.lastDigitChanges.Add("504");
            BranchSpecificData.eliminatedLocations.Add("11G10");
            current.OperationCaller();
            Assert.AreEqual("101110428", current.blanks[0].Item1);
            Assert.AreEqual("627880031", current.blanks[14].Item1);
            Assert.AreEqual("549777551", current.blanks[10].Item1);
            Assert.AreEqual("11T18", current.calculatedBlanks[10].Item3);
            Assert.AreEqual("11Q01", current.calculatedBlanks[31].Item3);
            Assert.AreNotEqual("11Q02", current.calculatedBlanks[31].Item3);
        }

        [TestCleanup]
        public void Cleanup()
        {
            current.CleanUp();
        }
    }
}
