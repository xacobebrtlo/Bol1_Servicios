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
        private static bool pausado = false;
        private static bool juego = true;
        static void Main(string[] args)
        {
            Thread player1 = new Thread(funcPlayer1);
            Thread player2 = new Thread(funcPlayer2);
            Thread display = new Thread(funcDisplay);
            player1.Start();
            player2.Start();
            display.Start();
            player1.Join();
            player2.Join();

            Console.SetCursorPosition(0, 13);

            if (puntos <= -20)
            {

                Console.WriteLine("Ganador Player2\nPuntos:" + puntos);
            }
            if (puntos >= 20)
            {
                Console.WriteLine("Ganador Player1\nPuntos:" + puntos);
            }
            Console.ReadKey();

        }

        public static void funcPlayer1()
        {
            while (juego)
            {
                Random rand = new Random();
                int num = rand.Next(1, 10);
                lock (l)
                {
                    if (juego)
                    {
                        Console.SetCursorPosition(0, 5);
                        Console.WriteLine(num);
                        Console.SetCursorPosition(0, 13);
                        Console.WriteLine("Puntos: " + String.Format("{0,-3}", puntos));

                        if (num == 5 || num == 7)
                        {
                            if (pausado)
                            {
                                puntos += 5;
                            }
                            else
                            {

                                pausado = true;
                                puntos++;
                            }
                        }
                        if (puntos >= 20)
                        {
                            juego = false;
                        }
                    }


                }
                Random randSleep = new Random();
                int sleep = randSleep.Next(100, 100 * num);
                Thread.Sleep(sleep);
            }


        }
        public static void funcPlayer2()
        {
            while (juego)
            {

                Random rand = new Random();
                int num = rand.Next(1, 10);
                lock (l)
                {
                    if (juego)
                    {

                        Console.SetCursorPosition(0, 11);
                        Console.WriteLine(num);
                        Console.SetCursorPosition(0, 13);
                        Console.WriteLine("Puntos: " + String.Format("{0,-3}", puntos));

                        if (num == 5 || num == 7)
                        {
                            if (!pausado)
                            {
                                puntos -= 5;
                            }
                            else
                            {

                                Monitor.Pulse(l);
                                pausado = false;
                                puntos--;
                            }
                        }
                        if (puntos <= -20)
                        {
                            juego = false;
                        }
                    }

                }
                Random randSleep = new Random();
                int sleep = randSleep.Next(100, 100 * num);
                Thread.Sleep(sleep);

            }
        }
        public static void funcDisplay()
        {
            int cont = 0;
            char[] caracteres = { '|', '/', '-', '\\' };
            while (puntos > -20 && puntos < 20)
            {
                lock (l)
                {
                    if (!pausado)
                    {

                        Console.SetCursorPosition(0, 8);
                        Console.WriteLine(caracteres[cont]);
                        cont++;
                    }
                    else
                    {
                        Monitor.Wait(l);
                    }

                }
                Thread.Sleep(200);
                if (cont > 3)
                {
                    cont = 0;
                }

            }
        }
    }
}
