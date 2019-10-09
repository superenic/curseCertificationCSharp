using System;
using System.Threading;
using ProgramingInCSharp.Contract;

namespace ProgramingInCSharp.Threads
{ 
    class Threadings: ICommand
    {
        public string Description => "Crea un configurable para pasar el argumento que gustes";

        private void WorkOnData(Object data)
        {
            Console.WriteLine("Working on: {0}", data);

            Thread.Sleep(1000);
        }

        public void StartCommand()
        {
            ParameterizedThreadStart ps = new ParameterizedThreadStart(this.WorkOnData);

            Thread thread = new Thread(ps);

            thread.Start(1000);
        }
    }
}
