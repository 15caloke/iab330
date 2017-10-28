using System;
using System.Collections.Generic;
using StoragePal1.Databases;
using StoragePal1.Models;

using Xamarin.Forms;

namespace StoragePal1 {
    public partial class MovingPage : ContentPage {
        public MovingPage() {
            InitializeComponent();
            BindingContext = new ItemsViewModel();
        }

        protected override void OnAppearing() {
            BindingContext = new ItemsViewModel();
            //new Label() {

            //}
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
            // Add code to view single room
        }
    }
}
