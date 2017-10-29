using System;
using System.Collections.Generic;
using System.IO;
using StoragePal1.Databases;
using StoragePal1.Models;
using StoragePal1;

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
            var file = "StoragePal_Data.txt";
            var fileService = DependencyService.Get<ISaveAndLoad>();
            var inputText = "";
            var listOfBoxes = ((ItemsViewModel)BindingContext).AllBoxes;
            var listOfItemsInEachBox = ((ItemsViewModel)BindingContext).AllItems;

            inputText += Application.Current.Properties["uname"] + ": \t\t\n";

            foreach (Boxes box in listOfBoxes) {
                inputText += "\nBox " + box.Number.ToString() + " " + box.Category + " in " + box.RoomName + "\n";
                foreach (Items item in listOfItemsInEachBox) {
                    if (box.Number == item.BoxNumber) {
                        inputText += item.Name + " " + item.BoxNumber.ToString() + " " + item.Description + "\n";
                    }
                }
            }

            exportFeedback.Text = "Data has been exported successfully";
            fileService.SaveTextAsync(file, inputText);
        }

        protected override void OnDisappearing() {
            base.OnDisappearing();
            exportFeedback.Text = String.Empty;
        }
    }
}
