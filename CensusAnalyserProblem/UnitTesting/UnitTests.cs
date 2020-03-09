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
        public void Check_NumberOf_Records_Given_Matched()
        {
            string Path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCensusData.csv";
            Builder builder = new Builder();
            Factory factory = new Factory();
            int actual=builder.Construct1(factory.GetObjectCSVStateCensus(), Path, ",", "AreaInSqKm");
            int expected = StateCensusAnalyser.CSVLoadData(Path);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test Case 1.2
        /// Throw the exception if wrong file path pass
        /// </summary>
        [Test]
        public void Pass_Wrong_FileName_Throw_Wrong_File_Path()
        {
            Builder builder = new Builder();
            Factory factory = new Factory();
            var ex = Assert.Throws<FileNotFoundException>(() => builder.Construct1(factory.GetObjectCSVStateCensus(), "Wrong_File_Path", ",", "AreaInSqKm"));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
        }

        /// <summary>
        /// Test Case 1.3
        /// throw the exception if wrong extention file pass
        /// </summary>
        [Test]
        public void Pass_Wrong_FileType_Throw_Wrong_File_Path()
        {
            string Path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCensusData.txt";
            Builder builder = new Builder();
            Factory factory = new Factory();
            var ex = Assert.Throws<FileNotFoundException>(() => builder.Construct1(factory.GetObjectCSVStateCensus(), Path, ",", "AreaInSqKm"));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
        }

        /// <summary>
        /// Test Case 1.4
        /// throw the exception if wrong delimiter pass
        /// </summary>
        [Test]
        public void Pass_Wrong_Delimiter_ThrowExceptionWrong_Delimiter()
        {
            string Path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCensusData.csv";
            Builder builder = new Builder();
            Factory factory = new Factory();
            var ex = Assert.Throws<FileNotFoundException>(() => builder.Construct1(factory.GetObjectCSVStateCensus(), Path, ";", "AreaInSqKm"));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_Delimiter.ToString()));
        }

        /// <summary>
        /// Test Case 1.5
        /// throw the exception if wrong header pass
        /// </summary>
        [Test]
        public void Pass_Wrong_Header_File_ThrowException()
        {
            string Path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCensusData.csv";
            Builder builder = new Builder();
            Factory factory = new Factory();
            var ex = Assert.Throws<FileNotFoundException>(() => builder.Construct1(factory.GetObjectCSVStateCensus(), Path, ";", "Wrong_Header"));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_Header.ToString()));
        }

        /// <summary>
        /// Test Case 2.1
        /// Match the records
        /// </summary>
        [Test]
        public void Check_NumberOf_Records_Given_Matched1()
        {
            string Path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCode.csv";
            Builder builder = new Builder();
            Factory factory = new Factory();
            int actual = builder.Construct1(factory.GetObjectCSVState(), Path, ",", "StateCode");
            int expected = StateCensusAnalyser.CSVLoadData(Path);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test Case 2.2
        /// Throw the exception if wrong file path pass
        /// </summary>
        [Test]
        public void Pass_Wrong_FileName_Throw_Wrong_File_Path1()
        {
            Builder builder = new Builder();
            Factory factory = new Factory();
            var ex = Assert.Throws<FileNotFoundException>(() => builder.Construct1(factory.GetObjectCSVState(), "Wrong_File_Path", ",", "StateCode"));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
        }

        /// <summary>
        /// Test Case 2.3
        /// throw the exception if wrong extention file pass
        /// </summary>
        [Test]
        public void Pass_Wrong_FileType_Throw_Wrong_File_Path1()
        {
            string Path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCode.txt";
            Builder builder = new Builder();
            Factory factory = new Factory();
            var ex = Assert.Throws<FileNotFoundException>(() => builder.Construct1(factory.GetObjectCSVState(), Path, ",", "AreaInSqKm"));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
        }

        /// <summary>
        /// Test Case 2.4
        /// throw the exception if wrong delimiter pass
        /// </summary>
        [Test]
        public void Pass_Wrong_Delimiter_ThrowExceptionWrong_Delimiter1()
        {
            string Path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCode.csv";
            Builder builder = new Builder();
            Factory factory = new Factory();
            var ex = Assert.Throws<FileNotFoundException>(() => builder.Construct1(factory.GetObjectCSVState(), Path, ";", "AreaInSqKm"));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_Delimiter.ToString()));
        }

        /// <summary>
        /// Test Case 2.5
        /// throw the exception if wrong header pass
        /// </summary>
        [Test]
        public void Pass_Wrong_Header_File_ThrowException1()
        {
            string Path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCode.csv";
            Builder builder = new Builder();
            Factory factory = new Factory();
            var ex = Assert.Throws<FileNotFoundException>(() => builder.Construct1(factory.GetObjectCSVState(), Path, ";", "Wrong_Header"));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_Header.ToString()));
        }
    }
}