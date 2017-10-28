using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoragePal1.Databases;
using StoragePal1.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoragePal1.SubPages {
    public partial class ViewSingleBoxPage : ContentPage {
        private readonly Database db;
        public ViewSingleBoxPage() {
            InitializeComponent();
            db = new Database();
        }
        private void SaveChangesButton_Clicked(object sender, EventArgs e) {
            var theBox = ((Button)sender).CommandParameter as Boxes;
            db.InsertOrUpdate(theBox);

            // Need to make it not crash when save chnages is made (pops to login to prevent crashing)
            Navigation.PopAsync(true);
        }
    }
}