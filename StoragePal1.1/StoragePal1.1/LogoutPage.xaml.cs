using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StoragePal1 {
    /*
     * Page primarily for logging the user out and 
     * ending their session
     * 
     * Date: 29th of October 2017
     */
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
            // pops back to login screen
            Navigation.PopToRootAsync(true);
        }

    }
}
