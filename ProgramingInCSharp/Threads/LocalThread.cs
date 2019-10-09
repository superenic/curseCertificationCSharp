using ProgramingInCSharp.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProgramingInCSharp.Threads
{
    class LocalThread: ICommand
    {
        /// <summary>
        /// Create a same variable for each thread like name that in a threar is
        /// changing but only for a single thread
        /// </summary>
        public ThreadLocal<Random> RandomGenerator =
            new ThreadLocal<Random>(() =>
            {
                return new Random(2);
            });
        private string name = "quesadilla";

        public string Description => "Run differents thread but link main thread";

        public void StartCommand()
        {
            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("t1: {0} {1}", RandomGenerator.Value.Next(10), name);
                    Thread.Sleep(500);
                }
            });

            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("t1: {0} {1}", RandomGenerator.Value.Next(10), name);
                    name = name + i;
                    Thread.Sleep(500);
                }
            });

            t1.Start();
            t2.Start();
            Console.ReadKey();
        }
    }
}
