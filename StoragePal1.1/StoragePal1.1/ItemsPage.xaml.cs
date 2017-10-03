using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StoragePal1
{
    public partial class ItemsPage : ContentPage
    {
        public ItemsPage()
        {
            InitializeComponent();
        }
		async void AddItemButtonClicked(Object sender, EventArgs e)
		{
            await Navigation.PushAsync(new SubPages.AddNewItemPage());
		}

	}
}
