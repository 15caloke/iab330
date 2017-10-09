using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoragePal1 {
    public partial class ItemsPage : ContentPage {
        public ItemsPage() {
            InitializeComponent();
            BindingContext = new ItemsViewModel();
        }
        private void AddItemButtonClicked(Object sender, EventArgs e) {
            Navigation.PushAsync(new SubPages.AddNewItemPage());
        }

    }
}
