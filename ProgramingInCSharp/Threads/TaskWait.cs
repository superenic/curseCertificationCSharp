using ProgramingInCSharp.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingInCSharp.Threads
{
    class TaskWait : ICommand
    {
        public string Description => "Solo espero que termine la tarea";

        public void StartCommand()
        {
            Task task1 = new Task(() => {
                Console.WriteLine("hola1");
                Task.Delay(5000).Wait();
                Console.WriteLine("adios1");
                Task.Delay(500).Wait();
            }, TaskCreationOptions.AttachedToParent);

            Task task2 = new Task(() => {
                Console.WriteLine("hola2");
                Task.Delay(5000).Wait();
                Console.WriteLine("adios2");
                Task.Delay(500).Wait();
            }, TaskCreationOptions.AttachedToParent);

            Task[] list = new Task[2];
            list[0] = task1;
            list[1] = task2;

            Task.WaitAll(list);
        }
    }
}
