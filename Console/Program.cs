using System;

using Core;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var results = Processor.Execute(1, 100);

                Console.WriteLine(results);
            }
            catch (Exception)
            {
                // Handle exception

                Console.WriteLine("Something bad happend.");
            }

            Console.ReadKey();
        }
    }
}