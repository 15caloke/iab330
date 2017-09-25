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
    public class Database {
        static SQLiteConnection database;

        public Database() {
            database = new SQLiteConnection(DependencyService.Get<ISQLitePlatform>(),
                DependencyService.Get<IFilePath>().GetFilePath("StoragePal.db"));
            database.CreateTable<Users>();
        }

        public int Insert(Users users) {
            var user = database.Insert(users);
            database.Commit();
            return user;
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
            return num;
        }

        public List<Users> FetchAllUsers() {
            return database.Table<Users>().ToList();
        }

        public Users FetchUser(int key) {
            return database.Table<Users>().Where(entry => entry.Id == key).FirstOrDefault();
        }
    }
}
