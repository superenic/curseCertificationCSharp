using ProgramingInCSharp.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramingInCSharp.ValuesAndReferences
{
    public class Father
    {
        public virtual string SayMySonWillbe()
        {
            return "My son will study that I want he study";
        }
    }

    public class Son: Father
    {
        public override string SayMySonWillbe()
        {
            return "Come on!!!";
        }
    }

    public class ChangeOpinionFather : ICommand
    {
        public string Description => "The method of father will be changed by son class.";

        public void StartCommand()
        {
            Father father = new Father();
            Son son = new Son();

            Console.WriteLine(father.SayMySonWillbe());
            Console.WriteLine(son.SayMySonWillbe());

            Console.ReadKey();
        }
    }
}
