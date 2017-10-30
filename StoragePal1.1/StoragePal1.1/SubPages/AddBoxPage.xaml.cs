using StoragePal1.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoragePal1.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoragePal1.SubPages {
    /*
     * A subpage to add new box information
     * and submit it to the database if it 
     * passes validation
     * 
     * Date: 29th October 2017
     */
    public partial class AddBoxPage : ContentPage {
        public AddBoxPage() {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void SubmitBox_Clicked(object sender, EventArgs e) {
            var userLoggedIn = (int)Application.Current.Properties["userId"];
            var boxNumInput = Int32.Parse(boxNumber.Text);
            var theRoom = ((MainViewModel)BindingContext).GetTheRoom(roomName.Text, userLoggedIn);

            // Detects if the room's name is in the database and the box number according to the user logged in
            // and submits it to the database if both fields exist
            if (((MainViewModel)BindingContext).BoxExist(userLoggedIn, boxNumInput)) {
                DisplayAlert("Already exist", "The box you want to create is already exist. Please enter a different number", "OK");
            } else if (theRoom == null) {
                DisplayAlert("Room Does not Exist", "The entered room does not exist. Please enter a different room or create one",
                    "OK");
            } else {
                var theBox = new Boxes() {
                    UserId = ((int)Application.Current.Properties["userId"]),
                    RoomId = theRoom.Id,
                    Number = Int32.Parse(boxNumber.Text),
                    Category = boxCategory.Text,
                    RoomName = roomName.Text,
                    QRCode = "", // Need to implement further down the track
                };

                ((MainViewModel)BindingContext).SubmiteTheBox(theBox);
                Navigation.PopAsync(true);
            }
        }
    }
}