﻿using System;
using System.Linq;
using ProgramingInCSharp.Contract;
using ProgramingInCSharp.Diagnostic;
using ProgramingInCSharp.Event;
using ProgramingInCSharp.Threads;
using ProgramingInCSharp.ValuesAndReferences;

namespace ProgramingInCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            ICommand[] tareas = new ICommand[]
            {
                new Threadings(),
                new ThreadRandomLocal(),
                new ParallelInvoke(),
                new TaskEnumerable(),
                new TaskStopable(),
                new SelectPersonByParallel(),
                new OtherParallelLinq(),
                new OtherParallelLinqOrder(),
                new OtherParallelLinqOrderAsSequential(),
                new TaskWait(),
                new TaskContinueWith(),
                new TaskFactoryChildhood(),
                new StopWatchThread(),
                new LocalThread(),
                new ShowCurrentThread(),
                new ThreadQueuePool(),
                new BlockingCollection(),
                new AsyncAndAwait(),
                new SumThreat(),
                new CancelationToken(),
                new MonitorTreat(),
                new VolatileVariableThreat(),
                new ActionDelegator(),
                new DelegateFunction(),
                new Types(),
                new CreateAStructure(),
                new ArrayClass(),
                new ImplicitAndExplicit(),
                new EachCharacter(),
                new VerboseAndTerse(),
                new AnnotationStudy(),
                new DinamicVariable(),
                new IWillDisplayIfUseInterface(),
                new ChangeOpinionFather(),
                new NumerableTest(),
                new GetAssamblyWay(),
                new CreateClassByCode(),
                new FunctionCodeGeneretor(),
            };

            var salida = "q";
            string letraElegida = "";

            while(true)
            {
                try
                {
                    Console.Clear();

                    int position = 0;
                    foreach(ICommand tarea in tareas)
                    {
                        Console.Write(position + " - " + tarea.GetType().Name);
                        Console.WriteLine("\t\t" + tarea.Description);

                        position++;
                    }

                    Console.WriteLine("¿Que quieres probar?");
                    letraElegida = Convert.ToString(Console.ReadLine());

                    if (letraElegida.ToLower() == salida)
                    {
                        Console.WriteLine("Adios amo cruel!!");

                        break;
                    }

                    int index = Convert.ToInt32(letraElegida);

                    if (tareas[index] != null)
                    {
                        Console.Clear();
                        Console.WriteLine("empieza " + tareas[index].GetType().Name);
                        Console.WriteLine(tareas[index].Description);
                        tareas[index].StartCommand();
                        Console.WriteLine("quizas termine espera que termine el proceso paralelo " + tareas[index].GetType().Name);
                    }

                    letraElegida = "";
                    index = 0;
                }
                catch
                {}
            }
        }
    }
}
