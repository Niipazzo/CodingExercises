using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new A();
            Test(ref a);
            Console.WriteLine(a.a);
            Console.Read();
        }

        private static void Test(ref A a)
        {
            a = new A() { a = 777 };
        }

        class A
        {
            public int a = 666;
        }
    }
}
