using System;
using System.Collections.Generic;
using StoragePal1.Databases;
using StoragePal1.Models;

using Xamarin.Forms;

namespace StoragePal1 {
    public partial class MovingPage : ContentPage {
        private const int FONT_SIZE = 16;
        private List<Boxes> relatedBoxes;
        private Label boxNumbersLabel;

        public MovingPage() {
            InitializeComponent();
            BindingContext = new ItemsViewModel();
            relatedBoxes = new List<Boxes>();
            boxNumbersLabel = new Label() {
                FontSize = FONT_SIZE,
                FontAttributes = FontAttributes.Bold,
            };
        }

        protected override void OnAppearing() {
            BindingContext = new ItemsViewModel();
        }

        private void AddRoom_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new SubPages.AddRoomPage());
        }

        private void MenuItem_Clicked(object sender, EventArgs e) {
            var selectedRoom = ((MenuItem)sender).CommandParameter as Rooms;
            ((ItemsViewModel)BindingContext).Delete(selectedRoom);
            OnAppearing();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            var selectedRoom = e.SelectedItem as Rooms;

            if (selectedRoom == null) { } else {
                var theRoom = new Rooms() {
                    Id = selectedRoom.Id,
                    UserId = ((int)Application.Current.Properties["userId"]),
                    Function = selectedRoom.Function
                };

                foreach (Boxes box in ((ItemsViewModel)BindingContext).AllBoxes) {
                    if (box.RoomId == theRoom.Id) {
                        relatedBoxes.Add(box);
                    }
                }

                if (relatedBoxes.Count == 0 || relatedBoxes == null) {
                    boxNumbersLabel.Text = "There are no boxes in this room";
                } else {
                    boxNumbersLabel.Text = "Boxes in the " + theRoom.Function + " are: \n";
                }

                foreach (Boxes eachBox in relatedBoxes) {
                    boxNumbersLabel.Text += "Box " + eachBox.Number.ToString() + " - " + eachBox.Category + "\n";
                }

                var selectedRoomPage = new SubPages.ViewSingleRoomPage() {
                    BindingContext = theRoom,
                    Content = boxNumbersLabel
                };

                Navigation.PushAsync(selectedRoomPage);
                relatedBoxes.Clear();
            }
        }
    }
}
