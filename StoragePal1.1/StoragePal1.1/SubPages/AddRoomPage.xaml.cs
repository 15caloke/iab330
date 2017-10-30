using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StoragePal1.Models;

namespace StoragePal1.SubPages {
    public partial class AddRoomPage : ContentPage {
        /*
         * Subpage to add a new room to put boxes in
         * and submit to the database if it passes validation
         * 
         * Date: 29th October 2017
         */
        public AddRoomPage() {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        protected override void OnAppearing() {
            BindingContext = new MainViewModel();
        }

        // Checks if the room name already exists and inserts into database if not
        private void SubmitRoom_Clicked(object sender, EventArgs e) {
            var mvm = ((MainViewModel)BindingContext);
            var userIdLoggedIn = (int)(Application.Current.Properties["userId"]);

            if (mvm.ValidateRoom(funtionEntry.Text, userIdLoggedIn)) {
                DisplayAlert("Room Already Exists", "Please enter another room name", "OK");
            } else {
                var newRoom = new Rooms() {
                    UserId = userIdLoggedIn,
                    Function = funtionEntry.Text
                };

                mvm.SubmitRoom(newRoom);
                Navigation.PopAsync(true);
            }
        }
    }
}