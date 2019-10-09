using ProgramingInCSharp.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramingInCSharp.Threads
{
    class CancelationToken : ICommand
    {
        public string Description => "Cancelation Token";

        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        private void Clock(CancellationToken cancellationToken)
        {
            int tickCount = 0;

            while (!cancellationToken.IsCancellationRequested && tickCount < 20)
            {
                tickCount++;
                Console.WriteLine("Tick {0} / 20", tickCount);
                Thread.Sleep(500);
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        public void StartCommand()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            Task clock = Task.Run(() => Clock(cancellationTokenSource.Token));

            Console.WriteLine("Press any key to stop the clock");

            Console.ReadKey();

            if (clock.IsCompleted)
            {
                Console.WriteLine("Clock task completed");
            }
            else
            {
                try
                {
                    cancellationTokenSource.Cancel();
                    clock.Wait();
                }
                catch (AggregateException ex)
                {
                    Console.WriteLine("Clock stopped: {0}",
                         ex.InnerExceptions[0].ToString());
                }
            }
            Console.ReadKey();
        }
    }
}
