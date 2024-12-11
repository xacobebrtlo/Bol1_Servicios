using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer6
{
    //solucionar, inicia sin presionar tecla
    internal class Program
    {
        static int counter = 0;
        static void increment()
        {
            counter++;
            Console.WriteLine(counter);
        }
        static void Main(string[] args)
        {
            MyTimer t = new MyTimer(increment);
            t.interval = 1000;
            string op = "";
            do
            {
                Console.WriteLine("Press any key to start.");
                Console.ReadKey();
                t.run();
                Console.WriteLine("Press any key to pause.");
                Console.ReadKey();
                t.pause();
                Console.WriteLine("Press 1 to contiue or Enter to end.");
                op = Console.ReadLine();
            } while (op == "1");
        }
    }
}
