using StoragePal1.Models;
using StoragePal1.Databases;
using PCLCrypto;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Text;
using Xamarin.Forms.Xaml;

namespace StoragePal1 {
    public partial class UserLogInPage : ContentPage {
        /*
         * Allows users to enter their account information and login
         * successfully, if their inputted information is in the database
         * 
         * Date: 29th October 2017
         */
        public UserLogInPage() {
            InitializeComponent();
            BindingContext = new MainViewModel();
            ErrorMessage.Text = String.Empty;
        }
        private void OnSignUpButtonClicked(object sender, EventArgs e) {
            Navigation.PushAsync(new SignUpPage());
        }

        private void TempLoginClicked(object sender, EventArgs e) {
            // Checks inputted entries against values in the database and allows them to login
            // if there is, otherwise displays an error message
            if (((MainViewModel)BindingContext).ValidateUser(usernameEntry.Text, passwordEntry.Text)) {
                var user = ((MainViewModel)BindingContext).GetTheUser(usernameEntry.Text);
                ErrorMessage.Text = String.Empty;
                // Session variables
                Application.Current.Properties.Clear();
                Application.Current.Properties.Add("userId", user.Id);
                Application.Current.Properties.Add("uname", user.Username);
                Application.Current.Properties.Add("isLogged", true);
                Navigation.PushAsync(new StoragePal1_1Page());
            } else {
                ErrorMessage.Text = "Username and/or Password Invalid";
            }
        }

        protected override void OnDisappearing() {
            base.OnDisappearing();
            ErrorMessage.Text = String.Empty;
        }
    }
}
