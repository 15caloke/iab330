using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoragePal1 {
    /*
     * Interface that contains a method to
     * retrieve an inputted filename
     * 
     * Date: 29th October 2017
     */
    public interface IFilePath {
        string GetFilePath(string filename);
    }
}
