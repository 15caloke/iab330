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
        }

        private void OnCreate(object sender, EventArgs e) {
            if (((MainViewModel)BindingContext).ValidateSignup(emailEntry.Text, usernameEntry.Text)) {
                ((MainViewModel)BindingContext).CreateUser(emailEntry.Text, usernameEntry.Text, passwordEntry.Text);
                Navigation.PopAsync(true);
            } else {
                emailEntry.Text = "Username and/or Email has already taken";
            }
        }
    }
}
