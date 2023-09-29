using _003_AsyncAwait;

Console.WriteLine("General ThreadId {0}",
    Thread.CurrentThread.ManagedThreadId);

MyClass myClass = new MyClass();

myClass.OperationAsync();

Thread.Sleep(5000);

Console.WriteLine("General ThreadId {0}",
    Thread.CurrentThread.ManagedThreadId);