using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramingInCSharp.ValuesAndReferences
{
    public static class ExtensionMethod
    {
        private const char JUMP_CHARACTER = (char) 13;

        public static int LineCount(this String str)
        {
            return str.Split(new char[] { JUMP_CHARACTER },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
