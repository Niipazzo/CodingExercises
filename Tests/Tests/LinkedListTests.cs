using Microsoft.VisualStudio.TestTools.UnitTesting;
using Niipazzo.DataStructures;

namespace Tests
{
    [TestClass]
    public class LinkedListTests
    {
        private const string TestClassName = "LinkedList";

        private LinkedList<int> GetEmptyList => new LinkedList<int>();
        private LinkedList<int> GetListWithNElements(int n)
        {
            var list = new LinkedList<int>();
            for (int i = 1; i <= n; i++) list.Add(i);
            return list;
        }

        [TestMethod]
        public void EmptyListFirstNull()
        {
            var list = GetEmptyList;
            Assert.IsTrue(list.First == null, $"First supposed to be null for empty { TestClassName }");
        }

        [TestMethod]
        public void EmptyListLastNull()
        {
            var list = GetEmptyList;
            Assert.IsTrue(list.Last == null, $"Last supposed to be null for empty { TestClassName }");
        }

        [TestMethod]
        public void OneElementFirstNotNull()
        {
            var list = GetListWithNElements(1);

            Assert.IsTrue(list.First != null, $"First expected to be not null after first insertion");
        }

        [TestMethod]
        public void OneElementLastNotNull()
        {
            var list = GetListWithNElements(1);

            Assert.IsTrue(list.Last != null, $"Last expected to be not null after first insertion");
        }

        [TestMethod]
        public void OneElementCountOne()
        {
            var list = GetListWithNElements(1);

            var expected = 1;
            var actual = list.Count;

            Assert.IsTrue(actual == expected, $"Count expected to be { expected } after first insertion, but was { actual }");
        }

        [TestMethod]
        public void OneElementFistAndLastEquals()
        {
            var list = GetListWithNElements(1);

            Assert.AreSame(list.First, list.Last, $"First and Last expected to be the same object when { TestClassName } contains 1 value");
        }

        [TestMethod]
        public void TwoElementFistAndLastTest()
        {
            var list = GetListWithNElements(2);

            Assert.AreEqual(1, list.First.Data);
            Assert.AreEqual(2, list.Last.Data);

            Assert.AreEqual(2, list.First.Next.Data);
            Assert.IsNull(list.Last.Next, "list.Last.Next has to be null");

            Assert.AreNotSame(list.First, list.Last, $"First and Last expected to be different objects");
        }
    }
}
