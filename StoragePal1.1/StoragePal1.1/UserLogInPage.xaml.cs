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
            usernameEntry.Text = "admin";
            passwordEntry.Text = "admin";
            ErrorMessage.Text = "";
        }
        async void OnSignUpButtonClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new SignUpPage());
        }

        private void TempLoginClicked(object sender, EventArgs e) {
            if (((MainViewModel)BindingContext).ValidateUser(usernameEntry.Text, passwordEntry.Text)) {
                // Session variables
                ErrorMessage.Text = "";
               Application.Current.Properties.Clear();
                Application.Current.Properties.Add("uname", usernameEntry.Text);
                Application.Current.Properties.Add("isLogged", true);
                Navigation.PushAsync(new StoragePal1_1Page());
            } else {
                // Need a better feeback mechanism
                ErrorMessage.Text = "Username and/or Password Invalid";
            }
        }
    }
}
