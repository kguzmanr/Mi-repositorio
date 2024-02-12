// See https://aka.ms/new-console-template for more information

int tamano = 2;
String[] nombre = new string[tamano];
int[] edad = new int[tamano];
string[] citas = new string[tamano];
string nomb;
int opcion = 0;

menu(); 

void inicializar()
{
    nombre = Enumerable.Repeat("", tamano).ToArray<string>();
    citas = Enumerable.Repeat("", tamano).ToArray<string>();
    edad = Enumerable.Repeat(0, tamano).ToArray<int>();
    Console.WriteLine("Los arreglos han sido inicializados");
    Console.ReadKey();
    Console.Clear();
}


void agregar()
{
    for (int i = 0; i < nombre.Length; i++)
    {
        Console.Write("Ingrese el nombre: "); nombre[i] = Console.ReadLine();
        Console.Write("Ingrese su edad: "); edad[i] = int.Parse(Console.ReadLine());
    }
}

void consultacita()
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("Nombre     Edad");
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine("------    ----");
    for (int i = 0; i < nombre.Length; i++)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"{nombre[i]}    {edad[i]}");
    }
}

void consulta()
{
    bool encontrado = false;
    Console.WriteLine("Digite el nombre que desea buscar: ");
    nomb = Console.ReadLine();
    for(int i = 0; i < nombre.Length; i++)
    {
        if (nomb.Equals(nombre[i]))
        {
            Console.WriteLine($"La edad de {nomb} es {edad[i]}");
            encontrado = true;
        }
    }
    if (encontrado == false)
    {
        Console.WriteLine($"El paciente {nomb} no existe");
    }
}
void asignar()
{
    bool encontrado = false;
    Console.WriteLine("Digite el nombre del paciente al que desea agendar una cita: ");
    nomb = Console.ReadLine();
    for (int i = 0; i < nombre.Length; i++)
    {
        if (nomb.Equals(nombre[i]))
        {
            Console.WriteLine($"El paciente {nomb} se encuentra registrado...");
            encontrado = true;
            do
            {
                Dictionary<DateTime, bool> disponibilidad = new Dictionary<DateTime, bool>();
                List<DateTime> citasProgramadas = new List<DateTime>();

                Main();

                void Main()
                {
                    InicializarDisponibilidad();

                    while (true)
                    {
                        MostrarMenu();
                        int opcion = Convert.ToInt32(Console.ReadLine());

                        switch (opcion)
                        {
                            case 1:
                                MostrarDisponibilidad();
                                break;
                            case 2:
                                ProgramarCita();
                                break;
                            case 3:
                                MostrarCitasProgramadas();
                                break;
                            case 4:
                                return;
                            default:
                                Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                                break;
                        }
                    }
                }

                void InicializarDisponibilidad()
                {
                    DateTime fechaInicio = DateTime.Now.Date;
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 9; j < 17; j++)
                        {
                            DateTime hora = fechaInicio.AddHours(j);
                            disponibilidad.Add(hora, true);
                        }
                        fechaInicio = fechaInicio.AddDays(1);
                    }
                }

                void MostrarMenu()
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Seleccione una opción:");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("1. Ver disponibilidad");
                    Console.WriteLine("2. Programar cita");
                    Console.WriteLine("3. Ver citas programadas");
                    Console.WriteLine("4. Salir");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Digite una opción...");
                }

                void MostrarDisponibilidad()
                {
                    Console.WriteLine("Disponibilidad:");
                    foreach (var hora in disponibilidad)
                    {
                        Console.WriteLine($"{hora.Key}: {(hora.Value ? "Disponible" : "No disponible")}");
                    }
                }

                void ProgramarCita()
                {
                    Console.WriteLine("Ingrese la fecha y hora para la cita (yyyy-MM-dd HH:mm):");
                    DateTime fechaHora = Convert.ToDateTime(Console.ReadLine());

                    if (disponibilidad.ContainsKey(fechaHora) && disponibilidad[fechaHora])
                    {
                        disponibilidad[fechaHora] = false;
                        citasProgramadas.Add(fechaHora);
                        Console.WriteLine("Cita programada con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("La hora seleccionada no está disponible. Por favor, elija otra.");
                    }
                }

                void MostrarCitasProgramadas()
                {
                    foreach (var cita in citasProgramadas)
                    {
                        Console.WriteLine($"Citas programadas: {cita}");
                    }
                }

            } while (false);
        }
    }
    if (encontrado == false)
    {
        Console.WriteLine($"El paciente {nomb} no existe");
    }
}

void menu()
{
    do
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("***** Consultorio Médico *****");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("1- Inicializar Arreglos");
        Console.WriteLine("2- Ingresar Paciente");
        Console.WriteLine("3- Consultar Paciente");
        Console.WriteLine("4- Reporte");
        Console.WriteLine("5- Asignar Cita");
        Console.WriteLine("6- Salir");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Digite una opcion...");
        opcion = int.Parse(Console.ReadLine());

        switch (opcion)
        {
            case 1: inicializar(); break;
            case 2: agregar(); break;
            case 3: consulta(); break;
            case 4: consultacita();  break;
            case 5: asignar(); break;
            case 6:  break;
            default:
                break;
        }
    } while (opcion != 6);
}
