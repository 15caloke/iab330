using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoragePal1.SubPages {
    public partial class AddBoxPage : ContentPage {
        public AddBoxPage() {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void SubmitBox_Clicked(object sender, EventArgs e) {
            Navigation.PopAsync(true);
        }
    }
}