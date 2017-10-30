using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;

namespace StoragePal1.Droid {
    /*
     * Gets the file location path on the Android filesystem
     * 
     * Date: 29th October 2017
     */
    public class FilePathDroid : IFilePath {
        public string GetFilePath(string filename) {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}