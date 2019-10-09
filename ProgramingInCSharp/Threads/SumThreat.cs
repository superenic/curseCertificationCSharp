using ProgramingInCSharp.Contract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingInCSharp.Threads
{
    class SumThreat : ICommand
    {
        public string Description => "Sum a huge collection.";

        private static long sharedTotal;

        // make an array that holds the values 0 to 5000000
        private int[] items = Enumerable.Range(0, 5000000).ToArray();

        private void addRangeOfValues(int start, int end)
        {
            while (start < end)
            {
                sharedTotal = sharedTotal + items[start];
                start++;
            }
        }

        private void MultiTreat()
        {
            List<Task> tasks = new List<Task>();

            int rangeSize = 1000;
            int rangeStart = 0;

            while (rangeStart < items.Length)
            {
                int rangeEnd = rangeStart + rangeSize;

                if (rangeEnd > items.Length)
                    rangeEnd = items.Length;

                // create local copies of the parameters
                int rs = rangeStart;
                int re = rangeEnd;

                tasks.Add(Task.Run(() => addRangeOfValues(rs, re)));
                rangeStart = rangeEnd;
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("The total is: {0}", sharedTotal);
        }

        private void NormalLoop()
        {
            long total = 0;

            for (int i = 0; i < items.Length; i++)
                total = total + items[i];

            Console.WriteLine("The total is: {0}", total);
        }

        public void StartCommand()
        {
            SumThreat.sharedTotal = 0;

            Console.WriteLine("Normal 1, Multithreat 2");
            string letter = Console.ReadLine();
            Stopwatch time = Stopwatch.StartNew();
            time.Start();
            if (letter == "1")
            {
                NormalLoop();
            }
            else if (letter == "2")
            {
                MultiTreat();
            }

            Console.Write("TIEMPO: {0}", time.Elapsed.Milliseconds
                .ToString());
            time.Stop();
            Console.ReadKey();
        }
    }
}
