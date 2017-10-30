using System;
using System.Collections.Generic;
using System.IO;
using StoragePal1.Databases;
using StoragePal1.Models;
using StoragePal1;

using Xamarin.Forms;

namespace StoragePal1 {
    /*
     * Displays a list of boxes that are bound to the user
     * who created them. Passes the data of a selected box 
     * onto a new page if clicked on
     *
     * Date: 29th October 2017
     */
    public partial class YourBoxesPage : ContentPage {
        private const int FONT_SIZE = 20;
        private Label itemsInBoxLabel;
        private List<Items> listOfItems;
        private Button submitButton;
        private Database db;

        public YourBoxesPage() {
            InitializeComponent();
            db = new Database();
            listOfItems = new List<Items>();
            BindingContext = new ItemsViewModel();
            itemsInBoxLabel = new Label() {
                FontSize = FONT_SIZE,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
            };
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
            var ivm = ((ItemsViewModel)BindingContext);
            var userLoggedIn = (int)(Application.Current.Properties["userId"]);

            if (selectedbox == null) { } else {
                var singleBox = new Boxes() {
                    Id = selectedbox.Id,
                    UserId = ((int)Application.Current.Properties["userId"]),
                    Number = selectedbox.Number,
                    RoomName = selectedbox.RoomName,
                    Category = selectedbox.Category,
                    QRCode = selectedbox.QRCode
                };

                // adds all items in the box to a list of items to display
                foreach (Items item in ivm.AllItems) {
                    if (item.BoxId == singleBox.Id) {
                        listOfItems.Add(item);
                    }
                }

                if (listOfItems.Count == 0 || listOfItems == null) {
                    itemsInBoxLabel.Text = "\nThere are no items in this box";
                } else {
                    itemsInBoxLabel.Text = "\nItems in this box are: \n";
                }

                foreach (Items eachItem in listOfItems) {
                    itemsInBoxLabel.Text += eachItem.Name + "\n";
                }

                // create a new page with elements and display the selected box
                // information in those elements
                var singleBoxPage = new SubPages.ViewSingleBoxPage() {
                    Content = new StackLayout {
                        BindingContext = singleBox,
                        Padding = new Thickness(0, 20, 0, 0),
                        VerticalOptions = LayoutOptions.StartAndExpand,
                        Children = {
                            new Label {
                                FontSize = FONT_SIZE,
                                TextColor = Color.Black,
                                HorizontalTextAlignment = TextAlignment.Center,
                                Text = "Box " + singleBox.Number.ToString(),
                            },
                            new Label {
                                FontSize = FONT_SIZE,
                                TextColor = Color.Black,
                                HorizontalTextAlignment = TextAlignment.Center,
                                Text = singleBox.Category
                            },
                            new Label {
                                FontSize = FONT_SIZE,
                                TextColor = Color.Black,
                                HorizontalTextAlignment = TextAlignment.Center,
                                Text = singleBox.RoomName
                            },
                            itemsInBoxLabel
                        }
                    }
                };

                listOfItems.Clear();
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
                inputText += "\nBox " + box.Number.ToString() + " " + box.Category + " in " + box.RoomName + ":\n";
                foreach (Items item in listOfItemsInEachBox) {
                    if (box.Number == item.BoxNumber) {
                        inputText += item.Name + " - " + item.Description + "\n";
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
