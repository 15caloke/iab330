using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoragePal1.Models {
    /*
     * A Model for the User table in the database with
     * each getter/setter method being a field
     * 
     * Date: 29th October 2017
     */
    public class Users {

        [PrimaryKey]
        [AutoIncrement]
        //[NotNull]
        public int Id { set; get; }

        //[NotNull]
        public string Email { set; get; }

        //[NotNull]
        public string Username { set; get; }

        //[NotNull]
        public string Password { set; get; }
    }
}
