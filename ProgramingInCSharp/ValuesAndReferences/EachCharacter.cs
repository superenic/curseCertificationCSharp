using ProgramingInCSharp.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramingInCSharp.ValuesAndReferences
{
    class EachCharacter : ICommand
    {
        public string Description => "each character";

        public void StartCommand()
        {
            foreach (char ch in "Hello world")
                Console.Write(ch);

            EnumerableThing e = new EnumerableThing(10);

            foreach (int i in e)
                Console.WriteLine(i);

            Console.ReadKey();
        }
    }
}
