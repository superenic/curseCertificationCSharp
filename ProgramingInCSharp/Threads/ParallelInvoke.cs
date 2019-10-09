using ProgramingInCSharp.Contract;
using System;

using System.Threading;
using System.Threading.Tasks;

namespace ProgramingInCSharp.Threads
{
    class ParallelInvoke : ICommand
    {
        public string Description => "arrancar dos tareas con Parallel Invoke";

        void Task1()
        {
            Console.WriteLine("tarea 1");
            Thread.Sleep(2000);
            Console.WriteLine("termine 1");
        }

        void Task2()
        {
            Console.WriteLine("tarea 2");
            Thread.Sleep(2000);
            Console.WriteLine("termine 2");
        }

        public void StartCommand()
        {
            Parallel.Invoke(() => this.Task1(), () => this.Task2());
            Console.WriteLine("presiona para no acabar a tiempo");
            Console.ReadKey();
        }
    }
}
