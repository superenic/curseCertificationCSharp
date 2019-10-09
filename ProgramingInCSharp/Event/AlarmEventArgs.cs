using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramingInCSharp.Event
{
    public class AlarmEventArgs : EventArgs
    {
        public string Location { get; set; }

        public AlarmEventArgs(string location)
        {
            Location = location;
        }
    }
}
