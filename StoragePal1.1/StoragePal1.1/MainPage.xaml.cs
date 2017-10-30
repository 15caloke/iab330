using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoragePal1 {
    /*
     * The first page th user sees when they
     * log in. Clicking on this page navigates 
     * them to the camera page
     * 
     * Date: 29th of October 2017
     */
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        async void CallCameraPage(Object Sender, EventArgs e) {
            await Navigation.PushAsync(new CameraPage());
        }
    }
}
