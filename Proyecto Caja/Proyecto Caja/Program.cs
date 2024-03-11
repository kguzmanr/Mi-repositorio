// See https://aka.ms/new-console-template for more information

int numeroPago = 0;
DateTime fecha = DateTime.Now;
int cedula = 0;
string nombre = "";
string apellido1 = "";
string apellido2 = "";
int numeroCaja = 0;
int tipoServicio = 0;
string numeroFactura = "";
decimal montoAPagar = 0;
decimal montoComision = 0;
decimal montoDeducido = 0;
decimal montoPagaCliente = 0;
decimal vuelto = 0;
int servicioElectrico = 0;
int servicioTelefonico = 0;
int servicioAgua = 0;

int[] numeroPagos = new int[10];
DateTime[] fechas = new DateTime[10];
int[] cedulas = new int[10];
string[] nombres = new string[10];
string[] apellidos1 = new string[10];
string[] apellidos2 = new string[10];
int[] numerosCaja = new int[10];
int[] tiposServicio = new int[10];
string[] numerosFactura = new string[10];
decimal[] montosAPagar = new decimal[10];
decimal[] montosComision = new decimal[10];
decimal[] montosDeducido = new decimal[10];
decimal[] montosPagaCliente = new decimal[10];
decimal[] vueltos = new decimal[10];


for (int i = 0; i < 10; i++)
{
    numeroPagos[i] = 0;
    fechas[i] = DateTime.MinValue;
    cedulas[i] = 0;
    nombres[i] = "";
    apellidos1[i] = "";
    apellidos2[i] = "";
    numerosCaja[i] = 0;
    tiposServicio[i] = 0;
    numerosFactura[i] = "";
    montosAPagar[i] = 0;
    montosComision[i] = 0;
    montosDeducido[i] = 0;
    montosPagaCliente[i] = 0;
    vueltos[i] = 0;
}
while (true)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("**** Menú Principal ****");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("1. Inicializar Vectores");
    Console.WriteLine("2. Realizar Pagos");
    Console.WriteLine("3. Consultar Pagos");
    Console.WriteLine("4. Modificar Pagos");
    Console.WriteLine("5. Eliminar Pagos");
    Console.WriteLine("6. Submenú Reportes");
    Console.WriteLine("7. Salir");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("Digite una opción...");

    int opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1: InicializarVectores(); break;
        case 2: RealizarPagos(); break;
        case 3: ConsultarPagos(); break;
        case 4: ModificarPagos(); break;
        case 5: EliminarPagos(); break;
        case 6: SubmenuReportes(); break;
        case 7: return;
        default:
            Console.WriteLine("Opción no válida");
            Console.ReadKey();
            break;
    }
}
void InicializarVectores()
{

    {
        for (int i = 0; i < 10; i++)
        {
            numeroPagos[i] = 0;
            fechas[i] = DateTime.MinValue;
            cedulas[i] = 0;
            nombres[i] = "";
            apellidos1[i] = "";
            apellidos2[i] = "";
            numerosCaja[i] = 0;
            tiposServicio[i] = 0;
            numerosFactura[i] = "";
            montosAPagar[i] = 0;
            montosComision[i] = 0;
            montosDeducido[i] = 0;
            montosPagaCliente[i] = 0;
            vueltos[i] = 0;
        }

        Console.WriteLine("Vectores inicializados correctamente");
        Console.ReadKey();
        Console.Clear();
    }
}
void RealizarPagos()
{
    bool continuar = true;
    int posicion = 0;

    while (continuar)
    {
        if (posicion < 10)
        {
            numeroPagos[posicion] = numeroPagos.Max() + 1;
            fechas[posicion] = DateTime.Now;
            Console.Write("Ingrese la cédula: ");
            cedulas[posicion] = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el nombre: ");
            nombres[posicion] = Console.ReadLine();
            Console.Write("Ingrese el apellido 1: ");
            apellidos1[posicion] = Console.ReadLine();
            Console.Write("Ingrese el apellido 2: ");
            apellidos2[posicion] = Console.ReadLine();
            numerosCaja[posicion] = new Random().Next(1, 4);
            Console.Write("Ingrese el tipo de servicio (1=Luz, 2=Teléfono, 3=Agua): ");
            tiposServicio[posicion] = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el número de factura: ");
            numerosFactura[posicion] = Console.ReadLine();
            Console.Write("Ingrese el monto a pagar: ");
            montosAPagar[posicion] = decimal.Parse(Console.ReadLine());

            // Calcular comisión, monto deducido y vuelto
            switch (tiposServicio[posicion])
            {
                case 1:
                    montosComision[posicion] = montosAPagar[posicion] * 0.04m;
                    servicioElectrico++;
                    break;
                case 2:
                    montosComision[posicion] = montosAPagar[posicion] * 0.055m;
                    servicioTelefonico++;
                    break;
                case 3:
                    montosComision[posicion] = montosAPagar[posicion] * 0.065m;
                    servicioAgua++;
                    break;
            }

            montosDeducido[posicion] = montosAPagar[posicion] - montosComision[posicion];

            Console.Write("Ingrese el monto que paga el cliente: ");
            montosPagaCliente[posicion] = decimal.Parse(Console.ReadLine());

            vueltos[posicion] = montosPagaCliente[posicion] - montosAPagar[posicion];

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("**** Resumen del pago ****");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Número de pago: {0}", numeroPagos[posicion]);
            Console.WriteLine("Fecha: {0}", fechas[posicion]);
            Console.WriteLine("Cédula: {0}", cedulas[posicion]);
            Console.WriteLine("Nombre: {0} {1} {2}", nombres[posicion], apellidos1[posicion], apellidos2[posicion]);
            Console.WriteLine("Número de caja: {0}", numerosCaja[posicion]);
            Console.WriteLine("Tipo de servicio: {0}", tiposServicio[posicion]);
            Console.WriteLine("Número de factura: {0}", numerosFactura[posicion]);
            Console.WriteLine("Monto a pagar: {0}", montosAPagar[posicion]);
            Console.WriteLine("Monto comisión: {0}", montosComision[posicion]);
            Console.WriteLine("Monto deducido: {0}", montosDeducido[posicion]);
            Console.WriteLine("Monto paga cliente: {0}", montosPagaCliente[posicion]);
            Console.WriteLine("Vuelto: {0}", vueltos[posicion]);


            Console.WriteLine("¿Desea realizar otro pago? (S/N)");
            string respuesta = Console.ReadLine().ToUpper();

            if (respuesta == "N")
            {
                continuar = false;
            }

            posicion++;
        }
        else
        {
            Console.WriteLine("Vectores llenos. No se pueden realizar más pagos.");
            continuar = false;
        }
    }
}


void ConsultarPagos()

{
    int numeroPago;
    bool encontrado = false;

    Console.Write("Ingrese el número de pago a consultar: ");
    numeroPago = int.Parse(Console.ReadLine());

    for (int i = 0; i < 10; i++)
    {
        if (numeroPagos[i] == numeroPago)
        {
            encontrado = true;

            Console.WriteLine("**Datos del pago**");
            Console.WriteLine("Número de pago: {0}", numeroPagos[i]);
            Console.WriteLine("Fecha: {0}", fechas[i]);
            Console.WriteLine("Cédula: {0}", cedulas[i]);
            Console.WriteLine("Nombre: {0} {1} {2}", nombres[i], apellidos1[i], apellidos2[i]);
            Console.WriteLine("Número de caja: {0}", numerosCaja[i]);
            Console.WriteLine("Tipo de servicio: {0}", tiposServicio[i]);
            Console.WriteLine("Número de factura: {0}", numerosFactura[i]);
            Console.WriteLine("Monto a pagar: {0}", montosAPagar[i]);
            Console.WriteLine("Monto comisión: {0}", montosComision[i]);
            Console.WriteLine("Monto deducido: {0}", montosDeducido[i]);
            Console.WriteLine("Monto paga cliente: {0}", montosPagaCliente[i]);
            Console.WriteLine("Vuelto: {0}", vueltos[i]);
            string respuesta = Console.ReadLine().ToUpper();
        }
    }

    if (!encontrado)
    {
        Console.WriteLine("Pago no encontrado");
    }
}


void ModificarPagos()
{
    int numeroPago;
    bool encontrado = false;

    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write("Ingrese el número de pago a modificar: ");
    numeroPago = int.Parse(Console.ReadLine());

    for (int i = 0; i < 10; i++)
    {
        if (numeroPagos[i] == numeroPago)
        {
            encontrado = true;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("**** Datos del pago ****");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Número de pago: {0}", numeroPagos[i]);
            Console.WriteLine("Fecha: {0}", fechas[i]);
            Console.WriteLine("Cédula: {0}", cedulas[i]);
            Console.WriteLine("Nombre: {0} {1} {2}", nombres[i], apellidos1[i], apellidos2[i]);
            Console.WriteLine("Número de caja: {0}", numerosCaja[i]);
            Console.WriteLine("Tipo de servicio: {0}", tiposServicio[i]);
            Console.WriteLine("Número de factura: {0}", numerosFactura[i]);
            Console.WriteLine("Monto a pagar: {0}", montosAPagar[i]);
            Console.WriteLine("Monto comisión: {0}", montosComision[i]);
            Console.WriteLine("Monto deducido: {0}", montosDeducido[i]);
            Console.WriteLine("Monto paga cliente: {0}", montosPagaCliente[i]);
            Console.WriteLine("Vuelto: {0}", vueltos[i]);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("¿Desea modificar algún dato? (S/N)");
            string respuesta = Console.ReadLine().ToUpper();

            if (respuesta == "S")
            {
                ModificarDato(i);
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
void ModificarDato(int posicion)
{
    int opcion;

    do
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("¿Qué dato desea modificar?");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("1. Fecha");
        Console.WriteLine("2. Cédula");
        Console.WriteLine("3. Nombre");
        Console.WriteLine("4. Apellido 1");
        Console.WriteLine("5. Apellido 2");
        Console.WriteLine("6. Número de caja");
        Console.WriteLine("7. Tipo de servicio");
        Console.WriteLine("8. Número de factura");
        Console.WriteLine("9. Monto a pagar");
        Console.WriteLine("10. Salir");

        opcion = int.Parse(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                Console.Write("Ingrese la nueva fecha: ");
                fechas[posicion] = DateTime.Parse(Console.ReadLine());
                break;
            case 2:
                Console.Write("Ingrese la nueva cédula: ");
                cedulas[posicion] = int.Parse(Console.ReadLine());
                break;
            case 3:
                Console.Write("Ingrese el nuevo nombre: ");
                nombres[posicion] = Console.ReadLine();
                break;
            case 4:
                Console.Write("Ingrese el nuevo apellido 1: ");
                apellidos1[posicion] = Console.ReadLine();
                break;
            case 5:
                Console.Write("Ingrese el nuevo apellido 2: ");
                apellidos2[posicion] = Console.ReadLine();
                break;
            case 6:
                Console.Write("Ingrese el nuevo número de caja: ");
                numerosCaja[posicion] = int.Parse(Console.ReadLine());
                break;
            case 7:
                Console.Write("Ingrese el nuevo tipo de servicio: ");
                tiposServicio[posicion] = int.Parse(Console.ReadLine());
                break;
            case 8:
                Console.Write("Ingrese el nuevo número de factura: ");
                numerosFactura[posicion] = Console.ReadLine();
                break;
            case 9:
                Console.Write("Ingrese el nuevo monto a pagar: ");
                montosAPagar[posicion] = decimal.Parse(Console.ReadLine());
                montosComision[posicion] = montosAPagar[posicion] * 0.04m;
                montosDeducido[posicion] = montosAPagar[posicion] - montosComision[posicion];
                break;
            case 10:
                Console.WriteLine("Saliendo de la función Modificar Dato");
                break;
            default:
                Console.WriteLine("Opción no válida");
                break;
        }

        if (opcion >= 1 && opcion <= 10)
        {
            Console.WriteLine("Dato modificado correctamente");
        }

    } while (opcion != 10);
}

void EliminarPagos()
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write("Ingrese el número de pago que desea eliminar: ");
    int numeroPago = int.Parse(Console.ReadLine());
    bool encontrado = false;

    for (int i = 0; i < 10; i++)
    {
        if (numeroPagos[i] == numeroPago)
        {
            encontrado = true;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("**** Datos del pago a eliminar ****");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Número de pago: {0}", numeroPagos[i]);
            Console.WriteLine("Fecha: {0}", fechas[i]);
            Console.WriteLine("Cédula: {0}", cedulas[i]);
            Console.WriteLine("Nombre: {0} {1} {2}", nombres[i], apellidos1[i], apellidos2[i]);
            Console.WriteLine("Número de caja: {0}", numerosCaja[i]);
            Console.WriteLine("Tipo de servicio: {0}", tiposServicio[i]);
            Console.WriteLine("Número de factura: {0}", numerosFactura[i]);
            Console.WriteLine("Monto a pagar: {0}", montosAPagar[i]);
            Console.WriteLine("Monto comisión: {0}", montosComision[i]);
            Console.WriteLine("Monto deducido: {0}", montosDeducido[i]);
            Console.WriteLine("Monto paga cliente: {0}", montosPagaCliente[i]);
            Console.WriteLine("Vuelto: {0}", vueltos[i]);

            Console.Write("¿Está seguro de eliminar el dato? (S/N): ");
            string respuesta = Console.ReadLine().ToUpper();

            if (respuesta == "S")
            {
                numeroPagos[i] = 0;
                fechas[i] = DateTime.MinValue;
                cedulas[i] = 0;
                nombres[i] = "";
                apellidos1[i] = "";
                apellidos2[i] = "";
                numerosCaja[i] = 0;
                tiposServicio[i] = 0;
                numerosFactura[i] = "";
                montosAPagar[i] = 0;
                montosComision[i] = 0;
                montosDeducido[i] = 0;
                montosPagaCliente[i] = 0;
                vueltos[i] = 0;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("La información fue eliminada.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("La información no fue eliminada.");
            }

            break;
        }
    }

    if (!encontrado)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Pago no se encuentra registrado.");
    }

    Console.ReadKey();
    Console.Clear();
}
void SubmenuReportes()
{
    int opcionReportes;

    do
    {
        Console.Clear();

        Console.WriteLine("Submenú Reportes");
        Console.WriteLine("1. Ver todos los Pagos");
        Console.WriteLine("2. Ver Pagos por tipo de Servicio");
        Console.WriteLine("3. Ver Pagos por código de caja");
        Console.WriteLine("4. Ver Dinero Comisionado por servicios");
        Console.WriteLine("5. Regresar Menú Principal");

        Console.Write("Ingrese una opción: ");
        if (int.TryParse(Console.ReadLine(), out opcionReportes))
        {
            switch (opcionReportes)
            {
                case 1:
                    VerTodosLosPagos();
                    break;
                case 2:
                    VerPagosPorTipoServicio();
                    break;
                case 3:
                    VerPagosPorCodigoCaja();
                    break;
                case 4:
                    VerDineroComisionadoPorServicios();
                    break;
                case 5:
                    Console.WriteLine("Regresando al Menú Principal...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Por favor, ingrese un número válido.");
        }

        Console.WriteLine();
    } while (opcionReportes != 5);
}

void VerTodosLosPagos()
{
    try
    {
        Console.Clear();
        int contador = 0;

        Console.WriteLine("Reporte de todos los pagos");
        Console.WriteLine("");
        Console.WriteLine("===============================================================================================================================");
        Console.WriteLine("# Pago  Fecha      Hora       Cédula      Nombre          Apellido 1          ApelLido 2          Monto Recibo          ");
        Console.WriteLine("===============================================================================================================================");

        for (int i = 0; i < 10; i++)
        {
            if (numeroPagos[i] == 0)
            {
                i = 10;
            }
            else
            {
                Console.WriteLine(numeroPagos[i].ToString().PadRight(8) + fechas[i].ToShortDateString().PadRight(11) + cedulas[i].ToString().PadRight(12) + nombres[i].ToString().PadRight(16) + apellidos1[i].ToString().PadRight(20) + apellidos2[i].ToString().PadRight(20) + montosAPagar[i].ToString().PadRight(22));
                contador = contador + 1;
            }
        }

        Console.WriteLine("");
        Console.WriteLine("===============================================================================================================================");
        Console.WriteLine("Total de registros: " + contador + "                                                                     Monto Total: " + montosAPagar);
        Console.ReadKey();
    }
    catch (Exception e)
    {
        Console.WriteLine("Error cargando los datos: " + e.Message);
        Console.ReadKey();
    }
}

void VerPagosPorTipoServicio()
{
    try
    {

        Console.Clear();

        Console.WriteLine("Digite el Tipo de Servicio ([1] recibo de luz, [2] servicio telefonico, [3] recibo de agua): ");
        int tipodeservicio = int.Parse(Console.ReadLine());

        if (tipodeservicio > 3)
        {
            Console.WriteLine("El Tipo de Servicio no puede ser mayor a 3");
            Console.ReadKey();
            return;
        }

        Console.Clear();
        int contador = 0;

        Console.WriteLine("Reporte de todos los pagos por Tipo de Servicio");
        Console.WriteLine("");
        Console.WriteLine("===============================================================================================================================");
        Console.WriteLine("# Pago  Fecha/Hora       Cédula      Nombre          Apellido 1          ApelLido 2          Monto Recibo          ");
        Console.WriteLine("===============================================================================================================================");

        for (int i = 0; i < 10; i++)
        {
            if (numeroPagos[i] == 0)
            {
                i = 10;
            }
            else
            {
                if (tiposServicio[i] == tipodeservicio)
                {
                    Console.WriteLine(numeroPagos[i].ToString().PadRight(8) + fechas[i].ToShortDateString().PadRight(11) + cedulas[i].ToString().PadRight(12) + nombres[i].ToString().PadRight(16) + apellidos1[i].ToString().PadRight(20) + apellidos2[i].ToString().PadRight(20) + montosAPagar[i].ToString().PadRight(22));
                    contador = contador + 1;
                }
            }
        }

        Console.WriteLine("");
        Console.WriteLine("===============================================================================================================================");
        Console.WriteLine("Total de registros: " + contador + "                                                                     Monto Total: " + montosAPagar);
        Console.ReadKey();
    }
    catch (Exception e)
    {
        Console.WriteLine("Error cargando los datos: " + e.Message);
        Console.ReadKey();
    }
}

void VerPagosPorCodigoCaja()
{
    try
    {

        Console.Clear();

        Console.WriteLine("Digite el Número de Caja (rango entre 1 y 3): ");
        int numerodecaja = int.Parse(Console.ReadLine());

        if (numerodecaja > 3)
        {
            Console.WriteLine("El Número de Caja no puede ser mayor a 3");
            Console.ReadKey();
            return;
        }

        Console.Clear();
        int contador = 0;

        Console.WriteLine("Reporte de todos los pagos por Código de Cajero");
        Console.WriteLine("");
        Console.WriteLine("===============================================================================================================================");
        Console.WriteLine("# Pago  Fecha      Hora       Cédula      Nombre          Apellido 1          ApelLido 2          Monto Recibo          ");
        Console.WriteLine("===============================================================================================================================");

        for (int i = 0; i < 10; i++)
        {
            if (numeroPagos[i] == 0)
            {
                i = 10;
            }
            else
            {
                if (numerosCaja[i] == numerodecaja)
                {
                    Console.WriteLine(numeroPagos[i].ToString().PadRight(8) + fechas[i].ToShortDateString().PadRight(11) + cedulas[i].ToString().PadRight(12) + nombres[i].ToString().PadRight(16) + apellidos1[i].ToString().PadRight(20) + apellidos2[i].ToString().PadRight(20) + montosAPagar[i].ToString().PadRight(22));
                    contador = contador + 1;
                }
            }
        }

        Console.WriteLine("");
        Console.WriteLine("===============================================================================================================================");
        Console.WriteLine("Total de registros: " + contador + "                                                                     Monto Total: " + montosAPagar);
        Console.ReadKey();
    }
    catch (Exception e)
    {
        Console.WriteLine("Error cargando los datos: " + e.Message);
        Console.ReadKey();
    }

}
void VerDineroComisionadoPorServicios()
{
    try
    {
        Console.Clear();
        int cantElectricidad = 0;
        int cantTelefono = 0;
        int cantAgua = 0;
        decimal comisionElectricidad = 0;
        decimal comisionTelefono = 0;
        decimal comisionAgua = 0;
        int contador = 0;

        Console.WriteLine("Reporte de dinero comisionado - Desglose por Tipo de Servicio");
        Console.WriteLine("");
        Console.WriteLine("===============================================================================");
        Console.WriteLine("ITEM              Cantidad de Transacciones         Total Comisionado          ");
        Console.WriteLine("===============================================================================");

        for (int i = 0; i < 10; i++)
        {
            if (numeroPagos[i] == 0)
            {
                break; // Salir del bucle si no hay más pagos registrados
            }

            switch (tiposServicio[i])
            {
                case 1:
                    cantElectricidad++;
                    comisionElectricidad += montosComision[i];
                    break;
                case 2:
                    cantTelefono++;
                    comisionTelefono += montosComision[i];
                    break;
                case 3:
                    cantAgua++;
                    comisionAgua += montosComision[i];
                    break;
            }

            contador++;
        }

        Console.WriteLine("1-Electricidad   " + cantElectricidad.ToString().PadRight(34) + comisionElectricidad.ToString());
        Console.WriteLine("2-Teléfono       " + cantTelefono.ToString().PadRight(34) + comisionTelefono.ToString());
        Console.WriteLine("3-Agua           " + cantAgua.ToString().PadRight(34) + comisionAgua.ToString());
        Console.WriteLine("===============================================================================");
        Console.WriteLine("");
        Console.WriteLine("Total:           " + contador.ToString().PadRight(34) + (comisionElectricidad + comisionTelefono + comisionAgua).ToString());
        Console.WriteLine("");
        Console.WriteLine("===============================================================================");
        Console.ReadKey();
    }
    catch (Exception e)
    {
        Console.WriteLine("Error cargando los datos: " + e.Message);
        Console.ReadKey();
    }
}
