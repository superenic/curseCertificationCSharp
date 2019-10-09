using ProgramingInCSharp.Contract;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using ProgramingInCSharp.Model;

namespace ProgramingInCSharp.Threads
{
    class OtherParallelLinqOrderAsSequential : ICommand
    {
        public string Description => "other way to get linq parallel order";

        public void StartCommand()
        {
            var people = SelectPersonByParallel.GetListPerson();
            var result = from 
                         person in people
                            .AsParallel()
                            .AsOrdered()
                         where person.City == "Seattle" select person;

            foreach(Person person in result)
            {
                Console.WriteLine(person.Name);
            }

            Console.ReadKey();
        }
    }
}
