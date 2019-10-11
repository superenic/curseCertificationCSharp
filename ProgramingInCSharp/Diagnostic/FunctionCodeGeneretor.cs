using ProgramingInCSharp.Contract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ProgramingInCSharp.Diagnostic
{
    class FunctionCodeGeneretor : ICommand
    {
        public string Description => "Handerl expresion function with reflection";

        public void StartCommand()
        {
            // build the expression tree: 
            // Expression<Func<int,int>> square = num => num * num;

            // The parameter for the expression is an integer
            ParameterExpression numParam = Expression.Parameter(typeof(int), "num");

            // The opertion to be performed is to square the parameter
            BinaryExpression squareOperation = Expression.Multiply(numParam, numParam);

            // This creates an expression tree that describes the square operation
            Expression<Func<int, int>> square =
                Expression.Lambda<Func<int, int>>(
                    squareOperation,
                    new ParameterExpression[] { numParam });

            // Compile the tree to make an executable method and assign it to a delegate
            Func<int, int> doSquare = square.Compile();

            // Call the delegate
            Console.WriteLine("Square of 2: {0}", doSquare(2));

            Console.ReadKey();
        }
    }
}
