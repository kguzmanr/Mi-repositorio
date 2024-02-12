// See https://aka.ms/new-console-template for more information

int numeroPago = 0;
DateTime fecha = DateTime.Now;
TimeSpan hora = TimeSpan.Zero;
string cedula = "";
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

int[] numeroPagos = new int[10];
DateTime[] fechas = new DateTime[10];
TimeSpan[] horas = new TimeSpan[10];
string[] cedulas = new string[10];
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
    horas[i] = TimeSpan.Zero;
    cedulas[i] = "";
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
    Console.WriteLine("**Menú Principal**");
    Console.WriteLine("1. Inicializar Vectores");
    Console.WriteLine("2. Realizar Pagos");
    Console.WriteLine("3. Consultar Pagos");
    Console.WriteLine("4. Modificar Pagos");
    Console.WriteLine("5. Eliminar Pagos");
    Console.WriteLine("6. Submenú Reportes");
    Console.WriteLine("7. Salir");

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
            horas[i] = TimeSpan.Zero;
            cedulas[i] = "";
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
            horas[posicion] = TimeSpan.FromHours(DateTime.Now.Hour);
            Console.Write("Ingrese la cédula: ");
            cedulas[posicion] = Console.ReadLine();
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
                    break;
                case 2:
                    montosComision[posicion] = montosAPagar[posicion] * 0.055m;
                    break;
                case 3:
                    montosComision[posicion] = montosAPagar[posicion] * 0.065m;
                    break;
            }

            montosDeducido[posicion] = montosAPagar[posicion] - montosComision[posicion];

            Console.Write("Ingrese el monto que paga el cliente: ");
            montosPagaCliente[posicion] = decimal.Parse(Console.ReadLine());

            vueltos[posicion] = montosPagaCliente[posicion] - montosAPagar[posicion];


            Console.WriteLine("**Resumen del pago**");
            Console.WriteLine("Número de pago: {0}", numeroPagos[posicion]);
            Console.WriteLine("Fecha: {0}", fechas[posicion]);
            Console.WriteLine("Hora: {0}", horas[posicion]);
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
            Console.WriteLine("Hora: {0}", horas[i]);
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

    Console.Write("Ingrese el número de pago a modificar: ");
    numeroPago = int.Parse(Console.ReadLine());

    for (int i = 0; i < 10; i++)
    {
        if (numeroPagos[i] == numeroPago)
        {
            encontrado = true;

            Console.WriteLine("**Datos del pago**");
            Console.WriteLine("Número de pago: {0}", numeroPagos[i]);
            Console.WriteLine("Fecha: {0}", fechas[i]);
            Console.WriteLine("Hora: {0}", horas[i]);
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
        Console.WriteLine("Pago no encontrado");
    }
}
void ModificarDato(int posicion)
{
    int opcion;

    do
    {
        Console.WriteLine("**¿Qué dato desea modificar?**");
        Console.WriteLine("1. Fecha");
        Console.WriteLine("2. Hora");
        Console.WriteLine("3. Cédula");
        Console.WriteLine("4. Nombre");
        Console.WriteLine("5. Apellido 1");
        Console.WriteLine("6. Apellido 2");
        Console.WriteLine("7. Número de caja");
        Console.WriteLine("8. Tipo de servicio");
        Console.WriteLine("9. Número de factura");
        Console.WriteLine("10. Monto a pagar");
        Console.WriteLine("11. Salir");

        opcion = int.Parse(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                Console.Write("Ingrese la nueva fecha: ");
                fechas[posicion] = DateTime.Parse(Console.ReadLine());
                break;
            case 2:
                Console.Write("Ingrese la nueva hora: ");
                horas[posicion] = TimeSpan.Parse(Console.ReadLine());
                break;
            case 3:
                Console.Write("Ingrese la nueva cédula: ");
                cedulas[posicion] = Console.ReadLine();
                break;
            case 4:
                Console.Write("Ingrese el nuevo nombre: ");
                nombres[posicion] = Console.ReadLine();
                break;
            case 5:
                Console.Write("Ingrese el nuevo apellido 1: ");
                apellidos1[posicion] = Console.ReadLine();
                break;
            case 6:
                Console.Write("Ingrese el nuevo apellido 2: ");
                apellidos2[posicion] = Console.ReadLine();
                break;
            case 7:
                Console.Write("Ingrese el nuevo número de caja: ");
                numerosCaja[posicion] = int.Parse(Console.ReadLine());
                break;
            case 8:
                Console.Write("Ingrese el nuevo tipo de servicio: ");
                tiposServicio[posicion] = int.Parse(Console.ReadLine());
                break;
            case 9:
                Console.Write("Ingrese el nuevo número de factura: ");
                numerosFactura[posicion] = Console.ReadLine();
                break;
            case 10:
                Console.Write("Ingrese el nuevo monto a pagar: ");
                montosAPagar[posicion] = decimal.Parse(Console.ReadLine());
                montosComision[posicion] = montosAPagar[posicion] * 0.04m;
                montosDeducido[posicion] = montosAPagar[posicion] - montosComision[posicion];
                break;
            case 11:
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

    } while (opcion != 11);
}

void EliminarPagos()
{
    Console.Write("Ingrese el número de pago que desea eliminar: ");
    int numeroPago = int.Parse(Console.ReadLine());
    bool encontrado = false;

    for (int i = 0; i < 10; i++)
    {
        if (numeroPagos[i] == numeroPago)
        {
            encontrado = true;

            Console.WriteLine("**Datos del pago a eliminar**");
            Console.WriteLine("Número de pago: {0}", numeroPagos[i]);
            Console.WriteLine("Fecha: {0}", fechas[i]);
            Console.WriteLine("Hora: {0}", horas[i]);
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
                horas[i] = TimeSpan.Zero;
                cedulas[i] = "";
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

                Console.WriteLine("La información fue eliminada.");
            }
            else
            {
                Console.WriteLine("La información no fue eliminada.");
            }

            break;
        }
    }

    if (!encontrado)
    {
        Console.WriteLine("Pago no se encuentra registrado.");
    }

    Console.ReadKey();
}
void SubmenuReportes()
{

}
