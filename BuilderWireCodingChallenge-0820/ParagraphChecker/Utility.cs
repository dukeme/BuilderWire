using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParagraphChecker
{
    public static class Utility
    {
        public static char ToChar(string text)
        {
            return Char.Parse(text);
        }

        public static bool IsUpper(string text)
        {
            if (Char.IsUpper(text[0]))
                return true;

            return false;
        }

        public static List<string> SplitText(string text)
        {
            List<string> list = text.Split(' ').ToList();
            return list;
        }

        public static List<string> SplitTextByChar(string text, string delimeter)
        {
            string[] stringSeparators = new string[] { delimeter };
            List<string> list = text.Split(stringSeparators, StringSplitOptions.None).ToList();

            return list;
        }

        public static string RemoveSpecialCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static string RemoveSpecialCharacters2(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
