using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoragePal1.Databases;
using StoragePal1.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoragePal1.SubPages {
    public partial class ViewSingleBoxPage : ContentPage {
        private readonly Database db;

        public ViewSingleBoxPage() {
            InitializeComponent();
            db = new Database();
        }

        private void SaveChangesButton_Clicked(object sender, EventArgs e) {
            var theBox = ((Button)sender).CommandParameter as Boxes;
            var belongedRoom = db.FetchRoom(boxRoomName.Text);
            var roomNum = Int32.Parse(boxNumSingle.Text);
            var listOfBoxes = db.FetchAllBoxes();

            if (belongedRoom == null) {
                DisplayAlert("Invalid Room Name", "The room name does not exist. Please enter a valid one or create one", "OK");
                //} else if () {
                //    DisplayAlert("Box Number Already Exits", "Please enter a different box number as that one already exists", "OK");
            } else {
                theBox.RoomId = belongedRoom.Id;
                db.InsertOrUpdate(theBox);
                Navigation.PopAsync(true);
            }
        }
    }
}