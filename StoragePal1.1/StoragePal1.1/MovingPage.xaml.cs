using System;
using System.Collections.Generic;
using StoragePal1.Databases;
using StoragePal1.Models;

using Xamarin.Forms;

namespace StoragePal1 {
    public partial class MovingPage : ContentPage {
        private List<int> boxNumbers;
        private Label boxNumbersLabel;

        public MovingPage() {
            InitializeComponent();
            BindingContext = new ItemsViewModel();
            boxNumbers = new List<int>();
            boxNumbersLabel = new Label();
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
            if (selectedRoom == null) {

            }
            else {
                var theRoom = new Rooms() {
                    Id = selectedRoom.Id,
                    UserId = ((int)Application.Current.Properties["userId"]),
                    Function = selectedRoom.Function
                };

                foreach (Boxes x in ((ItemsViewModel)BindingContext).AllBoxes) {
                    if (x.RoomId == theRoom.Id) {
                        boxNumbers.Add(x.Number);
                    }
                }

                boxNumbersLabel.Text = "Boxes in the " + theRoom.Function + " are: \n";

                foreach (int eachNum in boxNumbers) {
                    boxNumbersLabel.Text += "Box " + eachNum.ToString() + "\n";
                }


                var selectedRoomPage = new SubPages.ViewSingleRoomPage() {
                    BindingContext = theRoom,
                    Content = boxNumbersLabel
                };

                Navigation.PushAsync(selectedRoomPage);
            }
        }
    }
}
