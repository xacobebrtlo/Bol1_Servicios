using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio7
{
    internal class Program
    {
        static readonly private object l = new object();
        private static int puntos = 0;
        static void Main(string[] args)
        {
            Thread player1 = new Thread(funcPlayer1);
            Thread player2 = new Thread(funcPlayer2);
            player1.Start();
            player2.Start();

        }

        public static void funcPlayer1()
        {
            while (puntos < 20)
            {
                Random rand = new Random();
                int num = rand.Next(1, 11);
                lock (l)
                {
                    if (puntos < 20)
                    {
                        Console.SetCursorPosition(0, 10);
                        Console.WriteLine(num);
                    }

                }
                Random randSleep = new Random();
               int sleep= randSleep.Next(100, 100 * num);
                Thread.Sleep(sleep);
            }


        }
        public static void funcPlayer2()
        {
            while (puntos > -20)
            {

                Random rand = new Random();
                int num = rand.Next(1, 11);
                lock (l)
                {
                    if (puntos > -20)
                    {

                        Console.SetCursorPosition(0, 30);
                        Console.WriteLine(num);
                    }
                }
                Random randSleep = new Random();
               int sleep= randSleep.Next(100, 100 * num);
                Thread.Sleep(sleep);

            }
        }
    }
}
