using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_2_Kevin_Guzmán
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nombre;
            string apellido1;
            string apellido2;
            string cedula;
            int tipoempleado;
            int tiempolaborado;
            double precio;
            double aumento;
            double salario;
            int opcion;
            int cantidadoperadores = 0;
            int cantidadtecnicos = 0;
            int cantidadprofesionales = 0;
            double promediosalariooperadores = 0;
            double promediosalariotecnicos = 0;
            double promediosalarioprofesionales = 0;
            double salariobruto;
            double deduccionccss;
            double salarioneto;

            do
            {
                Console.WriteLine("*** Bienvenido al sistema de calculo salarial de la UPI");
                Console.WriteLine("Digite su número de cédula: ");
                cedula = Console.ReadLine();
                Console.WriteLine("Escriba su nombre");
                nombre = Console.ReadLine();
                Console.WriteLine("Escriba su primer apellido");
                apellido1 = Console.ReadLine();
                Console.WriteLine("Escriba su segundo apellido");
                apellido2 = Console.ReadLine();
                Console.WriteLine("Digite a que tipo de empleado pertenece:    " +
                    "1.Operario " +
                    "2.Técnico " +
                    "3.Profesional");
                tipoempleado = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite el tiempo laboradas a la semana: ");
                tiempolaborado = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite el precio a pagar por hora laborada: ");
                precio = double.Parse(Console.ReadLine());
                salario = precio * tiempolaborado;
                aumento = 0;
                if (tipoempleado == 1)
                {
                    aumento = salario * 0.15;
                    cantidadoperadores++;
                    promediosalariooperadores += salario + aumento;
                }
                else if (tipoempleado == 2)
                {
                    aumento = salario * 0.10;
                    cantidadtecnicos++;
                    promediosalariotecnicos += salario + aumento;
                }
                else if (tipoempleado == 3)
                {
                    aumento = salario * 0.05;
                    cantidadprofesionales++;
                    promediosalarioprofesionales *= salario + aumento;
                }

                salariobruto = salario + aumento;

                deduccionccss = salariobruto * 0.0917;

                salarioneto = salariobruto - deduccionccss;

                Console.WriteLine("\n**** Información del empleado ****");
                Console.WriteLine("Su numero de cedula es: " + cedula);
                Console.WriteLine("Su nombre completo es: " + nombre + " " + apellido1 + " " + apellido2);
                Console.WriteLine("Tipo de empleado: " + tipoempleado);
                Console.WriteLine("Su salario por hora es: " + precio);
                Console.WriteLine("Su tiempo laborado por semana es: " + tiempolaborado);
                Console.WriteLine("Su salario ordinario es: " + (precio * tiempolaborado));
                Console.WriteLine("Su aumento correspondiente sería: " + aumento);
                Console.WriteLine("Su salario Bruto es: " + salariobruto);
                Console.WriteLine("Su salario con la deducción de CCSS: " + deduccionccss);
                Console.WriteLine("Su salario neto sería: " + salarioneto);


                Console.WriteLine("\n¿Desea ingresar otro empleado? (1-Sí, 0-No): ");
                opcion = int.Parse(Console.ReadLine());


            } while (opcion != 0);

            Console.WriteLine("\n**** Estadísticas: ****");
            Console.WriteLine("1) Cantidad Empleados Tipo Operarios: " + cantidadoperadores);
            Console.WriteLine("   Acumulado Salario Neto para Operarios: " + promediosalariooperadores);
            Console.WriteLine("   Promedio Salario Neto para Operarios: " + (cantidadoperadores == 0 ? 0 : promediosalariooperadores / cantidadoperadores));

            Console.WriteLine("2) Cantidad Empleados Tipo Técnico: " + cantidadtecnicos);
            Console.WriteLine("   Acumulado Salario Neto para Técnicos: " + promediosalariotecnicos);
            Console.WriteLine("   Promedio Salario Neto para Técnicos: " + (cantidadtecnicos == 0 ? 0 : promediosalariotecnicos / cantidadtecnicos));

            Console.WriteLine("3) Cantidad Empleados Tipo Profesional: " + cantidadprofesionales);
            Console.WriteLine("   Acumulado Salario Neto para Profesionales: " + promediosalarioprofesionales);
            Console.WriteLine("   Promedio Salario Neto para Profesionales: " + (cantidadprofesionales == 0 ? 0 : promediosalarioprofesionales / cantidadprofesionales));

            Console.Read();
        }
    }
}
