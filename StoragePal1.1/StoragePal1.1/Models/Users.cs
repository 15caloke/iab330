using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoragePal1.Models {
    public class Users {

        [PrimaryKey]
        [AutoIncrement]
        [NotNull]
        public int Id { set; get; }

        [NotNull]
        public string FirstName { set; get; }

        [NotNull]
        public string LastName { set; get; }

        [NotNull]
        public string Email { set; get; }

        [NotNull]
        public string Password { set; get; }
    }
}
