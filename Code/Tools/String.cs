using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Niipazzo.Tools
{
    public class String
    {
        public const string Alphanumeric = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string RandomString(string validChars, int length)
        {
            var random = new Random();
            return new string (Enumerable.Repeat(validChars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
}
}
