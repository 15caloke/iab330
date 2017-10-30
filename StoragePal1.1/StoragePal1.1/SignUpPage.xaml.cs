using StoragePal1.Databases;
using StoragePal1.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoragePal1 {
    public partial class SignUpPage : ContentPage {
        /*
         * Allows new users to register an account and store the
         * account information to the local database, as long it passes validation.
         * 
         * Date: 29th October 2017
         */
        public SignUpPage() {
            InitializeComponent();
            BindingContext = new MainViewModel();
            invalidMessage.Text = "";
        }
        private void OnCreate(object sender, EventArgs e) {
            invalidMessage.Text = "";
            string currentEmail = emailEntry.Text;

            // Checks against inputted emails, passwords and usernames to make sure
            // that there is no user with those details already stored in the database and
            // the new user enters a srong enough password, username and valid email
            if (!Validation.Validation.ValidEmail(emailEntry.Text)) {
                invalidMessage.Text = "Please enter a valid email address";
            } else if (!Validation.Validation.ValidUsername(usernameEntry.Text)) {
                invalidMessage.Text = "A username must contain 6-20 characters, no special characters allowed";
            } else if (!Validation.Validation.ValidPassword(passwordEntry.Text)) {
                invalidMessage.Text = "Minimum eight characters, at least one uppercase letter, one lowercase letter, one special character and one number are required for password";
            } else {
                if (!((MainViewModel)BindingContext).ValidateEmail(emailEntry.Text)) {
                    invalidMessage.Text = "The email already exists";
                } else if (!((MainViewModel)BindingContext).ValidateUsername(usernameEntry.Text)) {
                    invalidMessage.Text = "The username already exists";
                } else if (rePasswordEntry.Text != passwordEntry.Text) {
                    invalidMessage.Text = "Please re-enter your password correctly";
                } else {
                    ((MainViewModel)BindingContext).CreateUser(emailEntry.Text, usernameEntry.Text, passwordEntry.Text);
                    Navigation.PopAsync(true);
                }
            }
        }
    }
}
