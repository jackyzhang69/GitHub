using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Immigration.Utility
{
    class StringOps
    {
        public static string[] sep(string s, char c)  // seperate one string to two with a char
        {
            string[] outnew = new string[2];
            int l = s.IndexOf(c);
            if(l > 0)
            {
                outnew[0] = s.Substring(0, l);
                if(s.Length > l) outnew[1] = s.Substring(l + 1, s.Length - l - 1);
                else outnew[1] = "";
                return outnew;
            }
            else
            {
                outnew[0] = "";
                if(s.Length > 0) outnew[1] = s.Substring(l + 1, s.Length - l - 1);
                else outnew[1] = "";
                return outnew;
            }
        }

    }
}
