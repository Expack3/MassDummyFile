using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MassDummyFile
{
    public class GlobalVars
    {
        public static List<string> fileArray = null; //stores a listing of all files in a directory.
        public static string directory = null; //stores the directory path
        public static string[] fileExt = new string[1]; //stores the desired file extension
        public static bool restoreBak = false; //does the user want to restore backup files made by this utility?
        public static bool makeBak = false; // does the user want to backup dummied files pre-dummying?
        public static bool extValid = false;
        public static bool reloadDir = false; //tells the application whether fileArray needs to be updated
    }
}
