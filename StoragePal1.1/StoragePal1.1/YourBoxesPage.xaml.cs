using System;
using System.Collections.Generic;
using StoragePal1.Databases;
using StoragePal1.Models;

using Xamarin.Forms;

namespace StoragePal1 {
    public partial class YourBoxesPage : ContentPage {
        public YourBoxesPage() {
            InitializeComponent();
            BindingContext = new ItemsViewModel();
        }

        protected override void OnAppearing() {
            BindingContext = new ItemsViewModel();
        }

        protected override void OnBindingContextChanged() {
            base.OnBindingContextChanged();

            ItemsViewModel vm = BindingContext as ItemsViewModel;
            if (vm != null) {
                this.thePicker.Items.Clear();
                foreach (var box in vm.AllBoxes) {
                    thePicker.Items.Add("Box " + box.Number.ToString() + ": " + box.Category.ToString());
                }
            }
        }

        private void Button_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new SubPages.AddBoxPage());
        }
    }
}
