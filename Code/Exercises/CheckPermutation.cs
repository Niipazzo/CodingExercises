using System;
using System.Linq;

namespace Niipazzo.Exercises
{
    /// 1.2 Check Permutation: Given two strings, write a method to decide if one is a permutation of the other.
    /// 
    /// From book: Cracking coding interview by Gayle Laakmann 2016
    /// Page: 193
    public class CheckPermutation : IExercise
    {
        public string String1 { get; private set; }
        public string String2 { get; private set; }
        public bool Result { get; private set; }
        public CheckPermutation(string string1, string string2)
        {
            String1 = string1;
            String2 = string2;
        }

        public void Render()
        {
            throw new NotImplementedException();
        }

        public void Solve()
        {
            if (CommonChecks())
            {
                Result = false;
                Solve1();
            }
            
        }

        /// <summary>
        /// returns true if all checks pass, otherwise false
        /// </summary>
        /// <returns></returns>
        private bool CommonChecks()
        {
            if (string.IsNullOrWhiteSpace(String1) || string.IsNullOrWhiteSpace(String2))
                return false;

            if (String1.Length != String2.Length)
                return false;

            return true;
        }

        //Using sequenceEqual
        private void Solve1()
        {
            var chars1 = String1.ToCharArray();
            var chars2 = String2.ToCharArray();

            Array.Sort(chars1);
            Array.Sort(chars2);

            Result = chars1.SequenceEqual(chars2);
        }
    }
}
