using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ej4
{
    internal class Program
    {
        public static int numero = 0;
        static readonly private Object l = new Object();
        static bool flag = true;
        static void Main(string[] args)
        {

            Thread hilo1 = new Thread(() =>
            {
                while (flag)
                {
                    lock (l)
                    {
                        if (flag)
                        {
                            numero++;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(numero);
                            Console.ResetColor();

                            if (numero == 500)
                            {
                                flag = false;
                            }
                        }
                    }

                }
            });
            Thread hilo2 = new Thread(() =>
            {
                while (flag)
                {
                    lock (l)
                    {
                        if (flag)
                        {
                            numero--;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(numero);
                            Console.ResetColor();
                            if (numero == -500)
                            {
                                flag = false;
                            }
                        }
                    }

                }
            });


            hilo1.Start();
            hilo2.Start();

            hilo1.Join();
            hilo2.Join();

            if (numero == 500)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"El hilo ganador es el hilo que incrementa (hilo1)");
                Console.ResetColor();
                Console.ReadKey();
            }
            if (numero == -500)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"El hilo ganador es el hilo que decrementa (hilo2)");
                Console.ResetColor();
                Console.ReadKey();
            }


            Console.ReadKey();

        }

    }
}
