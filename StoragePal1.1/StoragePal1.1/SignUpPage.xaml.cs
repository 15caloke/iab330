using StoragePal1.Databases;
using StoragePal1.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoragePal1 {
    public partial class SignUpPage : ContentPage {
        private readonly Database db;
        public SignUpPage() {
            InitializeComponent();
            BindingContext = new MainViewModel();
            invalidMessage.Text = "";

        }

        private void OnCreate(object sender, EventArgs e) {
            invalidMessage.Text = "";
            string currentEmail = emailEntry.Text;
            if (!Validation.Validation.ValidEmail(emailEntry.Text)) {
                invalidMessage.Text = "Please enter a valid email address";
            } else if (!Validation.Validation.ValidUsername(usernameEntry.Text)){
                invalidMessage.Text = "A username must contains at least 6 characters, no special characters allowed";

            } else {
                if (!((MainViewModel)BindingContext).ValidateEmail(emailEntry.Text)) {
                    invalidMessage.Text = "The email already exists";
                }
                else if (!((MainViewModel)BindingContext).ValidateUsername(usernameEntry.Text)) {
                    invalidMessage.Text = "The username already exists";
                }
                else {
                    ((MainViewModel)BindingContext).CreateUser(emailEntry.Text, usernameEntry.Text, passwordEntry.Text);
                    Navigation.PopAsync(true);
                }
            }
        }
    }
}
