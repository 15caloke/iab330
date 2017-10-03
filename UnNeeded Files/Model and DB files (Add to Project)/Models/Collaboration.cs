using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoragePal1.Models {
    /*
     * Nice-to-Have Feature: 
     * "Cloud synchronisation to allow multiple users to see the same data"
     * Local Integration
     */
    public class Collaboration {

        [ForeignKey(typeof(Users))]
        public int UserId { get; set; }

        [ForeignKey(typeof(Boxes))]
        public int BoxId { get; set; }
    }
}
