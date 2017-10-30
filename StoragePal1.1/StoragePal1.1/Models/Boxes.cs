using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoragePal1.Models {
    /*
     * A model for Boxes which store items
     * and are owned by a user, as their ID
     * will be used to determine which box
     * is owned by which user
     * 
     * Date: 29th October 2017
     */
    public class Boxes {

        [PrimaryKey]
        [AutoIncrement]
        //[NotNull]
        public int Id { get; set; }

        [ForeignKey(typeof(Users))]
        //[NotNull]
        public int UserId { get; set; }

        [ForeignKey(typeof(Rooms))]
        public int RoomId { get; set; }

        //[NotNull]
        public int Number { get; set; }

        public string Category { get; set; }

        //[NotNull]
        public string RoomName { get; set; }

        public string QRCode { get; set; }
    }
}
