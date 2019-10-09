using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramingInCSharp.Contract;

namespace ProgramingInCSharp.Threads
{
    class TaskStopable : ICommand
    {
        public string Description => "La tarea se debe finalizar en 200";

        public void StartCommand()
        {
            var items = Enumerable.Range(0, 500).ToArray();

            ParallelLoopResult result = Parallel.For(0, items.Count(), (int i, ParallelLoopState loopState) =>
            {
                if (i == 200)
                {
                    loopState.Stop();
                }

                Console.WriteLine("tarea " + i);
            });

            Console.WriteLine("Completed: " + result.IsCompleted);
            Console.WriteLine("Items: " + result.LowestBreakIteration);
            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}
