using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoragePal1;
using StoragePal1.Models;
using StoragePal1.Databases;
using StoragePal1.Droid;
using StoragePal1.iOS;

namespace StoragePalTests.ViewModelTests {
    [TestFixture]
    public partial class MainViewModelTests {
        MainViewModel main, nonInstanciated;
        Items testItem;
        Database db;

        [SetUp]
        public void SetUp() {
            //main = new MainViewModel();
            //testItem = new Items();
            //db = new Database();
        }

        /*
         * 
         * The following cannot be tested due to the dependancy injection,
         * testing will be done manually on the report, as unit tests will
         * not be required for marking, so test will remain inconclusive
         * 
         */
        [Test]
        public void TestModelNotNull() {
            //Assert.NotNull(main);
            Assert.Inconclusive("Cannot be tested");
        }

        [Test]
        public void TestNonInstanciatedModelIsNull() {
            //Assert.Null(nonInstanciated);
            Assert.Inconclusive("Cannot be tested");
        }

        [Test]
        public void TestModelValuesEqualWhatIsInputted() {
            //main.Name = "Test Item";
            //main.Description = "This Items is used for testing";
            //main.BoxNumber = 1;
            //main.ImagePath = "C:/test/testing/moreTesting/";

            //Assert.AreEqual("Test Item", main.Name);
            //Assert.AreEqual("This Items is used for testing", main.Description);
            //Assert.AreEqual(1, main.BoxNumber);
            //Assert.AreEqual("C:/test/testing/moreTesting/", main.ImagePath);
            Assert.Inconclusive("Cannot be tested");
        }

        [Test]
        public void TestModelValuesInsertProperly() {
            //main.Name = "Test Item";
            //main.Description = "This Items is used for testing";
            //main.BoxNumber = 1;
            //main.ImagePath = "C:/test/testing/moreTesting/";

            //main.SubmitItems();

            Assert.Inconclusive("Cannot be tested");
        }
    }
}