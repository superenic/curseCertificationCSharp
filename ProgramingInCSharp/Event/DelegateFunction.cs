﻿using ProgramingInCSharp.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramingInCSharp.Event
{
    class DelegateFunction : ICommand
    {
        private delegate int Operador(int a, int b);
        private Func<int, int, int> Functionality;
        private Action<string> logMessage = (message) => Console.WriteLine(message);

        public string Description => "Create two delegate function";

        private int add(int a, int b) => a + b;
        private int sub(int a, int b) => a - b;

        public void StartCommand()
        {
            Operador times = (first, second) => first * second;

            Operador[] operators = new Operador[]
            {
                this.add,
                this.sub,
                times,
                (first, second) => first / second,
            };

            int a = 10, b = 5;

            foreach (Operador operatora in operators)
            {
                logMessage(Convert.ToString(operatora(a, b)));
            }
            Console.WriteLine(add(b:10, a: 5));

            // return true or false, generic is parameters.
            Predicate<int> dividesByThree = (i) => i % 3 == 0;

            // catch (CalcException ce) when (ce.Error == CalcException.CalcErrorCodes.DivideByZero)

            Console.WriteLine(dividesByThree(6));

            Console.ReadKey();
        }
    }
}
