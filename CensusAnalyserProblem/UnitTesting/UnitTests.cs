using NUnit.Framework;
using CensusAnalyserProblem;
using System.IO;

namespace UnitTesting
{
    [TestFixture]
    public class UnitTests
    {
        /// <summary>
        /// Test Case 1.1
        /// </summary>
        [Test]
        public void MatchRecords()
        {
            string Path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCensusData.csv";
            int expected = StateCensusAnalyser.StateLoadData(Path);
            int actual = CSVStateCensus.CVSReadData(Path);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test Case 1.2
        /// </summary>
        [Test]
        public void ThrowExcetions()
        {
            string Path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCensusDat.csv"; 
            var ex = Assert.Throws<FileNotFoundException>(() => StateCensusAnalyser.StateLoadData(Path));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
        }

        /// <summary>
        /// Test Case 1.3
        /// </summary>
        [Test]
        public void ThrowTypeExcetions()
        {
            string Path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCensusDat.txt"; 
            var ex = Assert.Throws<FileNotFoundException>(() => StateCensusAnalyser.StateLoadData(Path));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
        }
    }
}