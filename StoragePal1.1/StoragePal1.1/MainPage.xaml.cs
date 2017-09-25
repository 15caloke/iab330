using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StoragePal1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void CallCameraPage (Object Sender, EventArgs e)
        {
            await Navigation.PushAsync(new CameraPage());
        }
    }
}
