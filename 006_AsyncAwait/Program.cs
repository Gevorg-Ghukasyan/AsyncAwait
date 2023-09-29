using _006_AsyncAwait;

MyClass my = new MyClass();

Task task = my.OperationAsync();

task.ContinueWith(t => Console.WriteLine("Continuing the task"));

Console.ReadLine();