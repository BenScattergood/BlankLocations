using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using BlankLocations;

namespace BlankLocations_Tests
{
    [TestClass]
    public class G05_Tests
    {
        [TestInitialize]
        public void Init()
        {
            G05.PopulateG05();
        }

        [TestMethod]
        public void wsRange_Test()
        {
            string[,] temp = G05.wsRange;
            Assert.AreEqual("11J17", temp[1, 2]);
            Assert.AreNotEqual("11J16", temp[1, 2]);
            Assert.AreEqual("VAN.WB65", temp[16140, 0]);
        }

        [TestMethod]
        public void ExtractExcelDataIntoLocationsAndBlanks_Test()
        {
            Assert.AreEqual(G05.locations["SEAVS7006V206"], "11S01");
            Assert.AreEqual(G05.blanks[3].Item1, "101330518");
        }

        [TestMethod]
        public void CalculateBlankLocationValues_Test()
        {
            G05.CalculateBlankLocationValues();
            Assert.AreEqual("549777551", G05.blanks[7].Item1);
            Assert.AreEqual("11T18", G05.calculatedBlanks[12].Item3);
            Assert.AreEqual("11Q01", G05.calculatedBlanks[34].Item3);
        }
        [TestCleanup]
        public void Cleanup()
        {
            G05.Cleanup();
        }
    }
}
