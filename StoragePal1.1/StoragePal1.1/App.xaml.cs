using System.Diagnostics;
using Xamarin.Forms;

namespace StoragePal1 {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            MainPage = new NavigationPage(new UserLogInPage());
        }

        protected override void OnStart() {
            // Handle when your app starts
            //Debug.WriteLine("OnStart");
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
            //Debug.WriteLine("OnSleep");
        }

        protected override void OnResume() {
            // Handle when your app resumes
            //Debug.WriteLine("OnResume");
        }
    }
}
