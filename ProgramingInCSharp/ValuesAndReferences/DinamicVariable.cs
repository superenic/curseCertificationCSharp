using Microsoft.CSharp.RuntimeBinder;
using ProgramingInCSharp.Contract;
using ProgramingInCSharp.Model;
using System;
using System.Dynamic;

namespace ProgramingInCSharp.ValuesAndReferences
{
    class DinamicVariable : ICommand
    {
        public string Description => "I will declare a variable with dinamic and let me be wrong in method not exists";

        public void StartCommand()
        {
            dynamic personWithoutCheese = new Person();

            try
            {
                personWithoutCheese.chesse();
            }
            catch (RuntimeBinderException runtime)
            {
                Console.WriteLine("Method chesse not exist but compiler let me be wrong by Dynamic key word.");
            }

            dynamic d = 99;
            d = d + 1;
            Console.WriteLine(d);

            d = "Hello";
            d = d + " Rob";
            Console.WriteLine(d);

            dynamic person = new ExpandoObject();

            person.Name = "Rob Miles";
            person.Age = 21;

            Console.WriteLine("Name: {0} Age: {1}", person.Name, person.Age);

            Console.ReadKey();
        }
    }
}
