using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _004_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("General ThreadId {0}",
    Thread.CurrentThread.ManagedThreadId);

            MyClass myClass = new MyClass();

            myClass.OperationAsync();

            Console.ReadLine();
        }
    }
}
