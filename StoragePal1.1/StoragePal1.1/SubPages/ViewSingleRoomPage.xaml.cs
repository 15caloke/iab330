using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoragePal1.Models;
using StoragePal1.Databases;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoragePal1.SubPages {
    public partial class ViewSingleRoomPage : ContentPage {
        Label headingLabel;

        public ViewSingleRoomPage() {
            InitializeComponent();
            // need to add to the page
            headingLabel = new Label() {
                AnchorX = 0,
                AnchorY = 0,
                Text = "Room",
                IsVisible = true
            };
        }

        private void FinishedButton_Clicked(object sender, EventArgs e) {
            Navigation.PopAsync(true);
        }
    }
}