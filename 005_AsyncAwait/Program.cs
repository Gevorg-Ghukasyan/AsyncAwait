using _005_AsyncAwait;

MyClass myClass = new MyClass();

myClass.OperationAsync();

Console.WriteLine("General Thread finish the work ThreadId = {0}",
    Thread.CurrentThread.ManagedThreadId);
