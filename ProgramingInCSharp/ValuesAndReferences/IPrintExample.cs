using ProgramingInCSharp.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramingInCSharp.ValuesAndReferences
{
    interface IPrintable
    {
        string GetPrintableText(int pageWidth, int pageHeight);
        string GetTitle();
    }

    interface IDisplay
    {
        string GetTitle();
    }

    class Report : IPrintable, IDisplay
    {
        string IPrintable.GetPrintableText(int pageWidth, int pageHeight)
        {
            return "Report text to be printed";
        }

        string IPrintable.GetTitle()
        {
            return "Report title to be printed";
        }

        string IDisplay.GetTitle()
        {
            return "Report title to be displayed";
        }

        string GetTitle()
        {
            return "Normal object";
        }
    }

    class IWillDisplayIfUseInterface : ICommand
    {
        public string Description => "There are GetPrintableText But if you want see in code you need assigne in Interface equal";

        public void StartCommand()
        {
            Report report = new Report();
            IPrintable printable = report;
            IDisplay display = report;

            Console.WriteLine(report.GetType().FullName);
            Console.WriteLine(printable.GetTitle());
            Console.WriteLine(display.GetTitle());

            Console.ReadKey();
        }
    }
}
