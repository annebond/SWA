using System;
using System.Linq;
using System.Text;
using CodingDojo1.Stack;

namespace CodingDojo1.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            TestWithObject();
            //TestWithString();
            //TestWithInt();
            Console.ReadLine();
        }


        static void TestWithInt()
        {
            Stack<int> test = new Stack<int>();

            test.Push(2);
            test.Push(3);
            Console.WriteLine("read: {0}", test.Peek());
            test.Push(4);
            Console.WriteLine("{0} removed", test.Pop());
            Console.WriteLine("{0} removed", test.Pop());
            Console.WriteLine("read: {0}", test.Peek());
            Console.WriteLine("{0} removed", test.Pop());
        }

        static void TestWithString()
        {
            Stack<string> test = new Stack<string>();

            test.Push("E1");
            test.Push("E2");
            Console.WriteLine("read: {0}", test.Peek());
            test.Push("E3");
            Console.WriteLine("{0} removed", test.Pop());
            Console.WriteLine("{0} removed", test.Pop());
            Console.WriteLine("read: {0}", test.Peek());
            Console.WriteLine("{0} removed", test.Pop());

        }

        static void TestWithObject()
        {
            Stack<TestObject> test = new Stack<TestObject>();

            test.Push(new TestObject(41, "Sampleperson1"));
            Console.WriteLine("read: {0}", test.Peek());
            test.Push(new TestObject(80, "Sampleperson2"));
            Console.WriteLine("read: {0}", test.Peek());
            test.Push(new TestObject(15, "Sampleperson3"));
            Console.WriteLine("read: {0}", test.Peek());
            Console.WriteLine("{0} removed", test.Pop());
            Console.WriteLine("read: {0}", test.Peek());
            Console.WriteLine("{0} removed", test.Pop());
            Console.WriteLine("read: {0}", test.Peek());
            Console.WriteLine("{0} removed", test.Pop());
            Console.WriteLine("read: {0}", test.Peek());

        }
    }
}
