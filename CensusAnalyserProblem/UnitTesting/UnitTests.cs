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
            DCsvStateDataLoad1 del = new DCsvStateDataLoad1(CSVStateCensus.StateLoadData);
            int actual = del(Path);
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
            DCsvStateDataLoad1 del = new DCsvStateDataLoad1(CSVStateCensus.StateLoadData);
            var ex = Assert.Throws<FileNotFoundException>(() => del("Wrong_File_Path"));
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
            DCsvStateDataLoad1 del = new DCsvStateDataLoad1(CSVStateCensus.StateLoadData);
            var ex = Assert.Throws<FileNotFoundException>(() => del(Path));
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
            DCheckCSVDelimiterAndHeader1 del1 = new DCheckCSVDelimiterAndHeader1(CSVStateCensus.CheckDelimiter);
            var ex = Assert.Throws<CensusAnalyserException>(() => del1(Path));
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
            DCheckCSVDelimiterAndHeader1 del1 = new DCheckCSVDelimiterAndHeader1(CSVStateCensus.CheckDelimiter);
            var ex = Assert.Throws<CensusAnalyserException>(() => del1(Path,"Wrong_Header"));
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
            DCsvStateDataLoad del = new DCsvStateDataLoad(CSVState.StateLoadData);
            int actual = del(Path);
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
            DCsvStateDataLoad del = new DCsvStateDataLoad(CSVState.StateLoadData);
            var ex = Assert.Throws<FileNotFoundException>(() => del("Wrong_File_Path"));
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
            DCsvStateDataLoad del = new DCsvStateDataLoad(CSVState.StateLoadData);
            var ex = Assert.Throws<FileNotFoundException>(() => del(Path));
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
            DCheckCSVDelimiterAndHeader del1 = new DCheckCSVDelimiterAndHeader(CSVState.CheckDelimiterAndHeader);
            var ex = Assert.Throws<CensusAnalyserException>(() => del1(Path));
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
            DCheckCSVDelimiterAndHeader del1 = new DCheckCSVDelimiterAndHeader(CSVState.CheckDelimiterAndHeader);
            var ex = Assert.Throws<CensusAnalyserException>(() => del1(Path, "Wrong_Header"));
            Assert.That(ex.mgs, Is.EqualTo(CensusException.Wrong_Header.ToString()));
        }
    }
}