using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardTrainer.Models
{
    internal static class SourceString
    {

        private static string source = "mama mama mama mama mama";
        private static int current = 0;

        public static string Source => source.Substring(current);

        public static char Next => source[current];
        public static bool HasNext => current < source.Length - 1;
        public static void Move()
        {
            ++current;
        }
    }
}