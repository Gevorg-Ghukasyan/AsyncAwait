namespace _003_AsyncAwait
{
    public class MyClass
    {
        public void Operation()
        {
            Console.WriteLine("Operation ThreadId {0}",
                Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Begin");
            Console.WriteLine("End");
        }

        public async void OperationAsync()
        {
            Console.WriteLine
                ("First part of OperationAsync Thread Id = {0}",
                Thread.CurrentThread.ManagedThreadId);
            Task task = new Task(Operation);
            task.Start();

            Console.WriteLine
                          ("First/Second part of OperationAsync Thread Id = {0}",
                          Thread.CurrentThread.ManagedThreadId);
            await task;

            Console.WriteLine
                    ("Second part of OperationAsync Thread Id = {0}",
                    Thread.CurrentThread.ManagedThreadId);
        }
    }
}
