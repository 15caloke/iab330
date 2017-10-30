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

        private string roomName;
        public string RoomName {
            get { return roomName; }
            set {
                roomName = value;
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

        // Rooms model
        private string function;
        public string Function {
            get { return function; }
            set {
                function = value;
                OnPropertyChanged();
            }
        }

        private Users theUser;
        public Users TheUser {
            get { return theUser; }
            set {
                theUser = value;
                OnPropertyChanged();
            }
        }

        private Boxes theBox;
        public Boxes TheBox {
            get { return theBox; }
            set {
                theBox = value;
                OnPropertyChanged();
            }
        }

        private Items theItem;
        public Items TheItem {
            get { return theItem; }
            set {
                theItem = value;
                OnPropertyChanged();
            }
        }

        private Rooms room;
        public Rooms Room {
            get { return room; }
            set {
                room = value;
                OnPropertyChanged();
            }
        }

        public ICommand SubmitItemCommand { set; get; }
        public ICommand SubmitUserCommand { set; get; }
        public ICommand SubmitBoxCommand { set; get; }
        public ICommand SubmitRoomCommand { set; get; }

        public MainViewModel() {
            db = new Database();
            TheUser = new Users();
            TheBox = new Boxes();
            TheItem = new Items();
            Room = new Rooms();
            SubmitItemCommand = new Command(SubmitItems);
            SubmitUserCommand = new Command(SubmitUsers);
            SubmitBoxCommand = new Command(SubmitBox);
        }

        public void SubmitItems() {
            if (this.BoxNumber <= 0 || this.BoxNumber > 100) {
                Label lbl = new Label {
                    Text = "Cannot have excessive or illigitimate box numbers"
                };
            } else {
                db.Insert(new Items() {
                    Name = this.Name,
                    BoxId = TheBox.Id,
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
        public void SubmitRoom(Rooms room) {
            db.Insert(room);
        }

        public bool ValidateRoom(string roomName, int userId) {
            foreach (Rooms room in db.FetchAllRooms()) {
                if (room.Function == roomName && room.UserId == userId) {
                    return true;
                }
            }
            return false;
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

        public bool ValidateEmail(string email) {
            foreach (Users user in db.FetchAllUsers()) {
                if (email == user.Email) {
                    return false;
                }
            }
            return true;
        }

        public bool ValidateUsername(string username) {
            foreach (Users user in db.FetchAllUsers()) {
                if (username == user.Username) {
                    return false;
                }
            }
            return true;
        }

        public bool ValidateSignup(string email, string username) {
            bool isValid = false;
            foreach (Users user in db.FetchAllUsers()) {
                if (email != user.Email && username != user.Username) {
                    isValid = true;
                } else {
                    isValid = false;
                }
            }
            return isValid;
        }

        public bool BoxExist(int userId, int boxNumber) {
            foreach (Boxes box in db.FetchAllBoxes()) {
                if (userId == box.UserId && boxNumber == box.Number) {
                    return true;
                }
            }
            return false;
        }

        public void CreateUser(string email, string username, string password) {
            db.Insert(new Users() {
                Email = email,
                Username = username,
                Password = CalculateSha1Hash(username + password)
            });
        }

        public void GetUserId(Users user) {
            db.FetchUser(user.Id);
        }

        public Users GetTheUser(string username) {
            Users user;
            user = db.FetchUser(username);
            return user;
        }

        public Boxes GetTheBox(int boxNum, int userId) {
            Boxes box;
            box = db.FetchBox(boxNum, userId);
            return box;
        }

        public Rooms GetTheRoom(string function, int userId) {
            Rooms theRoom;
            theRoom = db.FetchRoom(function, userId);
            return theRoom;
        }

        public int GetBoxIdFromItem(Items item) {
            foreach (Boxes x in db.FetchAllBoxes()) {
                if (item.BoxNumber == x.Number) {
                    return x.Id;
                }
            }
            return 0;
        }

        public void SubmitTheItem(Items item) {
            db.Insert(item);
        }

        public void SubmiteTheBox(Boxes box) {
            db.Insert(box);
        }

        public void SubmitBox() {
            db.Insert(new Boxes() {
                UserId = ((int)Application.Current.Properties["userId"]),
                Number = Number,
                Category = Category,
                QRCode = QRCode,
                RoomName = this.RoomName,
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
