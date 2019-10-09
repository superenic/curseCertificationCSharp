using ProgramingInCSharp.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace ProgramingInCSharp.Threads
{
    class MonitorTreat : ICommand
    {
        private static int[] items = Enumerable.Range(0, 5000000).ToArray();
        private static int ShareTotal = 0;

        private void addRangeOfValues(int start, int end)
        {
            int subTotal = 0;

            while (start < end)
            {
                subTotal = subTotal + items[start];
                start++;
            }

            //Monitor.Enter(sharedTotalLock);
            //try
            //{
            //    ShareTotal = ShareTotal + subTotal;
            //}
            //finally
            //{
            //    Monitor.Exit(sharedTotalLock);
            //}

            // to same like Monitor
            Interlocked.Add(ref ShareTotal, subTotal);
        }

        public string Description => "Lock process since element is not exit of monitor";

        public void StartCommand()
        {
            ShareTotal = 0;
            addRangeOfValues(1, 500000001);
            Console.WriteLine(ShareTotal);
        }
    }
}
