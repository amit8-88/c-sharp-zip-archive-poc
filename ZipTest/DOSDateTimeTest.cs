using ZipFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ZipTest
{
    
    
    /// <summary>
    ///This is a test class for DOSDateTimeTest and is intended
    ///to contain all DOSDateTimeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DOSDateTimeTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for DOSTime
        ///</summary>
        [TestMethod()]
        public void DOSTimeTest()
        {
            DOSDateTime target = new DOSDateTime(); // TODO: Initialize to an appropriate value
            ushort expected = 0; // TODO: Initialize to an appropriate value
            ushort actual;
            target.DOSTime = expected;
            actual = target.DOSTime;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DOSDate
        ///</summary>
        [TestMethod()]
        public void DOSDateTest()
        {
            DOSDateTime target = new DOSDateTime(); // TODO: Initialize to an appropriate value
            ushort expected = 0; // TODO: Initialize to an appropriate value
            ushort actual;
            target.DOSDate = expected;
            actual = target.DOSDate;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ClassicDateTime
        ///</summary>
        [TestMethod()]
        public void ClassicDateTimeTest()
        {
            DOSDateTime target = new DOSDateTime(); // TODO: Initialize to an appropriate value
            DateTime expected = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime actual;
            target.ClassicDateTime = expected;
            actual = target.ClassicDateTime;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for updateDOSDateTime
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ZipFramework.dll")]
        public void updateDOSDateTimeTest()
        {
            DOSDateTime_Accessor target = new DOSDateTime_Accessor(); // TODO: Initialize to an appropriate value
            target.updateDOSDateTime();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for updateClassicDateTime
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ZipFramework.dll")]
        public void updateClassicDateTimeTest()
        {
            DOSDateTime_Accessor target = new DOSDateTime_Accessor(); // TODO: Initialize to an appropriate value
            target.updateClassicDateTime();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetOutput
        ///</summary>
        [TestMethod()]
        public void GetOutputTest()
        {
            DOSDateTime target = new DOSDateTime(); // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.GetOutput();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetBits
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ZipFramework.dll")]
        public void GetBitsTest()
        {
            DOSDateTime_Accessor target = new DOSDateTime_Accessor(); // TODO: Initialize to an appropriate value
            ushort value = 0; // TODO: Initialize to an appropriate value
            int startBit = 0; // TODO: Initialize to an appropriate value
            int bitCount = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetBits(value, startBit, bitCount);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DOSDateTime Constructor
        ///</summary>
        [TestMethod()]
        public void DOSDateTimeConstructorTest2()
        {
            DOSDateTime target = new DOSDateTime();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DOSDateTime Constructor
        ///</summary>
        [TestMethod()]
        public void DOSDateTimeConstructorTest1()
        {
            DateTime classic = new DateTime(); // TODO: Initialize to an appropriate value
            DOSDateTime target = new DOSDateTime(classic);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DOSDateTime Constructor
        ///</summary>
        [TestMethod()]
        public void DOSDateTimeConstructorTest()
        {
            ushort dosDate = 0; // TODO: Initialize to an appropriate value
            ushort dosTime = 0; // TODO: Initialize to an appropriate value
            DOSDateTime target = new DOSDateTime(dosDate, dosTime);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
