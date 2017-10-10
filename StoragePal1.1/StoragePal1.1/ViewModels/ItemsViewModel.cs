﻿using StoragePal1.Databases;
using StoragePal1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoragePal1 {
    public class ItemsViewModel : BaseViewModel {
        public readonly Database db;
        private ObservableCollection<Items> items;

        public ObservableCollection<Items> AllItems {
            get { return items; }
            set {
                items = value;
                OnPropertyChanged();
            }
        }

        public ItemsViewModel() {
            db = new Database();
            AllItems = new ObservableCollection<Items>(db.FetchAllItems());
        }
    }
}