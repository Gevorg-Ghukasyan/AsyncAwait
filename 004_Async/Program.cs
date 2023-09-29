using _004_Async;

Console.WriteLine("General ThreadId {0}",
    Thread.CurrentThread.ManagedThreadId);

MyClass myClass = new MyClass();

myClass.OperationAsync();