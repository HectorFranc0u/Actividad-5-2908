using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Actividad_5_2908
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
                    actualizar();
                    Console.ReadKey();
                    return true;
                case "3":
                    Console.WriteLine("LISTADO DE PRODUCTOS REGISTRADOS.");
                    foreach (KeyValuePair<object, object> data in leer())
                    {
                        Console.Write("{0}; ${1}", data.Key, data.Value);
                        Console.WriteLine("");
                    }
                    Console.ReadKey();
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
        private static Dictionary<object, object> leer()
        {
            Dictionary<object, object> listdata = new Dictionary<object, object>();
            using (var reader = new StreamReader(direccion()))
            {
                string lines;
                while ((lines = reader.ReadLine()) != null)
                {
                    string[] keyvalue = lines.Split(';');
                    if (keyvalue.Length == 2)
                    {
                        listdata.Add(keyvalue[0], keyvalue[1]);
                    }
                }
            }
            return listdata;
        }

        private static bool search(string name)
        {
            if (!leer().ContainsKey(name))
            {
                return false;
            }
            return true;
        }

        private static void actualizar()
        {
            Console.Write("ESCRIBA EL NOMBRE DEL PRODUCTO A ACTUALIZAR. ");
            var name = Console.ReadLine();

            if (search(name))
            {
                Console.WriteLine("EL REGISTRO EXISTE");
                Console.Write("INGRESE EL NUEVO PRECIO (UTILIZAR DECIMALES) ");
                var nuevoprecio = Convert.ToDecimal(Console.ReadLine());

                Dictionary<object, object> temp = new Dictionary<object, object>();
                temp = leer();
                temp[name] = nuevoprecio;
                Console.WriteLine("SE ACTUALIZO EL PRECIO");
                File.Delete(direccion());

                using (StreamWriter sw = File.AppendText(direccion()))
                {
                    foreach (KeyValuePair<object, object> values in temp)
                    {
                        sw.WriteLine("{0}; {1}", values.Key, values.Value);
                    }
                }
            }
            else
            {
                Console.WriteLine("NO SE ENCONTRO EL REGISTRO.");
            }
        }
    }
}
