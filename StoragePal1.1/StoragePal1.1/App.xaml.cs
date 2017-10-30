using System.Diagnostics;
using Xamarin.Forms;

namespace StoragePal1 {
    public partial class App : Application {
        public App() {
            InitializeComponent();
            MainPage = new NavigationPage(new UserLogInPage());
        }

        protected override void OnStart() {
            //Debug.WriteLine("OnStart");
        }

        protected override void OnSleep() {
            //Debug.WriteLine("OnSleep");
        }

        protected override void OnResume() {
            //Debug.WriteLine("OnResume");
        }
    }
}
