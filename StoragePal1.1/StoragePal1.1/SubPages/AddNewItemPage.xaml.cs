using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoragePal1.SubPages {
    public partial class AddNewItemPage : ContentPage {
        public AddNewItemPage() {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e) {
            Navigation.PopAsync(true);
            // Navigation.PushAsync(new ItemsPage());
        }
    }
}
