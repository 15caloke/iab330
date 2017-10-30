using System;
using System.Collections.Generic;
using StoragePal1.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoragePal1.SubPages {
    /*
     * Subpage to add a new Item and submit to the database
     * if it passes valiadation
     * 
     * Date: 29th October 2017
     */
    public partial class AddNewItemPage : ContentPage {
        public AddNewItemPage() {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void ToSubmit_Clicked(object sender, EventArgs e) {
            var userLoggedIn = (int)Application.Current.Properties["userId"];
            var boxNumInput = Int32.Parse(boxNumber.Text);
            var selectedBox = ((MainViewModel)BindingContext).GetTheBox(boxNumInput, userLoggedIn);

            // Check if box number to put the item in exist according to the logged in user
            if (!((MainViewModel)BindingContext).BoxExist(userLoggedIn, boxNumInput)) {
                DisplayAlert("Box Does Not Exist",
                    "The box doesn't exist yet. Create a box in the box page", "OK");
            } else if (itemName.Text == String.Empty || itemName.Text == null) {
                DisplayAlert("No Item Name",
                    "Cannot create an Item without a name, please enter a name", "OK");
            } else {
                var newItem = new Items() {
                    Name = itemName.Text,
                    BoxId = selectedBox.Id,
                    UserId = userLoggedIn,
                    Description = itemDescription.Text,
                    BoxNumber = boxNumInput
                };

                ((MainViewModel)BindingContext).SubmitTheItem(newItem);
                Navigation.PopAsync(true);
            }
        }
    }
}
