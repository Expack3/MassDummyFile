using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MassDummyFile
{
    public class DummyOps
    {
        public static void MassDummyFile() //tests to see what kind of operation is needed
        {
            if (GlobalVars.restoreBak)
            {
                RestoreBaks();
            }
            else if (GlobalVars.makeBak)
            {
                DummyCreation(true);
            }
            else
            {
                DummyCreation(false);
            }
        }

        public static void RestoreBaks() //restores backed-up files created by this utility
        {
            string[] tempString;
            for (int i = 0; i < GlobalVars.fileArray.Length; i++)
            {
                if ((tempString = GlobalVars.fileArray[i].Split(new string[] {".bak"}, 2, StringSplitOptions.None)).Length == 2)
                {
                    if (File.Exists(tempString[0])) //File.Move doesn't work if tempString[0] already exists, so test for this
                        File.Delete(tempString[0]);
                    File.Move(GlobalVars.fileArray[i], tempString[0]);
                }
                tempString = null;
            }
        }

        public static void DummyCreation(bool BakFirst) //overrides pre-existing files with dummy files
        {
            string[] tempString;
            if (BakFirst)
            {
                for (int i = 0; i < GlobalVars.fileArray.Length; i++)
                {
                    if (GlobalVars.fileArray[i].Split(GlobalVars.fileExt, 2, StringSplitOptions.None).Length == 2)
                    {
                        string tempString2 = GlobalVars.fileArray[i];
                        File.Move(GlobalVars.fileArray[i], GlobalVars.fileArray[i] + ".bak");
                        GlobalVars.fileArray[i] = GlobalVars.fileArray[i] + ".bak";
                        File.Create(tempString2);
                    }
                }
            }
            else
            {
                for (int i = 0; i < GlobalVars.fileArray.Length; i++)
                {
                    if ((tempString = GlobalVars.fileArray[i].Split(GlobalVars.fileExt, 2, StringSplitOptions.None)).Length == 2)
                    {
                        File.Create(GlobalVars.fileArray[i]);
                    }
                    tempString = null;
                }
            }
        }
    }
}
