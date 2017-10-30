using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using StoragePal1.Droid;
using StoragePal1;

[assembly: Dependency(typeof(SaveAndLoad_Android))]
namespace StoragePal1.Droid {
    /*
     * Saves and Load exported data into a file in the 
     * file location specified for Android filesystem
     * 
     * Date: 29th October 2017
     */
    public class SaveAndLoad_Android : ISaveAndLoad {
        #region ISaveAndLoad implementation
        public async Task SaveTextAsync(string filename, string text) {
            var path = CreatePathToFile(filename);
            using (StreamWriter sw = File.CreateText(path))
                await sw.WriteAsync(text);
        }

        public async Task<string> LoadTextAsync(string filename) {
            var path = CreatePathToFile(filename);
            using (StreamReader sr = File.OpenText(path))
                return await sr.ReadToEndAsync();
        }

        public bool FileExists(string filename) {
            return File.Exists(CreatePathToFile(filename));
        }

        #endregion

        string CreatePathToFile(string filename) {
            var docsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(docsPath, filename);
        }
    }
}