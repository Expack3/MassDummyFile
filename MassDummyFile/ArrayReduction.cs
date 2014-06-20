using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;

namespace MassDummyFile
{
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
