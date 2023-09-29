using System.Runtime.CompilerServices;

namespace _002_StateMachine
{
    public class MyClass
    {
        public void Operation()
        {
            Console.WriteLine("Operation ThreadId {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Begin");
            Console.WriteLine("End");
        }

        public void OperationAsync()
        {
            AsyncStateMachine stateMachine;
            stateMachine.outer = this;
            stateMachine.builder = AsyncVoidMethodBuilder.Create();
            stateMachine.builder.Start(ref stateMachine);
        }
    }

    public struct AsyncStateMachine : IAsyncStateMachine
    {
        public MyClass outer;
        public AsyncVoidMethodBuilder builder;

        void IAsyncStateMachine.MoveNext()
        {
            Task task = new Task(outer.Operation);
            task.Start();
        }

        void IAsyncStateMachine.SetStateMachine
            (IAsyncStateMachine stateMachine)
        {
            throw new NotImplementedException();
        }
    }
}
