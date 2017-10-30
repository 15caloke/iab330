using System;
using StoragePal1;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StoragePal1 {
    /*
     * Interface for loading .txt files and saving/writing
     * data into a .txt file, each method is asynchronous
     * 
     * Date: 29th October 2017
     */
    public interface ISaveAndLoad {
        Task SaveTextAsync(string filename, string text);
        Task<string> LoadTextAsync(string filename);
        bool FileExists(string filename);
    }
}
