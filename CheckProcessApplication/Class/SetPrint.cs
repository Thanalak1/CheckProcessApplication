using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPM
{
    public static class SetPrint
    {
        private static string ConcatNewLine(List<string> str)
        {
            int i = 0;
            string text = "";
            for (; str.Count != i; i++)
            {
                text = text + "'" + str[i] + "'";
                if (i < str.Count - 1)
                {
                    text += "+ chr(30) +";
                }
            }

            return text;
        }

        public static string SetString(string str)
        {
            List<string> list = new List<string>();
            while (str.Contains("\n"))
            {
                int num = str.IndexOf("\n");
                list.Add(str.Substring(0, num));
                str = str.Substring(num + 1, str.Length - num - 2);
            }

            if (list.Count != 0)
            {
                list.Add(str);
                str = ConcatNewLine(list);
            }

            if (str.Contains("chr(13)"))
            {
                return str;
            }

            if (str.Contains("chr(30)"))
            {
                return str;
            }

            return new StringBuilder("'").Append(str).Append("'").ToString();
        }

    }
}
