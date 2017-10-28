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
    public partial class AddBoxPage : ContentPage {
        public AddBoxPage() {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void SubmitBox_Clicked(object sender, EventArgs e) {
            var userLoggedIn = (int)Application.Current.Properties["userId"];
            var boxNumInput = Int32.Parse(boxNumber.Text);
            if (((MainViewModel)BindingContext).BoxExist(userLoggedIn, boxNumInput)) {
                DisplayAlert("Already exist", "The box you want to create is already exist. Please enter a different number", "OK");
            } else {
                var theRoom = ((MainViewModel)BindingContext).GetTheRoom(roomName.Text);

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