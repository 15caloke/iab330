using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StoragePalTests
{
    /// <summary>
    /// Summary description for StoragePalUnitTests
    /// </summary>
    [TestClass]
    public class StoragePalUnitTests
    {
        public StoragePalUnitTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        ///<summary>
        ///Tests to assert that email is valid upon user creation
        ///</summary>
        public void TestValidEmail()
        {
            string testEmail = "test@example.com";
            bool isValid = StoragePal1.Validation.Validation.ValidEmail(testEmail);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        ///<summary>
        ///Tests to assert that email is valid upon user creation
        ///</summary>
        public void TestValidUsername()
        {
            string testUsername = "username";
            bool isValid = StoragePal1.Validation.Validation.ValidUsername(testUsername);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        ///<summary>
        ///Tests to assert that username with numbers is allowed
        /// </summary>
        public void TestUsernameWithDigits()
        {
            string testUsername = "test123";
            bool isValid = StoragePal1.Validation.Validation.ValidUsername(testUsername);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        ///<summary>
        ///Tests to assert that username with digits before letters is allowed
        /// </summary>
        public void TestUsernameDigitsAndLetters()
        {
            string testUsername = "123user";
            bool isValid = StoragePal1.Validation.Validation.ValidUsername(testUsername);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        ///<summary>
        ///Tests to assert that username with mix of letters and digits allowed
        /// </summary>
        public void TestUsernameMixed()
        {
            string testUsername = "us3rn4m3";
            bool isValid = StoragePal1.Validation.Validation.ValidUsername(testUsername);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        ///<summary>
        ///Tests to assert that username with only digits is allowed
        /// </summary>
        public void TestUsernameWithNoLetters()
        {
            string testUsername = "12345678"; 
            bool isValid = StoragePal1.Validation.Validation.ValidUsername(testUsername);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        ///<summary>
        ///Tests to assert that password with caps, letters and numbersis valid upon user creation
        /// </summary>
        public void TestValidPassword()
        {
            string testPassword = "Password123";
            bool isValid = StoragePal1.Validation.Validation.ValidPassword(testPassword);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        ///<summary>
        ///Tests to assert that password with special chars is allowed
        /// </summary>
        public void TestPasswordSpecialChars()
        {
            string testPassword = "P4$$woRd!()";
            bool isValid = StoragePal1.Validation.Validation.ValidPassword(testPassword);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        ///<summary>
        ///Tests to assert that username less than 6 characters is not allowed
        /// </summary>
        public void TestShortUsername()
        {
            string testUsername = "short"; // 5 characters
            bool isValid = StoragePal1.Validation.Validation.ValidUsername(testUsername);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        ///<summary>
        ///Tests to assert that username more than 20 characters is not allowed
        /// </summary>
        public void TestLongUsername()
        {
            string testUsername = "thisusernameistoolong"; // 21 characters
            bool isValid = StoragePal1.Validation.Validation.ValidUsername(testUsername);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        ///<summary>
        ///Tests to assert that username with special characters not allowed
        /// </summary>
        public void TestUsernameWithSpecialChars()
        {
            string testUsername = "user_name";
            bool isValid = StoragePal1.Validation.Validation.ValidUsername(testUsername);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        ///<summary>
        ///Tests to assert that invalid email is not allowed with no @ symbol
        /// </summary>
        public void TestInvalidEmail()
        {
            string testEmail = "invalidatexample.com"; // no @ symbol
            bool isValid = StoragePal1.Validation.Validation.ValidEmail(testEmail);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        ///<summary>
        ///Tests to assert that invalid email is not allowed with no .com
        /// </summary>
        public void TestInvalidEmailNoDotCom()
        {
            string testEmail = "invalid@example";
            bool isValid = StoragePal1.Validation.Validation.ValidEmail(testEmail);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        ///<summary>
        ///Tests to assert that invalid email with special characters
        /// </summary>
        public void TestInvalidEmailWithSpecialChars()
        {
            string testEmail = "inval!d@example.com";
            bool isValid = StoragePal1.Validation.Validation.ValidEmail(testEmail);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        ///<summary>
        ///Tests to assert that password does not meet criteria (too short)
        /// </summary>
        public void TestShortPassword()
        {
            string testPassword = "Sh0rt";
            bool isValid = StoragePal1.Validation.Validation.ValidPassword(testPassword);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        ///<summary>
        ///Tests to assert that password does not meet criteria (no numbers)
        /// </summary>
        public void TestPasswordNoDigits()
        {
            string testPassword = "Nonumbers";
            bool isValid = StoragePal1.Validation.Validation.ValidPassword(testPassword);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        ///<summary>
        ///Tests to assert that password does not meet criteria (only numbers)
        /// </summary>
        public void TestOnlyDigitsPassword()
        {
            string testPassword = "12345678";
            bool isValid = StoragePal1.Validation.Validation.ValidPassword(testPassword);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        ///<summary>
        ///Tests to assert that password does not meet criteria (no capital letters)
        /// </summary>
        public void TestPasswordNoCaps()
        {
            string testPassword = "password123";
            bool isValid = StoragePal1.Validation.Validation.ValidPassword(testPassword);
            Assert.IsFalse(isValid);
        }
    }
}
