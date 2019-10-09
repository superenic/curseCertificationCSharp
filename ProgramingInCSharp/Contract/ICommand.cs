using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramingInCSharp.Contract
{
    public interface ICommand
    {
        /// <summary>
        /// Kick started.
        /// </summary>
        void StartCommand();

        string Description { get;}
    }
}
