using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StoragePal1
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
            usernameLabel.Text = Application.Current.Properties["uname"].ToString();
        }

        //Need to put in settings page
        private void Logout_Button_Clicked(object sender, EventArgs e)
        {
            //Code for Log Out
            Application.Current.Properties["userId"] = null;
            Application.Current.Properties["uname"] = "";
            Application.Current.Properties["isLogged"] = false;
            Navigation.PopToRootAsync(true);
        }

    }
}
