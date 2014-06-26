using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;

namespace MassDummyFile
{
    /// <summary>
    /// A class containing functions designed to optimize a list of files based on the globally-stored file extension
    /// </summary>
    public class ArrayReduction
    {

        static bool useBak; //use .bak as the extension instead of the globally-stored file extension?
        public ArrayReduction()
        {
            useBak = false;
        }

        public ArrayReduction(bool Bak)
        {
            useBak = Bak;
        }

        /// <summary>
        /// Given a BackgroundWorker thread and a DoWorkEventArgs class, find all the files in the globally-stored directory location which match the globally-stored file extension and return the result. 
        /// </summary>
        /// <param name="worker"></param>
        /// <param name="e"></param>
        public void reduce(BackgroundWorker worker, DoWorkEventArgs e)
        {
            string[] temp = Directory.GetFiles(GlobalVars.directory);
            worker.ReportProgress(100, Array.FindAll(temp, hasExt).ToList<string>());
        }

        static bool hasExt(String s)
        {
            if (useBak != true)
                return s.Contains("." + GlobalVars.fileExt[0]);
            return s.Contains(".bak");
        }
    }
}
