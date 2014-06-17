using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MassDummyFile
{
    public class ExtValidator
    {
        public static bool validate(string ext)
        {
            foreach (char i in ext)
            {
                switch (i)
                {
                    case ' ':
                    case '.':
                    case ':':
                    case ',':
                    case '!':
                    case '<':
                    case '>':
                        return false;
                }
            }
            return true;
        }
    }
}
