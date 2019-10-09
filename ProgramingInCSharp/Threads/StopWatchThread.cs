using ProgramingInCSharp.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProgramingInCSharp.Threads
{
    class StopWatchThread : ICommand
    {
        public string Description => "Inicia el reloj";
        private bool _stopWatch = false;

        public void StartCommand()
        {
            _stopWatch = false;
            Thread tickThread = new Thread(() =>
            {
                int tickMax = 10;
                int timesTicks = 0;

                while (! this._stopWatch && timesTicks < tickMax)
                {
                    timesTicks++;
                    Console.WriteLine("Tick " + timesTicks);
                    Thread.Sleep(1000);
                }

                if (tickMax <= timesTicks)
                {
                    Console.WriteLine("Timeout");

                    return;
                }

                Console.WriteLine("Close premature.");
                Console.ReadKey();
            });

            tickThread.Start();

            Console.WriteLine("Press a key to stop the clock");
            Console.ReadKey();

            this._stopWatch = true;
        }
    }
}
