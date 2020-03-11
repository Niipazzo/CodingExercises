using System;
using System.Collections.Generic;
using System.Text;

namespace Niipazzo.Exercises.One
{
    /// 1.3 Write a method to replace all spaces in a string with '%20: You may assume that the string
    ///     has sufficient space at the end to hold the additional characters, and that you are given the "true"
    ///     length of the string. (Note: If implementing in Java, please use a character array so that you can
    ///     perform this operation in place.) 
    ///
    /// From book: Cracking coding interview by Gayle Laakmann 2016
    /// Page: 194
    public static class URLify
    {
        public static string Urlify(this string str, int trueLength)
        {
            return str.Substring(0, trueLength).Replace(" ", "%20");
        }
    }
}
