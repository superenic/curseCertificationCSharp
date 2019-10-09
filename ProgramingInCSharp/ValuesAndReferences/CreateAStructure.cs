using ProgramingInCSharp.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramingInCSharp.ValuesAndReferences
{
    class CreateAStructure : ICommand
    {
        public string Description => "basic to create a structure";

        struct Alien
        {
            public int X;
            public int Y;
            public int Lives;

            public Alien(int x, int y)
            {
                X = x;
                Y = y;
                Lives = 3;
            }

            public override string ToString()
            {
                return string.Format("X: {0} Y: {1} Lives: {2}", X, Y, Lives);
            }
        }

        class AlienClass
        {
            public int X;
            public int Y;
            public int Lives;

            public AlienClass(int x, int y)
            {
                X = x;
                Y = y;
                Lives = 3;
            }

            public override string ToString()
            {
                return string.Format("X: {0} Y: {1} Lives: {2}", X, Y, Lives);
            }
        }

        public void StartCommand()
        {
            Alien a;
            a.X = 50;
            a.Y = 50;
            a.Lives = 3;
            Console.WriteLine("without constructor a {0}", a.ToString());

            Alien x = new Alien(100, 100);
            Console.WriteLine("with constructor x {0}", x.ToString());

            Alien[] swarm = new Alien[5];
            int position = 0;
            foreach (var alien in swarm)
            {
                Console.WriteLine("swarm [{0}] {1}", position++, alien.ToString());
            }

            Console.WriteLine("--------------------------------------------");

            AlienClass[] swarmClass = new AlienClass[5];
            position = 0;
            foreach (var alien in swarmClass)
            {
                Console.WriteLine("swarm [{0}] {1} I am null, one problem with that?!", position++, alien?.ToString());
            }

            Console.ReadKey();
        }
    }
}
