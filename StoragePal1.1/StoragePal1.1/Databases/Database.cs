using SQLite.Net;
using SQLite.Net.Interop;
using StoragePal1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StoragePal1.Databases {
    /*
     * Create the database using the models and SQLite Dependency Service
     * database file is stored in emulator's filesystem
     * 
     * Date: 29th October 2017
     */
    public class Database {
        static SQLiteConnection database;

        /// <summary>
        /// Creates a new SQLite database connection and
        /// tables using the models and their fields
        /// </summary>
        public Database() {
            database = new SQLiteConnection(DependencyService.Get<ISQLitePlatform>(),
                DependencyService.Get<IFilePath>().GetFilePath("StoragePal1_1.db3"));
            database.CreateTable<Users>();
            database.CreateTable<Boxes>();
            database.CreateTable<Items>();
            database.CreateTable<Rooms>();
        }

        public int Insert(Users users) {
            var user = database.Insert(users);
            database.Commit();
            return user;
        }

        public int Insert(Boxes boxes) {
            var box = database.Insert(boxes);
            database.Commit();
            return box;
        }

        public int Insert(Items items) {
            var item = database.Insert(items);
            database.Commit();
            return item;
        }

        public int Insert(Rooms rooms) {
            var room = database.Insert(rooms);
            database.Commit();
            return room;
        }

        public int InsertOrUpdate(int id) {
            int num;
            if (database.Table<Items>().Any(entry => entry.Id == id)) {
                num = database.Update(id);
            } else {
                num = database.Insert(id);
            }
            database.Commit();
            return num;
        }

        public int InsertOrUpdate(Items item) {
            int num;
            if (database.Table<Items>().Any(entry => entry.Id == item.Id)) {
                num = database.Update(item);
            } else {
                num = database.Insert(item);
            }
            database.Commit();
            return num;
        }

        public int InsertOrUpdate(Boxes boxes) {
            int num;
            if (database.Table<Boxes>().Any(entry => entry.Id == boxes.Id)) {
                num = database.Update(boxes);
            } else {
                num = database.Insert(boxes);
            }
            database.Commit();
            return num;
        }

        public int InsertOrUpdate(Users users) {
            int num;
            if (database.Table<Users>().Any(entry => entry.Id == users.Id)) {
                num = database.Update(users);
            } else {
                num = database.Insert(users);
            }
            database.Commit();
            return num;
        }

        public int InsertOrUpdate(Rooms room) {
            int num;
            if (database.Table<Rooms>().Any(entry => entry.Id == room.Id)) {
                num = database.Update(room);
            } else {
                num = database.Insert(room);
            }
            database.Commit();
            return num;
        }

        public int Delete(Users users) {
            int num;
            num = database.Delete<Users>(users.Id);
            database.Commit();
            return num;
        }

        public int Delete(Boxes boxes) {
            int num;
            num = database.Delete<Boxes>(boxes.Id);
            database.Commit();
            return num;
        }

        public int Delete(Rooms rooms) {
            int num;
            num = database.Delete<Rooms>(rooms.Id);
            database.Commit();
            return num;
        }

        public int Delete(int id) {
            int num;
            num = database.Delete<Items>(id);
            database.Commit();
            return num;
        }

        public List<Users> FetchAllUsers() {
            return database.Table<Users>().ToList();
        }

        public List<Boxes> FetchAllBoxes() {
            return database.Table<Boxes>().ToList();
        }

        public List<Boxes> FetchAllBoxes(int user) {
            return database.Table<Boxes>().Where(boxes => boxes.UserId == user).ToList();
        }

        public List<Items> FetchAllItems() {
            return database.Table<Items>().ToList();
        }

        public List<Rooms> FetchAllRooms() {
            return database.Table<Rooms>().ToList();
        }

        public List<Rooms> FetchAllRooms(int user) {
            return database.Table<Rooms>().Where(rooms => rooms.UserId == user).ToList();
        }

        public List<Items> FetchAllItems(int user) {
            return database.Table<Items>().Where(items => items.UserId == user).ToList();
        }

        public Users FetchUser(int key) {
            return database.Table<Users>().Where(entry => entry.Id == key).FirstOrDefault();
        }

        public Users FetchUser(string username) {
            return database.Table<Users>().Where(entry => entry.Username == username).FirstOrDefault();
        }

        public Boxes FetchBox(int boxNum) {
            return database.Table<Boxes>().Where(entry => entry.Number == boxNum).FirstOrDefault();
        }

        public Boxes FetchBox(int boxNum, int userId) {
            return database.Table<Boxes>().Where(entry => entry.Number == boxNum && entry.UserId == userId).FirstOrDefault();
        }

        public Items FetchItem(int key) {
            return database.Table<Items>().Where(entry => entry.Id == key).FirstOrDefault();
        }

        public Rooms FetchRoom(int key) {
            return database.Table<Rooms>().Where(entry => entry.Id == key).FirstOrDefault();
        }

        public Rooms FetchRoom(string function) {
            return database.Table<Rooms>().Where(entry => entry.Function == function).FirstOrDefault();
        }

        public Rooms FetchRoom(string function, int userId) {
            return database.Table<Rooms>().Where(entry => entry.Function == function && entry.UserId == userId).FirstOrDefault();
        }
    }
}
