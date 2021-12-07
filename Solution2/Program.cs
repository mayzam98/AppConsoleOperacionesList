using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution2
{
    class Program
    {
        static void Main(string[] args)
        {


            //Declaracion de variables
            
            List<int> listaElementos = new List<int>();
            

            encabezado();
            listaElementos = solicitarElementos();
            

            while (true)
            {
                listaElementos = procesamientoLista(listaElementos);
            }


        }

        public static string Menu()
        {
            string op;
            Console.WriteLine("Ingrese la operacion a realizar: ");
            Console.WriteLine("\ta - Ordenar menor a mayor");
            Console.WriteLine("\td - Ordenar mayor a menor");
            Console.WriteLine("\tb - Buscar elemento");
            Console.WriteLine("\te - Agregar Elemento");
            Console.WriteLine("\tl - Listar repetidos");
            Console.WriteLine("\tx - Para salir");
            Console.Write("Your option? ");
            op = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("RESULTADO:");
            return op;

        }
        public static List<int> OrdenarMenorMayor(List<int> list)
        {
            List<int> listaOrdenada = new List<int>();
            listaOrdenada = list.OrderBy(x => x).ToList();
            return listaOrdenada;
        }
        public static List<int> OrdenarMayorMenor(List<int> list)
        {
            List<int> listaOrdenada = new List<int>();
            listaOrdenada = list.OrderByDescending(x => x).ToList();
            return listaOrdenada;
        }

        public static void encabezado()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("*******   Console Prueba2 en C#   *******\r");
            Console.WriteLine("*****************************************\n");

        }
        public static List<int> solicitarElementos()
        {
            int numElementos = 0;
            int contador = 0;
            int valorEntrada = 0;
            List<int> listaElementos = new List<int>();

            while (numElementos == 0)
            {
                Console.Write("Ingrese la cantidad n de elementos: ");
                try {
                    numElementos = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\n");
                }
                catch (Exception)
                {

                }

            }

            while (contador < numElementos)
            {
                Console.Write($"Ingrese el elemento: {contador}  de la lista: ");
                try
                {
                    valorEntrada = Convert.ToInt32(Console.ReadLine());
                    listaElementos.Add(valorEntrada);
                    listaElementos.Sort();
                    contador++;
                }
                catch (Exception)
                {

                }

            }
            Console.Clear();
            encabezado();
            
            return listaElementos;
        }

        private static void mostrarListaActual(List<int> list){
            Console.WriteLine("Su lista actual es:");
            list.ForEach(Console.WriteLine);
            Console.WriteLine();
            }

        private static List<int> procesamientoLista(List<int> listaElementos)
        {

            //List<int> listaElementosProcesados = new List<int>();
            var elementoBuscado = 0;
            var indiceElementoBuscado = 0;
            var elementoNuevo = 0;
            String op;

            mostrarListaActual(listaElementos);
            op = Menu();
            switch (op)
            {
                case "d":
                    listaElementos = OrdenarMayorMenor(listaElementos);
                    listaElementos.ForEach(Console.WriteLine);
                    break;
                case "a":
                    listaElementos = OrdenarMenorMayor(listaElementos);
                    listaElementos.ForEach(Console.WriteLine);
                    break;
                case "b":

                    Console.WriteLine("Ingrese el elemento a buscar: ");
                    elementoBuscado = Convert.ToInt32(Console.ReadLine());
                    indiceElementoBuscado = listaElementos.IndexOf(elementoBuscado);
                    if (indiceElementoBuscado != -1)
                    {
                        Console.WriteLine($"El elemento buscado se encuentra en la posicion: {indiceElementoBuscado} de la lista");
                        foreach (var elemento in listaElementos)
                        {
                            if (elementoBuscado == elemento)
                                Console.Write(">");
                            Console.WriteLine(elemento);
                        }
                    }
                    else
                    {
                        Console.WriteLine("El elemento no se encuentra en la lista.");
                    }

                    break;
                case "e":
                    Console.WriteLine("Ingrese el valor del elemento a agregar: ");
                    elementoNuevo = Convert.ToInt32(Console.ReadLine());
                    listaElementos.Add(elementoNuevo);
                    foreach (var elemento in listaElementos)
                    {
                        if (elementoNuevo == elemento)
                            Console.Write(">");
                        Console.WriteLine(elemento);

                    }
                    break;
                case "l":
                    var listaDuplicados = new List<int>();
                    var hashset = new HashSet<string>();
                    foreach (var elemento in listaElementos)
                    {
                        if (!hashset.Add(elemento.ToString()))
                        {

                            listaDuplicados.Add(elemento);


                        }
                    }
                    if (listaDuplicados.Count == 0)
                    {
                        Console.WriteLine("No hay elementos Duplicados");
                    }
                    else
                    {
                        Console.WriteLine("Los elementos duplicados son los siguentes: ");
                        listaDuplicados.ForEach(Console.WriteLine);
                    }
                    break;
                case "x":
                    Console.WriteLine("Preparate para salir");
                    Environment.Exit(0);

                    break;

                default:
                    Console.WriteLine("Entrada no valida.");
                    break;
            }
            Console.Write("Precione Enter para continuar");
            Console.ReadLine();
            Console.Clear();

            encabezado();
            return listaElementos;

        }
    }
    }

