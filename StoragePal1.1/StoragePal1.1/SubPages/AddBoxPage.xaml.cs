using StoragePal1.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoragePal1.SubPages {
    public partial class AddBoxPage : ContentPage {
        private Database db;
        public AddBoxPage() {
            InitializeComponent();
            BindingContext = new MainViewModel();

        }

        private void SubmitBox_Clicked(object sender, EventArgs e) {
            if ((((MainViewModel)BindingContext).BoxExist((int)Application.Current.Properties["userId"], Int32.Parse(boxNumber.Text)))) {
                DisplayAlert("Already exist", "The box you want to create is already exist. Please enter a different number","OK");
            }
            else {
                ((MainViewModel)BindingContext).SubmitBox();
                Navigation.PopAsync(true);
            }
        }
    }
}