using ProgramingInCSharp.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramingInCSharp.Threads
{
    class TaskEnumerable : ICommand
    {
        public string Description => "debe de hacer 500 procesos";

        private void Work(Object item)
        {
            Console.WriteLine("Started " + item);
            Thread.Sleep(100);
            Console.WriteLine("Finished " + item);
        }

        public void StartCommand()
        {
            var items = Enumerable.Range(0, 500);

            Parallel.ForEach(items, item => {
                this.Work(item);
            });
        }
    }
}
