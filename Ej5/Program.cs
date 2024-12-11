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
        static void Main(string[] args)
        {

            bool flag = true;
            while (flag)
            {
                int x = 0;
                int y = 0;
                Caballo[] caballos = new Caballo[5];
                Thread[] hilos = new Thread[5];
                for (int i = 0; i < caballos.Length; i++)
                {
                    y += 3;
                    Caballo caballo = new Caballo("Caballo" + (i + 1), x, y);
                    caballos[i] = caballo;
                    Thread hilo = new Thread(caballos[i].Correr);
                    hilos[i] = hilo;
                }
                Console.WriteLine("que caballo crees que va a ganar?");

                String respuestaUsuario = Console.ReadLine();
                hilos[0].Start();
                hilos[1].Start();
                hilos[2].Start();
                hilos[3].Start();
                hilos[4].Start();
                //hilos[0].Join();
                //hilos[1].Join();
                //hilos[2].Join();
                hilos[3].Join();
                //hilos[4].Join();
                Console.SetCursorPosition(0, 25);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("El caballo ganador es:" + Caballo.ganador);
                Console.ResetColor();
                if (Caballo.ganador == respuestaUsuario)
                {
                    Console.WriteLine("Has ganado!");
                    Console.WriteLine("Quieres volver a jugar?(Si/No)");

                    String respuesta = Console.ReadLine();
                    if (respuesta.ToUpper() == "SI")
                    {
                        Caballo.ganador = "";
                        Caballo.flag = true;

                        Console.Clear();
                        flag = true;
                    }

                }
                else
                {
                    Console.WriteLine("Has perdido");
                    flag = false;
                }
            };
            Console.ReadLine();

        }
    }
}
