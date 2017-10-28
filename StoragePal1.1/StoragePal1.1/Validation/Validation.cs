using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StoragePal1.Validation {
    public static class Validation {
        public static bool ValidUsername(string username) {
            if (username == null) {
                return false;
            }
            Regex regex = new Regex(@"^[A-Za-z0-9]{6,20}$");
            return regex.IsMatch(username);
        }

        public static bool ValidEmail(string email) {
            if (email == null) {
                return false;
            }
            Regex regex = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,6}$");
            return regex.IsMatch(email);
        }
        public static bool ValidPassword(string password) {
            if (password == null) {
                return false;
            }
            Regex regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            return regex.IsMatch(password);
        }
    }
}


/*
namespace StoragePal1.Validation {
    public static class Validation {
        public static bool ValidUsername(string username) {
            Regex regex = new Regex(@"^[A-Za-z0-9]{6,20}$");
            return regex.IsMatch(username);
        }

        public static bool ValidEmail(string email) {
            Regex regex = new Regex(@"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$");
            return regex.IsMatch(email);
        }
        public static bool ValidPassword(string password) {
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$");
            return regex.IsMatch(password);
        }
    }
}
*/
