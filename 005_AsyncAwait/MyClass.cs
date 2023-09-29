using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005_AsyncAwait
{
    public class MyClass
    {
        int Operation()
        {
            Console.WriteLine("Operation in Thread Id = {0}",
                Thread.CurrentThread.ManagedThreadId);

            return 2 + 2;
        }

        public async void OperationAsync()
        {
            Task<int> task = Task<int>.Factory
                .StartNew(Operation);

            Console.WriteLine("\n Result {0}", await task);
        }
    }
}
