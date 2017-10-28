using System;
using System.Collections.Generic;
using StoragePal1.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoragePal1.SubPages {
    public partial class AddNewItemPage : ContentPage {
        public AddNewItemPage() {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        //private void TapGestureRecognizer_Tapped(object sender, EventArgs e) {
        //    //var selectedItems = ((TapGestureRecognizer)sender).CommandParameter as Items;
        //    //var boxId = ((MainViewModel)BindingContext).Lmao(selectedItems);

        //    //var newItem = new Items() {
        //    //    Name = selectedItems.Name,
        //    //    BoxId = boxId,
        //    //    Description = selectedItems.Description,
        //    //    BoxNumber = selectedItems.BoxNumber,
        //    //    ImagePath = selectedItems.ImagePath,
        //    //};

        //    //((MainViewModel)BindingContext).SubmitTheItem(newItem);

        //    //Navigation.PopAsync(true);
        //}

        private void ToSubmit_Clicked(object sender, EventArgs e) {
            var selectedItem = ((MainViewModel)BindingContext).GetTheBox(Int32.Parse(boxNumber.Text));
            var userLoggedIn = (int)Application.Current.Properties["userId"];
            var boxNumInput = Int32.Parse(boxNumber.Text);

            if (!((MainViewModel)BindingContext).BoxExist(userLoggedIn, boxNumInput)) {
                DisplayAlert("Alert", "The box doesn't exist yet. Create a box in the box page", "Ok");
            } else {
                var newItem = new Items() {
                    Name = itemName.Text,
                    BoxId = selectedItem.Id,
                    UserId = ((int)Application.Current.Properties["userId"]),
                    Description = itemDescription.Text,
                    BoxNumber = Int32.Parse(boxNumber.Text),
                    ImagePath = "",
                };

                ((MainViewModel)BindingContext).SubmitTheItem(newItem);

                Navigation.PopAsync(true);
            }
        }
    }
}
