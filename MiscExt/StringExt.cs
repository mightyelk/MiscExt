using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace System.Text
{
    public static class StringExt
    {
        public static string PrintF(this string s, params object[] arg0)
        {
            Regex r = new Regex("({[sfd]+[:]{0,1}[0-9\\.]*})");
            MatchCollection matches = r.Matches(s);

            string ret = "";
            int idx = 0;
            int pos = 0;

            foreach (Match m in matches)
            {
                ret += s.Substring(pos, m.Index - pos);
                string f = "{0}";
                if (m.Value.Substring(1, 1) == "f")
                {
                    if (m.Value == "{f}")
                        f = "{0}";
                    else
                    {
                        int start = m.Value.IndexOf(":") + 1;
                        int end = m.Value.IndexOf("}") - start;
                        f = "{0:" + m.Value.Substring(start, end) + "}";
                    }
                }
                ret += string.Format(f, arg0[idx]);

                pos = m.Index + m.Length;
                idx++;
            }
            return ret;

        }

        public static string[] Split(this string text, string seperator)
        {
            return text.Split(new string[] { seperator }, StringSplitOptions.RemoveEmptyEntries);
        }
        public static string RemoveAny(this string str, params char[] oldChar)
        {
            foreach (char c in oldChar)
            {
                str = str.Replace(c.ToString(), "");
            }
            return str;
        }

        public static string RemoveAny(this string str, params string[] oldStr)
        {
            foreach (var s in oldStr)
            {
                str = str.Replace(s, "");
            }
            return str;
        }


        /// <summary>
        /// Reverses a string -> abcd becomes dcba
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Reverse(this string s)
        {
            char[] cArray = s.ToCharArray();
            Array.Reverse(cArray);
            return new string(cArray);
        }

        /// <summary>
        /// Returns part of string between a and b.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string Between(this string x, string a, string b)
        {
            if (!x.Contains(a) | !x.Contains(b)) return x;
            int start, ende;

            start = x.IndexOf(a) + a.Length;

            ende = x.IndexOf(b, start);


            return x.Substring(start, ende - start).Trim();
        }


        /// <summary>
        /// Cuts of cutOffCount charactes from the end
        /// </summary>
        /// <param name="s"></param>
        /// <param name="cutOffCount"></param>
        /// <returns></returns>
        public static string Cutoff(this string s, int cutOffCount)
        {
            if (cutOffCount > s.Length)
                throw new IndexOutOfRangeException("cutOffCount > than length of string.");
            return s.Substring(0, s.Length - cutOffCount);
        }


        /// <summary>
        /// Replaces all occurences of replace[] with replaceWith
        /// </summary>
        /// <param name="s"></param>
        /// <param name="replace">array of strings to look for</param>
        /// <param name="replaceWith">replace string</param>
        /// <returns></returns>
        public static string ReplaceAll(this string s, string[] replace, string replaceWith)
        {
            if (s is null)
                return null;

            foreach (string x in replace)
                s = s.Replace(x, replaceWith);

            return s;
        }

        /// <summary>
        /// Returns if any entry of search is in string.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="search">Array of strings to search for</param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static bool ContainsAny(this string s, string[] search, bool ignoreCase)
        {

            if (ignoreCase)
            {
                for (int i = 0; i < search.Length; i++)
                    if (s.ToLower().Contains(search[i].ToLower()))
                        return true;

            }
            else
            {
                for (int i = 0; i < search.Length; i++)
                    if (s.Contains(search[i]))
                        return true;
            }

            return false;
        }

        public static System.IO.MemoryStream AsMemoryStream(this string s)
        {
            var stream = new System.IO.MemoryStream();
            var writer = new System.IO.StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }


        public static bool EndsWithAny(this string s, string[] search, bool ignoreCase)
        {
            for (int i = 0; i < search.Length; i++)
            {
                if (ignoreCase & s.ToLower().EndsWith(search[i].ToLower())
                    | !ignoreCase & s.EndsWith(search[i]))
                    return true;
            }
            return false;
        }

        public static bool StartsWithAny(this string s, string[] search, bool ignoreCase)
        {
            for (int i = 0; i < search.Length; i++)
            {
                if (ignoreCase & s.ToLower().StartsWith(search[i].ToLower())
                    | !ignoreCase & s.StartsWith(search[i]))
                    return true;
            }
            return false;
        }

    }
}
