﻿using SQLite.Net;
using SQLite.Net.Interop;
using StoragePal1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StoragePal1.Databases {
    public class Database {
        static SQLiteConnection database;

        public Database() {
            database = new SQLiteConnection(DependencyService.Get<ISQLitePlatform>(),
                DependencyService.Get<IFilePath>().GetFilePath("StoragePal1.db3"));
            database.CreateTable<Users>();
            database.CreateTable<Boxes>();
            database.CreateTable<Items>();
            //database.CreateTable<Collaboration>();
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

        //public int InsertOrUpdate(Items items) {
        //    int num;
        //    if (database.Table<Items>().Any(entry => entry.Id == items.Id)) {
        //        num = database.Update(items);
        //    } else {
        //        num = database.Insert(items);
        //    }
        //    database.Commit();
        //    return num;
        //}

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

        public List<Items> FetchAllItems(int user) {
            return database.Table<Items>().Where(items => items.UserId == user).ToList();
        }

        //public List<Collaboration> FetchAllCollab() {
        //    return database.Table<Collaboration>().ToList();
        //}

        public Users FetchUser(int key) {
            return database.Table<Users>().Where(entry => entry.Id == key).FirstOrDefault();
        }

        public Users FetchUser(string username) {
            return database.Table<Users>().Where(entry => entry.Username == username).FirstOrDefault();
        }

        public Boxes FetchBox(int boxNum) {
            return database.Table<Boxes>().Where(entry => entry.Number == boxNum).FirstOrDefault();
        }

        public Items FetchItem(int key) {
            return database.Table<Items>().Where(entry => entry.Id == key).FirstOrDefault();
        }

        //public Collaboration FetchCollab(int key) {
        //    return database.Table<Collaboration>().Where(entry => entry.BoxId == key || entry.UserId == key).FirstOrDefault();
        //}
    }
}
