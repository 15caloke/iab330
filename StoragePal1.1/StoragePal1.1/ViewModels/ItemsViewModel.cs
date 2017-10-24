﻿using StoragePal1.Databases;
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

        public Items SingleItem {
            get { return selectedItem; }
            set {
                selectedItem = value;
                OnPropertyChanged();
            }
        }

        Boxes box;
        public Boxes SelectedBox {
            get { return box; }
            set {
                box = value;
                OnPropertyChanged();
            }
        }

        public ItemsViewModel() {
            db = new Database();
            AllItems = new ObservableCollection<Items>(db.FetchAllItems());
            AllBoxes = new ObservableCollection<Boxes>(db.FetchAllBoxes());
        }

        public void Delete(Items item) {
            db.Delete(item.Id);
        }
    }
}


