using System;
using System.Collections.Generic;
using StoragePal1.Databases;
using StoragePal1.Models;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Xamarin.Forms.Xaml;

namespace StoragePal1 {
    public partial class ItemsPage : ContentPage {
        private ObservableCollection<Items> searchedItems;

        public ItemsPage() {
            InitializeComponent();
            BindingContext = new ItemsViewModel();
            searchedItems = new ObservableCollection<Items>();
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

            if (selectedItem == null) { } else {
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

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e) {
            searchedItems.Clear();
            var inputtedSearch = searchBar.Text;
            var listOfItems = ((ItemsViewModel)BindingContext).AllItems;

            // searches through each item and adds any items to a temporary list that match
            foreach (Items item in listOfItems) {
                if (item.Name.Contains(inputtedSearch.ToLower())
                    || item.Name.Contains(inputtedSearch.ToUpper())
                    || item.Name.Contains(inputtedSearch)) {
                    searchedItems.Add(item);
                } else if (item.BoxNumber.ToString().Contains(inputtedSearch)) {
                    searchedItems.Add(item);
                }
            }

            // refresh the page and display the items matched with the search bar inputted text
            itemsList.ItemsSource = searchedItems;
            OnAppearing();
        }
    }
}