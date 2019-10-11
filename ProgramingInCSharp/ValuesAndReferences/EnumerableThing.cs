using ProgramingInCSharp.Contract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ProgramingInCSharp.ValuesAndReferences
{
    class EnumerableThing : IEnumerator<int>, IEnumerable
    {
        int count;
        int limit;

        public int Current
        {
            get
            {
                return count;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return count;
            }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (++count == limit)
                return false;
            else
                return true;
        }

        public void Reset()
        {
            count = 0;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public EnumerableThing(int limit)
        {
            count = 0;
            this.limit = limit;
        }
    }

    class NumerableTest : ICommand
    {
        public string Description => "I will run a custum Enumerable";

        public void StartCommand()
        {
            IEnumerable e = new EnumerableThing(10);

            foreach (int i in e)
                Console.WriteLine(i);

            Console.ReadKey();
        }
    }
}
