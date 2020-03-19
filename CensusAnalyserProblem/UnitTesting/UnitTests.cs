// --------------------------------------------------------------------------------------------------------------------
// <copyright file=UnitTests.cs" Company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Kuldeep Kasaudhan"/>
// ----------------------------------------------------------------------------------------------------------------------
namespace UnitTesting
{
    using System.IO;
    using CensusAnalyserProblem;
    using NUnit.Framework;

    /// <summary>
    /// Unit Testing of CensusAnalyserProblem project.
    /// </summary>
    [TestFixture]
    public class UnitTests
    {
        /// <summary>
        /// Test Case 1.1
        /// Match the records.
        /// </summary>
        [Test]
        public void Check_NumberOf_Records_Given_Matched()
        {
            string path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCensusData.csv";
            Factory factory = new Factory();
            DelegateCsvStateDataLoad deleget = new DelegateCsvStateDataLoad(Builder.Construct);
            int expected = StateCensusAnalyser.CSVLoadData(path);
            Assert.AreEqual(expected.ToString(), deleget(factory.GetObjectCSVStateCensus(), path));
        }

        /// <summary>
        /// Test Case 1.2
        /// Throw the exception if wrong file path pass.
        /// </summary>
        [Test]
        public void Pass_Wrong_FileName_Throw_Wrong_File_Path()
        {
            Factory factory = new Factory();
            DelegateCsvStateDataLoad deleget = new DelegateCsvStateDataLoad(Builder.Construct);
            var ex = Assert.Throws<FileNotFoundException>(() => deleget(factory.GetObjectCSVStateCensus(), "Wrong_File_Path"));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
        }

        /// <summary>
        /// Test Case 1.3
        /// throw the exception if wrong extension file pass.
        /// </summary>
        [Test]
        public void Pass_Wrong_FileType_Throw_Wrong_File_Path()
        {
            string path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCensusData.txt";
            Factory factory = new Factory();
            DelegateCsvStateDataLoad deleget = new DelegateCsvStateDataLoad(Builder.Construct);
            var ex = Assert.Throws<FileNotFoundException>(() => deleget(factory.GetObjectCSVStateCensus(), path));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
        }

        /// <summary>
        /// Test Case 1.4
        /// throw the exception if wrong delimiter pass.
        /// </summary>
        [Test]
        public void Pass_Wrong_Delimiter_ThrowExceptionWrong_Delimiter()
        {
            string path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCensusData.csv";
            Factory factory = new Factory();
            DelegateCsvStateDataLoad deleget = new DelegateCsvStateDataLoad(Builder.Construct);
            var ex = Assert.Throws<CensusAnalyserException>(() => deleget(factory.GetObjectCSVStateCensus(), path, ";"));
            Assert.That(ex.Mgs, Is.EqualTo(CensusException.Wrong_Delimiter.ToString()));
        }

        /// <summary>
        /// Test Case 1.5
        /// throw the exception if wrong header pass.
        /// </summary>
        [Test]
        public void Pass_Wrong_Header_File_ThrowException()
        {
            string path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCensusData.csv";
            Factory factory = new Factory();
            DelegateCsvStateDataLoad deleget = new DelegateCsvStateDataLoad(Builder.Construct);
            var ex = Assert.Throws<CensusAnalyserException>(() => deleget(factory.GetObjectCSVStateCensus(), path, ",", "Wrong_Header"));
            Assert.That(ex.Mgs, Is.EqualTo(CensusException.Wrong_Header.ToString()));
        }

        /// <summary>
        /// Test Case 2.1
        /// Match the records.
        /// </summary>
        [Test]
        public void Check_NumberOf_Records_Given_Matched1()
        {
            string path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCode.csv";
            Factory factory = new Factory();
            DelegateCsvStateDataLoad deleget = new DelegateCsvStateDataLoad(Builder.Construct);
            string actual = deleget(factory.GetObjectCSVStateCensus(), path);
            int expected = StateCensusAnalyser.CSVLoadData(path);
            Assert.AreEqual(expected.ToString(), actual);
        }

        /// <summary>
        /// Test Case 2.2
        /// Throw the exception if wrong file path pass.
        /// </summary>
        [Test]
        public void Pass_Wrong_FileName_Throw_Wrong_File_Path1()
        {
            Factory factory = new Factory();
            DelegateCsvStateDataLoad deleget = new DelegateCsvStateDataLoad(Builder.Construct);
            var ex = Assert.Throws<FileNotFoundException>(() => deleget(factory.GetObjectCSVStateCensus(), "Wrong_File_Path"));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
        }

        /// <summary>
        /// Test Case 2.3
        /// Throw the exception if wrong extension file pass.
        /// </summary>
        [Test]
        public void Pass_Wrong_FileType_Throw_Wrong_File_Path1()
        {
            string path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCode.txt";
            Factory factory = new Factory();
            DelegateCsvStateDataLoad deleget = new DelegateCsvStateDataLoad(Builder.Construct);
            var ex = Assert.Throws<FileNotFoundException>(() => deleget(factory.GetObjectCSVStateCensus(), path));
            Assert.That(ex.Message, Is.EqualTo(CensusException.Wrong_File_Path.ToString()));
        }

        /// <summary>
        /// Test Case 2.4
        /// throw the exception if wrong delimiter pass.
        /// </summary>
        [Test]
        public void Pass_Wrong_Delimiter_ThrowExceptionWrong_Delimiter1()
        {
            string path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCode.csv";
            Factory factory = new Factory();
            DelegateCsvStateDataLoad deleget = new DelegateCsvStateDataLoad(Builder.Construct);
            var ex = Assert.Throws<CensusAnalyserException>(() => deleget(factory.GetObjectCSVStateCensus(), path, ";"));
            Assert.That(ex.Mgs, Is.EqualTo(CensusException.Wrong_Delimiter.ToString()));
        }

        /// <summary>
        /// Test Case 2.5
        /// throw the exception if wrong header pass.
        /// </summary>

        [Test]
        public void Pass_Wrong_Header_File_ThrowException1()
        {
            string path = @"D:\BridgeLabz_CensusAnalyserProblem\StateCode.csv";
            Factory factory = new Factory();
            DelegateCsvStateDataLoad deleget = new DelegateCsvStateDataLoad(Builder.Construct);
            var ex = Assert.Throws<CensusAnalyserException>(() => deleget(factory.GetObjectCSVStateCensus(), path, ";", "Wrong_Header"));
            Assert.That(ex.Mgs, Is.EqualTo(CensusException.Wrong_Header.ToString()));
        }

        /// <summary>
        /// Test Case 3.1
        /// </summary>
        [Test]
        public void Comparing_FistStateCensus_Name()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            CSVStateCensus cSVStateCensus = new CSVStateCensus(stateCensusAnalyser);
            string jsonFilePath = @"D:\BridgeLabz_CensusAnalyserProblem\CensusAnalyserProblem\CensusAnalyserProblem\CSVStateCensus.json";
            string actual = cSVStateCensus.FirstElementNameOfJsonArray(jsonFilePath, "State");
            string expected = "Rajasthan";
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Test case 3.2
        /// </summary>
        [Test]
        public void Comparing_LastStateCensus_Name()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            CSVStateCensus cSVStateCensus = new CSVStateCensus(stateCensusAnalyser);
            string jsonFilePath = @"D:\BridgeLabz_CensusAnalyserProblem\CensusAnalyserProblem\CensusAnalyserProblem\CSVStateCensus.json";
            string actual = cSVStateCensus.LastElementNameOfJsonArray(jsonFilePath, "State");
            string expected = "Arunachal Pradesh";
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Test Case 4.1
        /// </summary>
        [Test]
        public void Comparing_FistStateCode_Name()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            CSVStateCensus cSVStateCensus = new CSVStateCensus(stateCensusAnalyser);
            string jsonFilePath = @"D:\BridgeLabz_CensusAnalyserProblem\CensusAnalyserProblem\CensusAnalyserProblem\CSVState.json";
            string actual = cSVStateCensus.FirstElementNameOfJsonArray(jsonFilePath, "StateName");
            string expected = "Andaman and Nicobar Islands";
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Test case 4.2
        /// </summary>
        [Test]
        public void Comparing_LastStateCode_Name()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            CSVStateCensus cSVStateCensus = new CSVStateCensus(stateCensusAnalyser);
            string jsonFilePath = @"D:\BridgeLabz_CensusAnalyserProblem\CensusAnalyserProblem\CensusAnalyserProblem\CSVState.json";
            string actual = cSVStateCensus.LastElementNameOfJsonArray(jsonFilePath, "StateName");
            string expected = "West Bengal";
            Assert.AreEqual(actual, expected);
        }
    }
}