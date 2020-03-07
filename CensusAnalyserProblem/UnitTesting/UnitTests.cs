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
            int actual = StateCensusAnalyser.StateLoadData(Path);
            int expected = CSVStateCensus.CVSReadData(Path);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test Case 1.2
        /// </summary>
        [Test]
        public void ThrowExcetions()
        {
            var ex = Assert.Throws<FileNotFoundException>(() => StateCensusAnalyser.StateLoadData("Wrong_File_Path"));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
        }

        /// <summary>
        /// Test Case 1.3
        /// </summary>
        [Test]
        public void ThrowTypeExcetions()
        {
            string Path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCensusData.txt"; 
            var ex = Assert.Throws<FileNotFoundException>(() => StateCensusAnalyser.StateLoadData(Path));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
        }
        
        /// <summary>
        /// Test Case 1.4
        /// </summary>
        [Test]
        public void CheckDelimiter()
        {
            string Path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCensusData.csv";
            var ex = Assert.Throws<CensusAnalyserException>(() => StateCensusAnalyser.CheckDelimiter(Path));
            Assert.That(ex.mgs, Is.EqualTo(CensusException.Wrong_Delimiter.ToString()));
        }

        /// <summary>
        /// Test Case 1.5
        /// </summary>
        [Test]
        public void CheckHeaderOfCSVFile()
        {
            string Path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCensusData.csv";
            var ex = Assert.Throws<CensusAnalyserException>(() => StateCensusAnalyser.CheckDelimiter(Path,"Wrong_Header"));
            Assert.That(ex.mgs, Is.EqualTo(CensusException.Wrong_Delimiter.ToString()));
        }
    }
}