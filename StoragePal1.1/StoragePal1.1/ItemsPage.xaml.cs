using System;
using System.Collections.Generic;
using StoragePal1.Databases;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoragePal1
{
    public partial class ItemsPage : ContentPage
    {
        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = new ItemsViewModel();
        }
        private void AddItemButtonClicked(Object sender, EventArgs e)
        {
            Navigation.PushAsync(new SubPages.AddNewItemPage());
        }
        protected override void OnAppearing (){
            BindingContext = new ItemsViewModel();
        }
        private void OnDeleteItem (Object sender, EventArgs e){
            BindingContext = new ItemsViewModel();
        }
    }
}