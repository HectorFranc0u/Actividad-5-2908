using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace semana5
{
    class Program
    {
        static void Main(string[] args)
        {
            bool menu = true;
            while (menu)
            {
                menu = menuprincipal();
            }
            Console.ReadKey();
        }

        // menu principal de la consola
        private static bool menuprincipal()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("1 - INGRESAR PRODUCTO Y PRECIO");
            Console.WriteLine("2 - ACTUALIZAR CARACTERISTICAS DE UN PRODUCTO");
            Console.WriteLine("3 - MOSTRAR LISTADO DE PRODUCTOS");
            Console.WriteLine("4 - CERRAR CONSOLA");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("ESCRIBA LA ACCION A REALIZAR.");

            switch (Console.ReadLine())
            {
                case "1":
                    return true;
                case "2":
                    return true;
                case "3":
                    return true;
                case "4":
                    return false;
                default:
                    return false;
            }
        }
    }
}