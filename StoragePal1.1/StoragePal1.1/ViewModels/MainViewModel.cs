using SQLite.Net;
using StoragePal1.Databases;
using StoragePal1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace StoragePal1 {
    public class MainViewModel : BaseViewModel {
        public Database db; // readonly

        private string name;

        public string Name {
            get { return name; }
            set {
                name = value;
                OnPropertyChanged();
            }
        }
        private string description;

        public string Description {
            get { return description; }
            set {
                description = value;
                OnPropertyChanged();
            }
        }

        private int boxNumber;

        public int BoxNumber {
            get { return boxNumber; }
            set {
                boxNumber = value;
                OnPropertyChanged();
            }
        }

        private string imagePath;

        public string ImagePath {
            get { return imagePath; }
            set {
                imagePath = value;
                OnPropertyChanged();
            }
        }
        public ICommand SubmitCommand { set; get; }
        public MainViewModel() {
            db = new Database();
            SubmitCommand = new Command(Submit);
        }

        public void Submit() {
            db.Insert(new Items() {
                Name = this.Name,
                Description = Description,
                BoxNumber = BoxNumber,
                ImagePath = ImagePath
            });
            Name = String.Empty;
            Description = String.Empty;
            BoxNumber = 0;
            ImagePath = String.Empty;
        }
    }
}
