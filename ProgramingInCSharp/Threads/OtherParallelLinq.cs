using ProgramingInCSharp.Contract;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using ProgramingInCSharp.Model;

namespace ProgramingInCSharp.Threads
{
    class OtherParallelLinq : ICommand
    {
        public string Description => "other way to get linq parallel";

        public void StartCommand()
        {
            var people = SelectPersonByParallel.GetListPerson();
            var result = from 
                         person in people
                            .AsParallel()
                            .WithDegreeOfParallelism(4)
                            .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                         where person.City == "Seattle" select person;

            foreach(Person person in result)
            {
                Console.WriteLine(person.Name);
            }

            //result.ForAll(element => Console.WriteLine(element.City));

            Console.ReadKey();
        }
    }
}
