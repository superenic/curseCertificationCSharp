using ProgramingInCSharp.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramingInCSharp.ValuesAndReferences
{
    class ExcelApp : ICommand
    {
        public string Description => "Excel intance";

        public void StartCommand()
        {
            // no working.
            throw new MissingMethodException();

            // Create the interop
            //var excelApp = new Microsoft.Office.Interop.Excel.Application();

            //// make the app visible
            //excelApp.Visible = true;

            //// Add a new workbook
            //excelApp.Workbooks.Add();

            //// Obtain the active sheet from the app
            //// There is no need to cast this dynamic type
            //Microsoft.Office.Interop.Excel.Worksheet workSheet = excelApp.ActiveSheet;

            //// Write into two cells
            //workSheet.Cells[1, "A"] = "Hello";
            //workSheet.Cells[1, "B"] = "from C#";
        }
    }
}
