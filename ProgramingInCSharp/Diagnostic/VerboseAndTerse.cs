﻿using ProgramingInCSharp.Contract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ProgramingInCSharp.Diagnostic
{
    class VerboseAndTerse : ICommand
    {
        public string Description => "Diagnostic verbose and terse";
        [Conditional("VERBOSE"), Conditional("TERSE")]
        static void reportHeader()
        {
            Console.WriteLine("This is the header for the report");
        }

        [Conditional("VERBOSE")]
        static void verboseReport()
        {
            Console.WriteLine("This is output from the verbose report.");
        }

        [Conditional("TERSE")]
        static void terseReport()
        {
            Console.WriteLine("This is output from the terse report.");
        }
        private void normalReport()
        {
            Console.WriteLine("this is a normal report");
        }

        public void StartCommand()
        {
            reportHeader();
            terseReport();
            verboseReport();
            normalReport();

            Console.WriteLine("Not show in normal console.");

            Console.ReadKey();
        }
    }
}
