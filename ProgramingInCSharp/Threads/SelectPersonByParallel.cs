using ProgramingInCSharp.Contract;
using ProgramingInCSharp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProgramingInCSharp.Threads
{
    class SelectPersonByParallel : ICommand
    {
        public string Description => "Seleciona una lista con Parallel";

        public static Person[] GetListPerson()
        {
            return new Person[] {
                new Person { Name = "Alan", City = "Hull" },
                new Person { Name = "Beryl", City = "Seattle" },
                new Person { Name = "Charles", City = "London" },
                new Person { Name = "David", City = "Seattle" },
                new Person { Name = "Eddy", City = "Paris" },
                new Person { Name = "Fred", City = "Berlin" },
                new Person { Name = "Gordon", City = "Hull" },
                new Person { Name = "Henry", City = "Seattle" },
                new Person { Name = "Isaac", City = "Seattle" },
                new Person { Name = "James", City = "London" } };
        }

        public void StartCommand()
        {
            var people = SelectPersonByParallel.GetListPerson();

            var result = from person in people.AsParallel() where person.City == "Seattle" select person;

            foreach (var person in result)
                Console.WriteLine(person.Name);

            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}
