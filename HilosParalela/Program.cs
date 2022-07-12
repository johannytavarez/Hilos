using System;
using System.Threading;

namespace HilosParalela
{
    class Program
    {
        static void Main(string[] args)
        {
            RunWithThreads();
        }

        static void RunWithThreads()
        {
            double result = 0d;

            // Crear el hilo para leer desde E/S
            var thread = new Thread(() => result = ReadDataFromIO());

            // Iniciar el hilo
            thread.Start();

            // Guardar el resultado de el calculo en otra variable
            double result2 = DoIntensiveCalculations();

            // Esperar a que el hilo termine 
            thread.Join();

            // Calcular el resultado final
            result += result2;

            // Imprimir el resultado
            Console.WriteLine("El resultado es {0}", result);
        }

        static double DoIntensiveCalculations()
        {
            // Estamos simulando cálculos intensivos
            // haciendo divisiones sin sentido
            double result = 100000000d;
            var maxValue = Int32.MaxValue;

            for (int i = 1; i < maxValue; i++)
            {
                result /= i;
            }

            return result;
        }

        static double ReadDataFromIO()
        {
            // Estamos simulando una E/S poniendo el hilo actual en suspensión.
            Thread.Sleep(5000);
            return 10d;
        }
    }
}
