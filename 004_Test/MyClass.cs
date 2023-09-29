using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace _004_Test
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

        AsyncStateMachine stateMachine;

        public void OperationAsync()
        {
            // = new AsyncStateMachine();
            stateMachine.outer = this;
            stateMachine.builder = AsyncVoidMethodBuilder.Create();
            stateMachine.state = -1;
            stateMachine.builder.Start(ref stateMachine);
        }
        private struct AsyncStateMachine : IAsyncStateMachine
        {
            public MyClass outer;
            public AsyncVoidMethodBuilder builder;
            public int state;

            int counterCallMoveNext;

            void IAsyncStateMachine.MoveNext()
            {
                Console.WriteLine("\n Method MoveNext calles {0}- time is the thread id {1}",
                    ++counterCallMoveNext, Thread.CurrentThread.ManagedThreadId);

                if (state == -1)
                {
                    Console.WriteLine("OperationAsync (Part I) ThreadId {0}",
                        Thread.CurrentThread.ManagedThreadId);

                    Task task = new Task(outer.Operation);

                    task.Start();

                    state = 0;
                    TaskAwaiter awaiter = task.GetAwaiter();

                    builder.AwaitOnCompleted(ref awaiter, ref this);

                    return;
                }
                Console.WriteLine("OperationAsync (Part II) ThreadId {0}",
                       Thread.CurrentThread.ManagedThreadId);
            }

            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
                Console.WriteLine("Method SetStateMachine with Thread Id {0}",
                    Thread.CurrentThread.ManagedThreadId);

                Console.WriteLine("stateMachine GetHashCode {0}", stateMachine.GetHashCode());

                Console.WriteLine("this.GetHashCode {0}", this.GetHashCode());
            }
        }
    }
}
