using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ej5
{
    internal class Program
    {
        internal class Caballo
        {
            static readonly private object l = new object();
            string nombre;
            int x;
            int y;
            static public bool flag = true;
            int contador = 0;
            public static string ganador = "";
            static Random random = new Random();

            public Caballo(string nombre, int x, int y)
            {

                this.nombre = nombre;
                this.x = x;
                this.y = y;
                posicionInicial();
            }

            public void posicionInicial()
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(nombre);
                x = nombre.Length;
            }
            public void Correr()
            {
                while (flag)
                {
                    Thread.Sleep(100);
                    lock (l)
                    {
                        if (flag)
                        {


                            contador++;
                            int saltos = random.Next(0, 5);
                            x += saltos;
                            Console.SetCursorPosition(x, y);
                            Console.WriteLine("*");

                            if (x >= 60)
                            {
                                flag = false;


                                //Console.ForegroundColor = ConsoleColor.Green;

                                //Console.SetCursorPosition(x, y);
                                //Console.WriteLine("gane");
                                ganador = nombre;



                            }
                        }
                    }


                }

            }
        }
    }
}
