using Microsoft.VisualStudio.TestTools.UnitTesting;
using Niipazzo.DataStructures;
using Niipazzo.Exercises;
using System;

namespace Tests
{
    [TestClass]
    public class IsUniqueTests
    {
        private const string TestClassName = "IsUnique";

        [TestMethod]
        public void StringNull()
        {
            var c = new IsUnique(null);
            c.Solve();

            Assert.IsTrue(c.Result == true, $"Null string should return true");
        }

        [TestMethod]
        public void StringEmpty()
        {
            var c = new IsUnique("");
            c.Solve();

            Assert.IsTrue(c.Result == true, $"Empty string should return true");
        }

        [TestMethod]
        public void StringSingleChar()
        {
            var c = new IsUnique("a");
            c.Solve();

            Assert.IsTrue(c.Result == true, $"single char string should return true");
        }

        [TestMethod]
        public void StringTwoUniqueChars()
        {
            var c = new IsUnique("ab");
            c.Solve();

            Assert.IsTrue(c.Result == true, $"single char string should return true");
        }

        [TestMethod]
        public void StringTwoDublicateChars()
        {
            var c = new IsUnique("aa");
            c.Solve();

            Assert.IsTrue(c.Result == false, $"single char string should return true");
        }
    }
}
