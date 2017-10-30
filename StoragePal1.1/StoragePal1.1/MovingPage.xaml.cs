using System;
using System.Collections.Generic;
using StoragePal1.Databases;
using StoragePal1.Models;

using Xamarin.Forms;

namespace StoragePal1 {
    /*
     * Shows a list of rooms to the user who created them
     * and their name/function. Room data is passed onto a new page
     * to view the selected room, if the user clicks on it in the
     * listview
     * 
     * Date: 29th October 2017
     */
    public partial class MovingPage : ContentPage {
        private const int FONT_SIZE = 16, MIN_PAGE_HEIGHT = 70;
        private List<Boxes> relatedBoxes;
        private Label boxNumbersLabel;
        private List<string> roomNames;

        public MovingPage() {
            InitializeComponent();
            BindingContext = new ItemsViewModel();
            roomNames = new List<string>();
            relatedBoxes = new List<Boxes>();
            boxNumbersLabel = new Label() {
                FontSize = FONT_SIZE,
                HeightRequest = MIN_PAGE_HEIGHT,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center
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
            var allBoxes = ((ItemsViewModel)BindingContext).AllBoxes;

            roomNames.Clear();
            ((ItemsViewModel)BindingContext).Delete(selectedRoom);
            OnAppearing();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            var selectedRoom = e.SelectedItem as Rooms;

            if (selectedRoom == null) { } else {
                var theRoom = new Rooms() {
                    Id = selectedRoom.Id,
                    UserId = ((int)Application.Current.Properties["userId"]),
                    Function = selectedRoom.Function,
                };

                // add boxes that are in the room to a new list of boxes
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

                // display information about each box on the ViewSingleRoom page
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
