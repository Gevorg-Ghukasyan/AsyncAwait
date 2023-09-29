using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class MyClass
    {
        public void Operation()
        {
            Console.WriteLine("Operation ThreadId {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Begin");
            Console.WriteLine("End");
        }

        public async void OperationAsync()
        {
            Task task = new Task(Operation);            
            task.Start();
            await task;
        }
    }
}
