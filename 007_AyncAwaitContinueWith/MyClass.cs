using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_AyncAwaitContinueWith
{
    internal class MyClass
    {
        double Operation(object argument)
        {
            Thread.Sleep(7000);
            return (double)argument * (double)argument;
        }

        public async Task<double> OperationAsync(double arg)
        {
            return await Task<double>
                .Factory.StartNew(Operation, arg);
        }
    }
}
