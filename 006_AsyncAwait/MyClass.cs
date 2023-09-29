using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_AsyncAwait
{
    internal class MyClass
    {
        public void Operation()
        {
            Console.WriteLine("Primary Thread Id = {0}",
                Thread.CurrentThread.ManagedThreadId);
        }

        public async Task OperationAsync()
        {
            await Task.Factory.StartNew(Operation);
        }
    }
}
