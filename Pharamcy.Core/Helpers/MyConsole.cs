using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Core.Helpers
{
    public class MyConsole
    {
        public static void WriteLine(object text, ConsoleColor color = ConsoleColor.DarkYellow)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void Write(object text, ConsoleColor color = ConsoleColor.DarkYellow)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
            Console.WriteLine("");
        }

        public static void WriteFormat(string text, ConsoleColor color = ConsoleColor.DarkYellow)
        {
            Console.ForegroundColor = color;
            foreach (var item in text)
            {
                Thread.Sleep(200);
                Console.Write(item);

            }
            Console.WriteLine("");
            Console.ResetColor();
        }
    }
}
