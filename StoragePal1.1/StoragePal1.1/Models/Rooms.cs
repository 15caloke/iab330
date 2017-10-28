using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace StoragePal1.Models {
    public class Rooms {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Users))]
        public int UserId { get; set; }

        //[ForeignKey(typeof(Boxes))]
        //public int BoxId { get; set; }

        public string Function { get; set; }

        //// MAY NEED TO CHANGE TO SINGULAR?
        //public int BoxNums { get; set; }

    }
}
