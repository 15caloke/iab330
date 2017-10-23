using System;
using System.Collections.Generic;
using StoragePal1.Databases;
using StoragePal1.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoragePal1 {
    public partial class ItemsPage : ContentPage {
        //private readonly Database db;

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

        //private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
        //    // Code to make individual item page
        //}

        //private void OnDelete(object sender, EventArgs e) {
        //    var menuItem = ((MenuItem)sender);
        //    var items = ((ItemsViewModel) menuItem.CommandParameter);
        //   // items.DeleteCommand;
        //}
    }
}