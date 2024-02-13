using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_1___Kevin_Guzmán
{
    internal class Program
    {
        int numerofactura = 0;
        int numeroplaca = 0;
        DateTime fecha = DateTime.Now;
        int tipovehiculo = 0;
        int numerocaseta = 0;
        double montopago = 0;
        double pagacon = 0;
        double vuelto = 0;

        static int[] numerofacturas = new int[15];
        static int[] numeroplacas = new int[15];
        static DateTime[] fechas = new DateTime[15];
        static int[] tipovehiculos = new int[15];
        static int[] numerocasetas = new int[15];
        static double[] montopagos = new double[15];
        static double[] pagacons = new double[15];
        static double[] vueltos = new double[15];
        static void Main(string[] args)
        {
            for (int i = 0; i < 15; i++)
            {
                numerofacturas[i] = 0;
                numeroplacas[i] = 0;
                fechas[i] = DateTime.MinValue;
                tipovehiculos[i] = 0;
                numerocasetas[i] = 0;
                montopagos[i] = 0;
                pagacons[i] = 0;
                vueltos[i] = 0;
            }
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("**** Menú Principal ****");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Inicializar vectores");
                Console.WriteLine("2. Ingresar Paso Vehicular");
                Console.WriteLine("3. Consulta de vehículos x Número de Placa");
                Console.WriteLine("4. Modificar datos Vehículos x número de placa");
                Console.WriteLine("5. Reporte Todos los datos de los vectores");
                Console.WriteLine("6. Salir");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Digite una opción... ");

                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1: InicializarVectores(); break;
                    case 2: IngresarPasoVehicular(); break;
                    case 3: Consultaxplaca(); break;
                    case 4: Modificaplaca(); break;
                    case 5: Reportevectores(); break;
                    case 6: return;
                    default:
                        Console.WriteLine("Opción no válida");
                        Console.ReadKey();
                        break;
                }
            }

            void InicializarVectores()
            {
                for (int i = 0; i < 15; i++)
                {
                    numerofacturas = Enumerable.Repeat(0, 15).ToArray<int>();
                    numeroplacas = Enumerable.Repeat(0, 15).ToArray<int>();
                    fechas = Enumerable.Repeat(DateTime.Parse("01/01/0001"), 15).ToArray<DateTime>();
                    tipovehiculos = Enumerable.Repeat(0, 15).ToArray<int>();
                    numerocasetas = Enumerable.Repeat(0, 15).ToArray<int>();
                    montopagos = Enumerable.Repeat(0.0, 15).ToArray<double>();
                    pagacons = Enumerable.Repeat(0.0, 15).ToArray<double>();
                    vueltos = Enumerable.Repeat(0.0, 15).ToArray<double>();
                }

                Console.WriteLine("Vectores inicializados correctamente");
                Console.ReadKey();
                Console.Clear();
            }

            void IngresarPasoVehicular()
            {
                bool continuar = true;
                int posicion = 0;

                while (continuar)
                {
                    if (posicion < 15)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        numerofacturas[posicion] = numerofacturas.Max() + 1;
                        Random rnd = new Random();
                        int ncaseta = rnd.Next(1, 3);
                        numerocasetas[posicion] = ncaseta;
                        Console.WriteLine("Número de caja random:  " + ncaseta);
                        fechas[posicion] = DateTime.Now;
                        Console.WriteLine("Digite el número de placa: ");
                        numeroplacas[posicion] = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite el tipo de vehículo que usted posee: (1.Moto 2.Vehículo Liviano 3.Camión/Pesado 4.Autobús)");
                        tipovehiculos[posicion] = int.Parse(Console.ReadLine());
                        montopagos[posicion] = 0;
                        if (tipovehiculos[posicion] == 1)
                        {
                            montopagos[posicion] = 500;
                        }
                        else if (tipovehiculos[posicion] == 2)
                        {
                            montopagos[posicion] = 700;
                        }
                        else if (tipovehiculos[posicion] == 3)
                        {
                            montopagos[posicion] = 2700;
                        }
                        else if (tipovehiculos[posicion] == 4)
                        {
                            montopagos[posicion] = 3700;
                        }
                        Console.WriteLine("Digite el monto con el que desea pagar: ");
                        pagacons[posicion] = double.Parse(Console.ReadLine());
                        vueltos[posicion] = pagacons[posicion] - montopagos[posicion];

                        Console.Clear();
                        int contador = 0;

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("**** Reporte de todos los pagos ****");
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("===============================================================================================================================");
                        Console.WriteLine("#Factura  Fecha/Hora       Placa      Tipo Vehículo        # Caseta          Monto Pagar           Paga Con         Vuelto    ");
                        Console.WriteLine("===============================================================================================================================");

                        for (int i = 0; i < 15; i++)
                        {
                            if (numerofacturas[i] == 0)
                            {
                                i = 15;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(numerofacturas[i].ToString().PadRight(10) + fechas[i].ToShortDateString().PadRight(12) + numeroplacas[i].ToString().PadRight(18) + tipovehiculos[i].ToString().PadRight(19) + numerocasetas[i].ToString().PadRight(22) + montopagos[i].ToString().PadRight(23) + pagacons[i].ToString().PadRight(25) + vueltos[i].ToString().PadRight(25));
                                contador = contador + 1;
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("¿Desea ingresar otro numero de placa? (S/N)");
                        string respuesta = Console.ReadLine().ToUpper();

                        if (respuesta == "N")
                        {
                            continuar = false;
                        }

                        posicion++;
                    }
                }
            }

            void Consultaxplaca()
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Digite el número de placa que desea buscar: ");
                    int buscaxplaca = int.Parse(Console.ReadLine());

                        Console.Clear();
                    double montototal = 0;
                    int contador = 0;

                    Console.WriteLine("Reporte de todos los pagos");
                    Console.WriteLine("");
                    Console.WriteLine("===============================================================================================================================");
                    Console.WriteLine("#Factura  Fecha/Hora       Placa      Tipo Vehículo          # Caseta          Monto Pagar         Paga Con      Vuelto    ");
                    Console.WriteLine("===============================================================================================================================");

                    for (int i = 0; i < 15; i++)
                    {
                        if (numeroplacas[i] == buscaxplaca)
                        {
                            i = 15;
                        }
                        else
                        {
                            Console.WriteLine(numerofacturas[i].ToString().PadRight(8) + fechas[i].ToShortDateString().PadRight(11) + numeroplacas[i].ToString().PadRight(12) + tipovehiculos[i].ToString().PadRight(16) + numerocasetas[i].ToString().PadRight(20) + montopagos[i].ToString().PadRight(20) + pagacons[i].ToString().PadRight(22) + vueltos[i].ToString().PadRight(24));
                            contador = contador + 1;
                        }
                    }
                    Console.WriteLine("");
                    Console.WriteLine("===============================================================================================================================");
                    Console.WriteLine("Total de registros: " + contador + "                                                                     Monto Total: " + montototal);
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error cargando los datos: " + e.Message);
                    Console.ReadKey();
                }
            }
            void Modificaplaca()
            {
                int numeroPlaca;
                bool encontrado = false;

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Ingrese el número de pago a modificar: ");
                numeroPlaca = int.Parse(Console.ReadLine());

                for (int i = 0; i < 10; i++)
                {
                    if (numeroplacas[i] == numeroPlaca)
                    {
                        encontrado = true;

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("**** Datos del pago ****");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Número de factura: {0}", numerofacturas[i]);
                        Console.WriteLine("Fecha: {0}", fechas[i]);
                        Console.WriteLine("Número de placa: {0}", numeroplacas[i]);
                        Console.WriteLine("Tipo de Vehículo: {0}", tipovehiculos[i]);
                        Console.WriteLine("Número de caseta: {0}", numerocasetas[i]);
                        Console.WriteLine("Monto a pagar: {0}", montopagos[i]);
                        Console.WriteLine("Monto con el que paga: {0}", pagacons[i]);
                        Console.WriteLine("Vuelto: {0}", vueltos[i]);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("¿Desea modificar algún dato? (S/N)");
                        string respuesta = Console.ReadLine().ToUpper();

                        if (respuesta == "S")
                        {
                            Modificaxplacas(i);
                        }

                        break;
                    }
                }

                if (!encontrado)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Pago no encontrado");
                }
            }
            void Modificaxplacas(int posicion)
            {
                int opcion;

                do
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("¿Qué dato desea modificar?");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("1. Número Factura");
                    Console.WriteLine("2. Número de Placa");
                    Console.WriteLine("3. Tipo de Vehículo");
                    Console.WriteLine("4. Número de Caseta");
                    Console.WriteLine("5. Monto a Pagar");
                    Console.WriteLine("6. Monto con el que paga");
                    Console.WriteLine("7. Salir");

                    opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Ingrese el nuevo número de factura: ");
                            numerofacturas[posicion] = int.Parse(Console.ReadLine());
                            break;
                        case 2:
                            Console.Write("Ingrese el nuevo número de placa: ");
                            numeroplacas[posicion] = int.Parse(Console.ReadLine());
                            break;
                        case 3:
                            Console.Write("Ingrese el tipo de vehículo: ");
                            tipovehiculos[posicion] = int.Parse(Console.ReadLine());
                            break;
                        case 4:
                            Console.Write("Ingrese el nuevo número de caseta: ");
                            numerocasetas[posicion] = int.Parse(Console.ReadLine());
                            break;
                        case 5:
                            Console.Write("Ingrese el nuevo monto a pagar: ");
                            montopagos[posicion] = int.Parse(Console.ReadLine());
                            break;
                        case 6:
                            Console.Write("Ingrese el nuevo monto con el que paga: ");
                            pagacons[posicion] = int.Parse(Console.ReadLine());
                            break;
                        case 7:
                            Console.WriteLine("Saliendo de la función Modificar Dato");
                            break;
                        default:
                            Console.WriteLine("Opción no válida");
                            break;
                    }

                    if (opcion >= 1 && opcion <= 7)
                    {
                        Console.WriteLine("Dato modificado correctamente");
                    }

                } while (opcion != 7);
            }

            void Reportevectores()
            {
                try
                {
                    Console.Clear();
                    double montototal = 0;
                    int contador = 0;



                    Console.WriteLine("Reporte de todos los pagos");
                    Console.WriteLine("");
                    Console.WriteLine("===============================================================================================================================");
                    Console.WriteLine("#Factura  Fecha/Hora       Placa      Tipo Vehículo          # Caseta          Monto Pagar         Paga Con      Vuelto    ");
                    Console.WriteLine("===============================================================================================================================");

                    for (int i = 0; i < 15; i++)
                    {
                        if (numerofacturas[i] == 0)
                        {
                            i = 15;
                        }
                        else
                        {
                            Console.WriteLine(numerofacturas[i].ToString().PadRight(8) + fechas[i].ToShortDateString().PadRight(11) + numeroplacas[i].ToString().PadRight(12) + tipovehiculos[i].ToString().PadRight(16) + numerocasetas[i].ToString().PadRight(20) + montopagos[i].ToString().PadRight(20) + pagacons[i].ToString().PadRight(22) + vueltos[i].ToString().PadRight(24));
                            contador = contador + 1;
                        }
                    }
                    Console.WriteLine("");
                    Console.WriteLine("===============================================================================================================================");
                    Console.WriteLine("Total de registros: " + contador + "                                                                     Monto Total: " + montototal);
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error cargando los datos: " + e.Message);
                    Console.ReadKey();
                }
            }
        }
    }
}
