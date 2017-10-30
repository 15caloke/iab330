using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace StoragePal1.Models {
    /* Model for Rooms that contain Boxes and
     * use the Users' ID as a foreign key
     * to display Rooms created by the user
     * 
     * Date: 29th October 2017
     */
    public class Rooms {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Users))]
        public int UserId { get; set; }

        public string Function { get; set; }
    }
}
