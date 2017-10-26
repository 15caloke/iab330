using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StoragePal1.Validation {
    public static class Validation {
        public static bool ValidUsername(string username) {
            Regex regex = new Regex(@"^[a-z0-9]{6,20}$");
            return regex.IsMatch(username);
        }

        public static bool ValidEmail(string email) {
            Regex regex = new Regex(@"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$");
            return regex.IsMatch(email);
        }
    }
}
