using ProgramingInCSharp.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramingInCSharp.Threads
{
    class TaskContinueWith : ICommand
    {
        public string Description => "Wait for others process or will be throw after";

        public static void HelloTask()
        {
            Thread.Sleep(3000);
            throw new Exception("cry");
            Console.WriteLine("Hello");
        }
        public static void WorldTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("World");
        }

        public void SomethinwasWrong(Task prevTask)
        {
            Console.WriteLine(prevTask.Exception.Message);

            foreach(var expcetion in prevTask.Exception.InnerExceptions)
            {
                Console.WriteLine(expcetion.Message);
            }
        }

        public void StartCommand()
        {
            Task task = Task.Run(() => HelloTask());
            task.ContinueWith((prevTask) => WorldTask());
            task.ContinueWith((prevTask) => this.SomethinwasWrong(prevTask), TaskContinuationOptions.OnlyOnFaulted);
            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}
