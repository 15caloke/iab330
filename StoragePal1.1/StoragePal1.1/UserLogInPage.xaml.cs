using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StoragePal1
{
    public partial class UserLogInPage : ContentPage
    {
        public UserLogInPage()
        {
            InitializeComponent();
        }
		async void OnSignUpButtonClicked(Object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SignUpPage());
		}

        // DELETE THE BELOW COMMAND ///
        async void TempLoginClicked(Object sender, EventArgs e) 
        {
            await Navigation.PushAsync(new StoragePal1_1Page());
        }
        // DELETE THE ABOVE CODE //
    }
}
