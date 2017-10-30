using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StoragePal1.Databases;
using StoragePal1.Models;

namespace StoragePal1.SubPages {
    /*
     * Views the selected items chosen from the previous page
     * and allows the user to change the binded data which will
     * update the entry in the database
     * 
     * Date: 29th October 2017
     */
    public partial class ViewSingleItemPage : ContentPage {
        private readonly Database db;
        public ViewSingleItemPage() {
            InitializeComponent();
            BindingContext = new MainViewModel();
            db = new Database();
        }

        protected override bool OnBackButtonPressed() {
            return base.OnBackButtonPressed();
        }

        private void SaveChangesButton_Clicked(object sender, EventArgs e) {
            var theItem = ((Button)sender).CommandParameter as Items;
            var userLoggedIn = ((int)Application.Current.Properties["userId"]);
            var belongedBox = db.FetchBox(theItem.BoxNumber, userLoggedIn);

            if (belongedBox == null) {
                DisplayAlert("Box Does Not Exist",
                    "The box you want to change to doesn't exist. Choose another number", "OK");
            } else {
                theItem.BoxId = belongedBox.Id;
                db.InsertOrUpdate(theItem);
                Navigation.PopAsync(true);
            }
        }
    }
}