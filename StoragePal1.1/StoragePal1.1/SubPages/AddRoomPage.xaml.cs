using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoragePal1.SubPages {
    public partial class AddRoomPage : ContentPage {
        public AddRoomPage() {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void SubmitRoom_Clicked(object sender, EventArgs e) {
            Navigation.PopAsync(true);
        }
    }
}