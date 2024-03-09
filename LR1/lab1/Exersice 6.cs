using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab1
{
    public static class Exersice_6
    {
        public static string RemoveRussianLetters(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            string result = new string(input.Where(c => (c < 'а' || c > 'я') && (c < 'А' || c > 'Я')).ToArray());

            return result;
        }
    }
}
