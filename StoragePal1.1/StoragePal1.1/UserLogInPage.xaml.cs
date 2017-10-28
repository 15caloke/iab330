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
        public UserLogInPage() {
            InitializeComponent();
            BindingContext = new MainViewModel();
            // Remove this before final release. Used for quick log in
            usernameEntry.Text = "theAdmin";
            passwordEntry.Text = "Password123";
            ErrorMessage.Text = "";
        }
        private void OnSignUpButtonClicked(object sender, EventArgs e) {
            Navigation.PushAsync(new SignUpPage());
        }

        private void TempLoginClicked(object sender, EventArgs e) {
            if (((MainViewModel)BindingContext).ValidateUser(usernameEntry.Text, passwordEntry.Text)) {
                var user = ((MainViewModel)BindingContext).GetTheUser(usernameEntry.Text);
                ErrorMessage.Text = "";

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
    }
}
