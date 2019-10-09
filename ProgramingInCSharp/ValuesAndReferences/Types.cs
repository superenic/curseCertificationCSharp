using ProgramingInCSharp.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramingInCSharp.ValuesAndReferences
{
    /// <summary>
    /// create a object and a structure, and show a estructure is not a reference like object.
    /// </summary>
    class Types : ICommand
    {
        public string Description => "Assigned all type in C# or .net";

        struct StructStore
        {
            public int Data { get; set; }
        }

        class ClassStore
        {
            public int Data { get; set; }
        }

        enum AlienState
        {
            Sleeping,
            Attacking,
            Destroyed,    
        };

        enum AlienBit:
        byte {
            Sleeping = 1,
            Attacking = 2,
            Destroyed = 4
        }

        public void StartCommand()
        {
            StructStore xs, ys;
            ys = new StructStore();
            ys.Data = 99;
            xs = ys;
            xs.Data = 100;
            Console.WriteLine("xStruct: {0}", xs.Data);
            Console.WriteLine("yStruct: {0}", ys.Data);

            ClassStore xc, yc;
            yc = new ClassStore();
            yc.Data = 99;
            xc = yc;
            xc.Data = 100;
            Console.WriteLine("xClass: {0}", xc.Data);
            Console.WriteLine("yClass: {0}", yc.Data);

            AlienState alienState = AlienState.Attacking;
            Console.WriteLine("State of alien {0}", alienState);

            AlienBit alienBit = AlienBit.Attacking;
            Console.WriteLine("State of alien bit {0}", alienBit);

            Console.ReadKey();
        }
    }
}
