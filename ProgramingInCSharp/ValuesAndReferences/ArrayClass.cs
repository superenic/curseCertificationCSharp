using ProgramingInCSharp.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramingInCSharp.ValuesAndReferences
{
    class IntArrayWrapper
    {
        // Create an array to store the values
        private int[] array = new int[100];

        // Declare an indexer property
        public int this[int i]
        {
            get { return array[i]; }
            set { array[i] = value; }
        }
    }

    class StringArrayWrapper
    {
        // Create an array to store the values
        private int[] array = new int[100];

        // Declare an indexer property
        public int this[string name]
        {
            get
            {
                switch (name)
                {
                    case "zero":
                        return array[0];
                    case "one":
                        return array[1];
                    default:
                        return -1;
                }
            }
            set
            {
                switch (name)
                {
                    case "zero":
                        array[0] = value;
                        break;
                    case "one":
                        array[1] = value;
                        break;
                }
            }
        }
    }

    class ArrayClass : ICommand
    {
        public string Description => "Convert a simple object in a array";

        public void StartCommand()
        {
            IntArrayWrapper x = new IntArrayWrapper();
            x[0] = 99;
            //foreach (int element in x)
            //    Console.WriteLine("value {0}", element);
            Console.WriteLine("element {0}", x[0]);

            StringArrayWrapper y = new StringArrayWrapper();
            y["zero"] = 99;
            Console.WriteLine(y["zero"]);

            Console.ReadKey();
        }
    }
}
