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
        private Database db;
        private List<string> roomNames;

        public MovingPage() {
            InitializeComponent();
            BindingContext = new ItemsViewModel();
            roomNames = new List<string>();
            db = new Database();
            relatedBoxes = new List<Boxes>();
            boxNumbersLabel = new Label() {
                FontSize = FONT_SIZE,
                HeightRequest = 70,
                //BackgroundColor = Color.Orange,
                //TextColor = Color.White,
                //FontAttributes = FontAttributes.Bold,
                //Text = "Room\n"
            };
        }

        protected override void OnAppearing() {
            BindingContext = new ItemsViewModel();
        }

        private void AddRoom_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new SubPages.AddRoomPage());
        }

        private void MenuItem_Clicked(object sender, EventArgs e) {
            roomNames.Clear();
            var selectedRoom = ((MenuItem)sender).CommandParameter as Rooms;
            var allBoxes = ((ItemsViewModel)BindingContext).AllBoxes;

            foreach (Boxes box in allBoxes) {
                if (selectedRoom.Function == box.RoomName) {
                    roomNames.Add(box.RoomName);
                }
            }

            if (roomNames.Contains(selectedRoom.Function)) {
                // add event to delete room and all boxes in it, if they press yes
                DisplayAlert("Room contains boxes",
                    "If you delete the room you'll delete all boxes in it, are you sure you want to delete it?",
                    "Yes", "No");
            } else {
                ((ItemsViewModel)BindingContext).Delete(selectedRoom);
                OnAppearing();
            }
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            var selectedRoom = e.SelectedItem as Rooms;

            //boxNumbersLabel.TextColor = Color.Black;
            //boxNumbersLabel.BackgroundColor = Color.White;

            if (selectedRoom == null) { } else {
                var theRoom = new Rooms() {
                    Id = selectedRoom.Id,
                    UserId = ((int)Application.Current.Properties["userId"]),
                    Function = selectedRoom.Function,
                };

                foreach (Boxes box in ((ItemsViewModel)BindingContext).AllBoxes) {
                    if (box.RoomId == theRoom.Id) {
                        relatedBoxes.Add(box);
                    }
                }

                if (relatedBoxes.Count == 0 || relatedBoxes == null) {
                    boxNumbersLabel.Text = "\tThere are no boxes in this room";
                } else {
                    boxNumbersLabel.Text = "\tBoxes in the " + theRoom.Function + " are: \n\n";
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
