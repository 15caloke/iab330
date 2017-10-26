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
using PCLCrypto;

namespace StoragePal1 {
    public class MainViewModel : BaseViewModel {
        private readonly Database db;

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

        // Users
        private string email;

        public string Email {
            get { return email; }
            set {
                email = value;
                OnPropertyChanged();
            }
        }

        private string password;

        public string Password {
            get { return password; }
            set {
                password = value;
                OnPropertyChanged();
            }
        }

        private string username;

        public string Username {
            get { return username; }
            set {
                username = value;
                OnPropertyChanged();
            }
        }

        // Boxes
        private int number;
        public int Number {
            get { return number; }
            set {
                number = value;
                OnPropertyChanged();
            }
        }

        private string category;
        public string Category {
            get { return category; }
            set {
                category = value;
                OnPropertyChanged();
            }
        }

        private string qrCode;
        public string QRCode {
            get { return qrCode; }
            set {
                qrCode = value;
                OnPropertyChanged();
            }
        }

        public ICommand SubmitItemCommand { set; get; }
        public ICommand SubmitUserCommand { set; get; }
        public ICommand SubmitBoxCommand { set; get; }
        public ICommand ValidateUserCommand { set; get; }

        public ICommand UpdateSelectedItemCommand { set; get; }


        public MainViewModel() {
            db = new Database();
            SubmitItemCommand = new Command(SubmitItems);
            SubmitUserCommand = new Command(SubmitUsers);
            SubmitBoxCommand = new Command(SubmitBox);
        }

        public void SubmitItems() {
            if (this.BoxNumber <= 0 || this.BoxNumber > 100) { // modify number
                Label lbl = new Label {
                    Text = "Cannot have excessive or illigitimate box numbers"
                };
            } else {
                db.Insert(new Items() {
                    Name = this.Name,
                    Description = this.Description,
                    BoxNumber = this.BoxNumber,
                    ImagePath = this.ImagePath
                });
                Name = String.Empty;
                Description = String.Empty;
                BoxNumber = 0;
                ImagePath = String.Empty;
            }
        }

        public void UpdateTheItem(Items item) {
            db.InsertOrUpdate(item.Id);
        }

        public void SubmitUsers() {
            db.Insert(new Users() {
                Email = Email,
                Username = Username,
                Password = CalculateSha1Hash(Username + Password) // email concatenated with password for salt value
            });
            Email = String.Empty;
            Username = String.Empty;
            Password = String.Empty;
        }

        public bool ValidateUser(string username, string password) {
            bool isValidated = false;
            foreach (Users x in db.FetchAllUsers()) {
                if (x.Username == username && x.Password == CalculateSha1Hash(username + password)) {
                    isValidated = true;
                    break;
                } else {
                    isValidated = false;
                }
            }
            return isValidated;
        }

        public bool ValidateSignup(string email, string username) {
            bool isValid = false;
            foreach (Users user in db.FetchAllUsers()) {
                if (email != user.Email && username != user.Username) { // may need to change to || ?
                    isValid = true;
                } else {
                    isValid = false;
                }
            }
            return isValid;
        }

        public void CreateUser(string email, string username, string password) {
            db.Insert(new Users() {
                Email = email,
                Username = username,
                Password = CalculateSha1Hash(password)
            });
        }

        public void SubmitBox() {
            db.Insert(new Boxes() {
                Number = Number,
                Category = Category,
                QRCode = QRCode
            });
            Number = 0;
            Category = String.Empty;
            QRCode = String.Empty;
        }

        private static string CalculateSha1Hash(string input) {
            // step 1, calculate MD5 hash from input
            var hasher = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha1);
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = hasher.HashData(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++) {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
