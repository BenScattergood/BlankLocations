using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using BlankLocations;

namespace BlankLocations_Tests
{
    [TestClass]
    public class UpdaterLogic_Tests
    {
        [TestInitialize]
        public void Init()
        {
            UpdaterLogic.Init();
        }

        [TestMethod]
        public void wsRange_Test()
        {
            string[,] temp = UpdaterLogic.wsRange;
            Assert.AreEqual("11J17", temp[1, 2]);
            Assert.AreNotEqual("11J16", temp[1, 2]);
            Assert.AreEqual("VAN.WB65", temp[16140, 0]);
        }

        [TestMethod]
        public void ExtractExcelDataIntoLocationsAndBlanks_Test()
        {
            Assert.AreEqual(UpdaterLogic.locations["SEAVS7006V206"], "11S01");
            Assert.AreEqual(UpdaterLogic.blanks[3].Item1, "101330518");
        }

        [TestMethod]
        public void CalculateBlankLocationValues_Test()
        {
            UpdaterLogic.CalculateBlankLocationValues();
            Assert.AreEqual("549777551", UpdaterLogic.blanks[7].Item1);
            Assert.AreEqual("11T18", UpdaterLogic.calculatedBlanks[12].Item3);
            Assert.AreEqual("11Q01", UpdaterLogic.calculatedBlanks[34].Item3);
            Assert.AreNotEqual("11Q02", UpdaterLogic.calculatedBlanks[34].Item3);
        }
        [TestCleanup]
        public void Cleanup()
        {
            ExcelFile.Cleanup();
            UpdaterLogic.CleanUp();
        }
    }
}
