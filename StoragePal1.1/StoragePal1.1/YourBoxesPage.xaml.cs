using System;
using System.Collections.Generic;
using System.IO;
using StoragePal1.Databases;
using StoragePal1.Models;

using Xamarin.Forms;

namespace StoragePal1 {
    public partial class YourBoxesPage : ContentPage {
        public YourBoxesPage() {
            InitializeComponent();
            BindingContext = new ItemsViewModel();

            //Need to put in settings page
       
        }

        protected override void OnAppearing() {
            BindingContext = new ItemsViewModel();
        }

        //protected override void OnBindingContextChanged() {
        //    base.OnBindingContextChanged();

        //    ItemsViewModel vm = BindingContext as ItemsViewModel;
        //    if (vm != null) {
        //        this.thePicker.Items.Clear();
        //        foreach (var box in vm.AllBoxes) {
        //            thePicker.Items.Add("Box " + box.Number.ToString() + ": " + box.Category.ToString());
        //        }
        //    }
        //}

        private void Button_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new SubPages.AddBoxPage());
        }

        private void MenuItem_Clicked(object sender, EventArgs e) {
            var selectedBox = ((MenuItem)sender).CommandParameter as Boxes;
            ((ItemsViewModel)BindingContext).Delete(selectedBox);
            OnAppearing();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            // Binds SelectedBox to SelectedItem
            var selectedbox = e.SelectedItem as Boxes;
            if (selectedbox == null) {

            } else {
                var singleBox = new Boxes() {
                    Id = selectedbox.Id,
                    UserId = ((int)Application.Current.Properties["userId"]),
                    Number = selectedbox.Number,
                    RoomName = selectedbox.RoomName,
                    Category = selectedbox.Category,
                    QRCode = selectedbox.QRCode
                };

                var singleBoxPage = new SubPages.ViewSingleBoxPage() {
                    BindingContext = singleBox
                };
                Navigation.PushAsync(singleBoxPage);
            }
        }

        private void ExportButton_Clicked(object sender, EventArgs e) {
            // Add export function
        }
    }
}
