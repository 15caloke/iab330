using System;
using System.Collections.Generic;
using StoragePal1.Databases;
using StoragePal1.Models;
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

        // Refresh the page
        protected override void OnAppearing() {
            BindingContext = new ItemsViewModel();
        }

        private void MenuItem_Clicked(object sender, EventArgs e) {
            var selectedItem = ((MenuItem)sender).CommandParameter as Items;
            ((ItemsViewModel)BindingContext).Delete(selectedItem);
            OnAppearing();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            var selectedItem = e.SelectedItem as Items;

            var singleItem = new Items() {
                Id = selectedItem.Id,
                BoxId = selectedItem.BoxId,
                UserId = ((int)Application.Current.Properties["userId"]),
                Name = selectedItem.Name,
                Description = selectedItem.Description,
                BoxNumber = selectedItem.BoxNumber,
                ImagePath = selectedItem.ImagePath
            };

            var singleItemPage = new SubPages.ViewSingleItemPage() {
                BindingContext = singleItem
            };
            Navigation.PushAsync(singleItemPage);
        }
    }
}