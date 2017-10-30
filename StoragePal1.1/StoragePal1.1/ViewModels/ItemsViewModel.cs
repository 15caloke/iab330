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
        private ObservableCollection<Rooms> rooms;
        private Items selectedItem;
        private Boxes selectedBox;
        private Rooms selectedRoom;
        private int counter;

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

        public ObservableCollection<Rooms> AllRooms {
            get { return rooms; }
            set {
                rooms = value;
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

        public Rooms SelectedRoom {
            get { return selectedRoom; }
            set {
                selectedRoom = value;
                OnPropertyChanged();
            }
        }

        public ItemsViewModel() {
            var userLoggedin = ((int)Application.Current.Properties["userId"]);
            counter = 0;
            db = new Database();
            AllItems = new ObservableCollection<Items>(db.FetchAllItems(userLoggedin));
            AllBoxes = new ObservableCollection<Boxes>(db.FetchAllBoxes(userLoggedin));
            AllRooms = new ObservableCollection<Rooms>(db.FetchAllRooms(userLoggedin));
        }

        public int GetCounter() {
            return counter;
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

        public void Delete(Rooms room) {
            db.Delete(room);
        }
    }
}


