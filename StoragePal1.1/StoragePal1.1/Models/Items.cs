﻿using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoragePal1.Models {
    public class Items {

        //[NotNull]
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Boxes))]
        //[NotNull]
        public int BoxId { get; set; }

        [ForeignKey(typeof(Users))]
        public int UserId { get; set; }

        //[NotNull]
        public string Name { get; set; }

        public string Description { get; set; }

        //[NotNull]
        public int BoxNumber { get; set; }

        public string ImagePath { get; set; }
    }
}
