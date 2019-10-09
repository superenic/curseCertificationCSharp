using ProgramingInCSharp.Contract;
using System;
using System.Threading;

namespace ProgramingInCSharp.Threads
{
    class ThreadQueuePool : ICommand
    {
        public string Description => "Crete a Queue that not let create more task even other are finish";
        void DoWork(object state)
        {
            Console.WriteLine("Doing work: {0}", state);
            Thread.Sleep(500);
            Console.WriteLine("Work finished: {0}", state);
        }

        public void StartCommand()
        {
            for (int i = 0; i < 50; i++)
            {
                int stateNumber = i;
                ThreadPool.QueueUserWorkItem(state => DoWork(stateNumber));
            }

            Console.ReadKey();
        }
    }
}
