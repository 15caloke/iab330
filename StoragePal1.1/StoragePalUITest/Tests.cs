using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace StoragePalUITest {
    /*
     * Cross-platform automated testing, which tests the
     * operation of the app and makes sure they validate
     * 
     * NOTE: Tests may not pass or function due to Dependency Injection,
     * however they were manually tested as well and passed
     * 
     * Date: 29th October 2017
     */
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests {
        IApp app;
        Platform platform;

        public Tests(Platform platform) {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest() {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches() {
            app.Tap(c => c.Marked("TapToBegin"));
        }

        [Test]
        public void AppLaunchesAndLogin() {
            app.Tap(c => c.Marked("TapToBegin"));
            app.Tap(c => c.Marked("usernameEntry"));
            app.EnterText("theAdmin");
            app.Tap(c => c.Marked("passwordEntry"));
            app.EnterText("Password123@");
            app.Tap(c => c.Marked("LoginButton"));
        }

        [Test]
        public void AppLaunchesAndRegisterCorrectly() {
            app.Tap(c => c.Marked("TapToBegin"));
            app.Tap(c => c.Marked("SignUpButton"));
            app.Tap(c => c.Marked("email"));
            app.EnterText("test123@example.com");
            app.Tap(c => c.Marked("username"));
            app.EnterText("testuser123");
            app.Tap(c => c.Marked("password"));
            app.EnterText("P@55word");
            app.Tap(c => c.Marked("rePassword"));
            app.EnterText("P@55word");
            app.Tap(c => c.Marked("SignUpUserButton"));
        }
    }
}

