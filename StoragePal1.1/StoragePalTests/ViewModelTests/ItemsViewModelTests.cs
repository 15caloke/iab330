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
    public partial class ItemsViewModelTests {
        MainViewModel main;
        ItemsViewModel items, notInstanciated;


        [SetUp]
        public void SetUp() {
            main = new MainViewModel {
                Name = "Test",
                Description = "just testing",
                BoxNumber = 2,
                ImagePath = "C:/TestDir/SecondDir/ThirdDir/"
            };
            items = new ItemsViewModel();
        }

        [Test]
        public void TestModelIsNotNull() {
            Assert.NotNull(items);
        }

        [Test]
        public void TestNotInstanciatedIsNull() {
            Assert.Null(notInstanciated);
        }

        [Test]
        public void TestModelRetrievesData() {
            foreach (Items item in items.AllItems) {
                Assert.AreEqual(1, item.Id);
                Assert.AreEqual("Test", item.Name);
                Assert.AreEqual("just testing", item.Description);
                Assert.AreEqual(2, item.BoxNumber);
                Assert.AreEqual("C:/TestDir/SecondDir/ThirdDir/", item.ImagePath);
            }
        }

    }
}
