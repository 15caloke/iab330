using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StoragePal1 {
    public partial class YourBoxesPage : ContentPage {
        public YourBoxesPage() {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new SubPages.AddBoxPage());
        }
    }
}
