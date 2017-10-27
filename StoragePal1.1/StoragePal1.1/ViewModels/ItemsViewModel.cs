using StoragePal1.Databases;
using StoragePal1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace StoragePal1 {
    public class ItemsViewModel : BaseViewModel {
        private readonly Database db;
        private ObservableCollection<Items> items;
        private ObservableCollection<Boxes> boxes;
        private Items selectedItem;
        private Boxes selectedBox;

        public ObservableCollection<Items> AllItems {
            get { return items; }
            set {
                items = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Boxes> AllBoxes {
            get { return boxes; }
            set {
                boxes = value;
                OnPropertyChanged();
            }
        }

        public Items SelectedItem {
            get { return selectedItem; }
            set {
                selectedItem = value;
                OnPropertyChanged();
            }
        }

        public Boxes SelectedBox {
            get { return selectedBox; }
            set {
                selectedBox = value;
                OnPropertyChanged();
            }
        }

        public ItemsViewModel() {
            db = new Database();
            AllItems = new ObservableCollection<Items>(db.FetchAllItems(((int)Application.Current.Properties["userId"])));
            AllBoxes = new ObservableCollection<Boxes>(db.FetchAllBoxes(((int)Application.Current.Properties["userId"])));
        }

        public void Delete(Items item) {
            db.Delete(item.Id);
        }

        public void Update(Items item) {
            db.InsertOrUpdate(item.Id);
        }

        public void Delete(Boxes box) {
            db.Delete(box);
        }
    }
}


