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
    public partial class ViewSingleItemPage : ContentPage {
        private readonly Database db;
        public ViewSingleItemPage() {
            InitializeComponent();
            BindingContext = new MainViewModel();
            db = new Database();
        }

        private void SaveChangesButton_Clicked(object sender, EventArgs e) {
            var theItem = ((Button)sender).CommandParameter as Items;
            var belongedBox = db.FetchBox(theItem.BoxNumber);
            theItem.BoxId = belongedBox.Id;
            db.InsertOrUpdate(theItem);

            // Need to make it not crash when save chnages is made (pops to login to prevent crashing)
            Navigation.PopToRootAsync(true);
        }
    }
}