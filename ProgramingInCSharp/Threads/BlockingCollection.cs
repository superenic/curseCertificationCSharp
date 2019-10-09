using ProgramingInCSharp.Contract;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingInCSharp.Threads
{
    class BlockingCollection : ICommand
    {
        public string Description => "Block of thread handler by BlockingCollection";

        public void StartCommand()
        {
            // Blocking collection that can hold 5 items
            BlockingCollection<int> data = new BlockingCollection<int>(2);

            Task.Run(() =>
            {
                // attempt to add 10 items to the collection - blocks after 5th
                for (int i = 0; i < 21; i++)
                {
                    data.Add(i);
                    Console.WriteLine("Data {0} added sucessfully.", i);
                }

                Console.WriteLine("Zone A");
                data.CompleteAdding();
                Console.WriteLine("Zone B");
            });

            Console.ReadKey();
            Console.WriteLine("Reading collection");

            Task.Run(() =>
            {
                while (! data.IsCompleted)
                {
                    try
                    {
                        int v = data.Take();
                        Console.WriteLine("\tData {0} taken sucessfully.", v);
                    }
                    catch (InvalidOperationException) { }
                }
            });

            Console.ReadKey();
        }
    }
}
