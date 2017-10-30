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
    /*
     * Shows all room information including the name, and 
     * all boxes being contained in the room, according to the 
     * room selected on the previous page from the listview
     * 
     * Date: 29th of October 2017
     */
    public partial class ViewSingleRoomPage : ContentPage {
        public ViewSingleRoomPage() {
            InitializeComponent();
        }

        private void FinishedButton_Clicked(object sender, EventArgs e) {
            Navigation.PopAsync(true);
        }
    }
}