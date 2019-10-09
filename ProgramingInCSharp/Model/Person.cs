using ProgramingInCSharp.ValuesAndReferences;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramingInCSharp.Model
{
    [Serializable]
    [Programmer(programmer: "Fred")]
    class Person
    {
        public string Name { get; set; }
        public string City { get; set; }
        [NonSerialized]
        private int Count;
    }
}
