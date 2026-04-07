
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Concurrent;



namespace Server
{
    class Program
    {
        //Socket principal de escucha para recibir conexiones
        static Socket _listenSocket;

        static void Main(string[] args)
        {
            //Comprobación y lectura de argumentos del programa
            

            //Lectura del fichero de datos
            

            //Generar una lista de control de los hilos activos para ir añadiendo hilos conforme se vayan creando
            List<Worker> workingThreads = new List<Worker>();

            //Asignacion de prioridad
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;

            //Lazar el comprobador para cerrar correctamente el programa
            Console.CancelKeyPress += delegate
            {
                _listenSocket.Close();
                Console.WriteLine("Esperando a que los Clientes se desconecten");
                for (int i = 0; i < workingThreads.Count; i++)
                {
                    ((Worker)workingThreads[i]).Stop();
                }
            };

            //Preparacion del socket de escucha
            

            //Preparar y lanzar el hilo que genera los datos
            

            //Preparar y lanzar el hilo que escucha comandos en el siguiente puerto después del puerto de escucha
            

            //Bucle infinito de aceptación de conexiones
            Console.WriteLine("Aceptando conexiones");

            while (true)
            {
                
            }
        }
    }
}
