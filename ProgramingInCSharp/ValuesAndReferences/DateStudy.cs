using ProgramingInCSharp.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramingInCSharp.ValuesAndReferences
{
    class DateStudy : ICommand
    {
        public string Description => "Datetime";

        public void StartCommand()
        {
            DateTime d0 = new DateTime(ticks: 636679008000000000);
            DateTime d1 = new DateTime(year: 2018, month: 7, day: 23);
            Console.WriteLine(d0);
            Console.WriteLine(d1);

            Console.ReadKey();
        }
    }
}
