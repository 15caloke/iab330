using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StoragePal1 {
    public partial class SignUpPage : ContentPage {
        public SignUpPage() {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void OnCreate(object sender, EventArgs e) {
            Navigation.PopAsync(true);
        }
    }
}
