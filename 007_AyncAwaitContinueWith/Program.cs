using _007_AyncAwaitContinueWith;

MyClass my = new MyClass();

Task<double> task = my.OperationAsync(5);

task.ContinueWith(t => Console.WriteLine("Result is {0}",
    t.Result));


Console.WriteLine(task.Result);

Console.WriteLine("After");
Console.ReadLine();