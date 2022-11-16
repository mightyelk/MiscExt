using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MightyElk.MiscExt
{
    public static class ConsoleExt
    {
        public static void Write(ConsoleColor color, string format, params object[] args)
        {
            var oldCol = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(format, args);
            Console.ForegroundColor = oldCol;
        }

        public static void WriteLine(ConsoleColor color, string format, params object[] args)
        {
            Write(color, format+Environment.NewLine, args);
        }

        public static void WriteLine(ConsoleColor color, string text)
        {
            WriteLine(color, "{0}", text);
        }
    }
}
