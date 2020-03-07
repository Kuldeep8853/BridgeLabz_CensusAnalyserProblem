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
        /// Match the records
        /// </summary>
        [Test]
        public void MatchRecords()
        {
            string Path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCensusData.csv";
            int actual = CSVStateCensus.StateLoadData(Path);
            int expected = StateCensusAnalyser.CSVLoadData(Path);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test Case 1.2
        /// Throw the exception if wrong file path pass
        /// </summary>
        [Test]
        public void ThrowExcetions()
        {
            var ex = Assert.Throws<FileNotFoundException>(() => CSVStateCensus.StateLoadData("Wrong_File_Path"));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
        }

        /// <summary>
        /// Test Case 1.3
        /// throw the exception if wrong extention file pass
        /// </summary>
        [Test]
        public void ThrowTypeExcetions()
        {
            string Path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCensusData.txt"; 
            var ex = Assert.Throws<FileNotFoundException>(() => CSVStateCensus.StateLoadData(Path));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
        }
        
        /// <summary>
        /// Test Case 1.4
        /// throw the exception if wrong delimiter pass
        /// </summary>
        [Test]
        public void CheckDelimiter()
        {
            string Path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCensusData.csv";
            var ex = Assert.Throws<CensusAnalyserException>(() => CSVStateCensus.CheckDelimiter(Path));
            Assert.That(ex.mgs, Is.EqualTo(CensusException.Wrong_Delimiter.ToString()));
        }

        /// <summary>
        /// Test Case 1.5
        /// throw the exception if wrong header pass
        /// </summary>
        [Test]
        public void CheckHeaderOfCSVFile()
        {
            string Path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCensusData.csv";
            var ex = Assert.Throws<CensusAnalyserException>(() => CSVStateCensus.CheckDelimiter(Path,"Wrong_Header"));
            Assert.That(ex.mgs, Is.EqualTo(CensusException.Wrong_Header.ToString()));
        }

        /// <summary>
        /// Test Case 2.1
        /// Match the records
        /// </summary>
        [Test]
        public void MatchRecords1()
        {
            string Path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCode.csv";
            int actual = CSVState.StateLoadData(Path);
            int expected = StateCensusAnalyser.CSVLoadData(Path);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test Case 2.2
        /// Throw the exception if wrong file path pass
        /// </summary>
        [Test]
        public void ThrowExcetions1()
        {
            var ex = Assert.Throws<FileNotFoundException>(() => CSVState.StateLoadData("Wrong_File_Path"));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
        }

        /// <summary>
        /// Test Case 2.3
        /// throw the exception if wrong extention file pass
        /// </summary>
        [Test]
        public void ThrowTypeExcetions1()
        {
            string Path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCode.txt";
            var ex = Assert.Throws<FileNotFoundException>(() => CSVState.StateLoadData(Path));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
        }

        /// <summary>
        /// Test Case 2.4
        /// throw the exception if wrong delimiter pass
        /// </summary>
        [Test]
        public void CheckDelimiter1()
        {
            string Path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCode.csv";
            var ex = Assert.Throws<CensusAnalyserException>(() => CSVState.CheckDelimiter(Path));
            Assert.That(ex.mgs, Is.EqualTo(CensusException.Wrong_Delimiter.ToString()));
        }

        /// <summary>
        /// Test Case 2.5
        /// throw the exception if wrong header pass
        /// </summary>
        [Test]
        public void CheckHeaderOfCSVFile1()
        {
            string Path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCode.csv";
            var ex = Assert.Throws<CensusAnalyserException>(() => CSVState.CheckDelimiter(Path, "Wrong_Header"));
            Assert.That(ex.mgs, Is.EqualTo(CensusException.Wrong_Header.ToString()));
        }
    }
}