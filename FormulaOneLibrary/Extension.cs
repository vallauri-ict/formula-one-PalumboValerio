using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NormalExtension
{
    public static class VetExtensions
    {
        /// <summary>
        /// return the last element of an array
        /// </summary>
        /// <returns></returns>
        public static string Last(this string[] array)
        {
            return array[array.Length - 1];
        }
    }
}
