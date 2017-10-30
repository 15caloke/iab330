using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StoragePal1.Validation {
    /*
     * Class for validating input fields, mainly used for users logging in
     * and signing up
     * 
     * Date: 29th October 2017
     */
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
