using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;
using System.Runtime.CompilerServices;

namespace Extension
{
    public static class VetExtensions
    {
        /// <summary>
        /// Return the last element of an array
        /// </summary>
        public static string Last(this string[] array)
        {
            return array[array.Length - 1];
        }
    }

    public static class ConsoleEx
    {
        /// <summary>
        /// Write a console line with green font
        /// </summary>
        public static void WriteLineGreen(string message, ConsoleColor defaultColor = ConsoleColor.White)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = defaultColor;
        }

        /// <summary>
        /// Write a console line with red font
        /// </summary>
        public static void WriteLineRed(string message, ConsoleColor defaultColor = ConsoleColor.White)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ForegroundColor = defaultColor;
        }

        /// <summary>
        /// Write a console line with personal font
        /// </summary>
        public static void WriteLineColoured(string message, ConsoleColor color, ConsoleColor defaultColor = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = defaultColor;
        }
    }

}
