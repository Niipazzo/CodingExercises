using Microsoft.VisualStudio.TestTools.UnitTesting;
using Niipazzo.DataStructures;
using Niipazzo.Exercises;
using System;

namespace Tests
{
    [TestClass]
    public class CheckPermutationTests
    {
        private const string TestClassName = "CheckPermutation";
        private const string TestStr = "iddqd";
        private const string PermuteTest = "iqddd";

        [TestMethod]
        public void String1Null()
        {
            var c = new CheckPermutation(null, TestStr);
            c.Solve();

            Assert.IsTrue(c.Result == false, $"Null value should return false");
        }

        [TestMethod]
        public void String2Null()
        {
            var c = new CheckPermutation(TestStr, null);
            c.Solve();

            Assert.IsTrue(c.Result == false, $"Null value should return false");
        }

        [TestMethod]
        public void BothNull()
        {
            var c = new CheckPermutation(null, null);
            c.Solve();

            Assert.IsTrue(c.Result == false, $"Null value should return false");
        }

        [TestMethod]
        public void BothEmpty()
        {
            var c = new CheckPermutation("", "");
            c.Solve();

            Assert.IsTrue(c.Result == false, $"Null value should return false");
        }

        [TestMethod]
        public void ValidPermutationTest()
        {
            var c = new CheckPermutation(TestStr, PermuteTest);
            c.Solve();

            Assert.IsTrue(c.Result == true, $"{PermuteTest} is permutation of {TestStr}. Should return true");
        }
    }
}
