using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bol1_Servicios
{
    internal class Program
    {
        //public static void view(int grade)
        //{
        //    Console.ForegroundColor = grade >= 5 ? ConsoleColor.Green : ConsoleColor.Red;
        //    Console.WriteLine($"Student grade: {grade,3}.");
        //    Console.ResetColor();
        //}
        //public static bool pass(int num)
        //{
        //    return num >= 5;
        //}
        static void Main(string[] args)
        {
            int[] v = { 2, 2, 6, 7, 1, 10, 3 };
            Array.ForEach(v, (n) =>
            {
                Console.ForegroundColor = n >= 5 ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine($"Student grade:{n,3}.");
                Console.ResetColor();
            });


            int res = Array.FindIndex(v, (n) => n >= 5);
            Console.WriteLine($"The first passing student is number {res + 1} in the list.");


            //Saber si hay un aprobado
            bool resultado = Array.Exists(v, (n) => n >= 5);
            Console.WriteLine("Did someone pass?");
            Console.WriteLine(resultado ? "Yes" : "No");



            //indicar la posición del ultimo aprovado
            int ultimoAprobado = Array.FindLastIndex(v, (n) => n >= 5);
            Console.WriteLine($"El ultimo aprobado es: {ultimoAprobado}");

            //Mostrar el inverso de todos los valores del array
            Array.ForEach(v, (n) =>
            {
                Console.WriteLine($"El inverso de {n} es: {1f / n}");
            });

            Console.ReadKey();
        }
    }
}
