﻿using System;
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
                    regprod();
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
        // obtener la ruta del archivo
        private static string direccion()
        {
            string path = @"C:\Users\hecto\Documents\ejercicios programacion\semana 5\productos.txt";
            return path;
        }
        // registro de productos
        private static void regprod()
        {
            Console.WriteLine("REGISTRO DE NUEVO PRODUCTO: ");
            Console.Write("NOMBRE DEL PRODUCTO: ");
            String nomprod = Console.ReadLine();
            Console.Write("PRECIO DEL PRODUCTO (ESCRIBIR EN DECIMALES): ");
            decimal precprod = Convert.ToDecimal(Console.ReadLine());

            using (StreamWriter pr = File.AppendText(direccion()))
            {
                pr.WriteLine("{0}; {1}", nomprod, precprod);
                pr.Close();
            }
        }
    }
}