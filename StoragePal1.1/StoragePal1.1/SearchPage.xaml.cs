using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StoragePal1 {
    public partial class SearchPage : ContentPage {
        public SearchPage() {
            InitializeComponent();
            usernameLabel.Text = "Hello! " + Application.Current.Properties["uname"].ToString();
        }

        private void Logout_Button_Clicked(object sender, EventArgs e) {
            // End user session
            Application.Current.Properties["userId"] = null;
            Application.Current.Properties["uname"] = "";
            Application.Current.Properties["isLogged"] = false;
            Navigation.PopToRootAsync(true);
        }

    }
}
