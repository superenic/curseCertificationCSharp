using ProgramingInCSharp.Contract;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace ProgramingInCSharp.ValuesAndReferences
{
    class GetAssamblyWay : ICommand
    {
        public string Description => "Get element that can be use ICommand";

        public void StartCommand()
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();

            List<Type> commanders = new List<Type>();

            foreach (Type t in thisAssembly.GetTypes())
            {
                if (t.IsInterface)
                    continue;

                if (typeof(ICommand).IsAssignableFrom(t))
                {
                    commanders.Add(t);
                }
            }

            foreach (var t in commanders)
            {
                Console.WriteLine(t.FullName);
            }

            var commanders2 = from type in thisAssembly.GetTypes()
                               where typeof(ICommand).IsAssignableFrom(type) && ! type.IsInterface
                               select type;

            // Assembly bankTypes = Assembly.Load("BankTypes.dll");

            Console.ReadKey();
        }
    }
}
