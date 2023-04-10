using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizionarioV20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TourOperator cliente = new TourOperator(Console.ReadLine());
            Console.WriteLine("Inserisci valori (0 per terminare, 1 per continuare)");
            do
            {
                Console.WriteLine("Inserisci");
                cliente.add(Console.ReadLine(), Console.ReadLine());
                Console.WriteLine("Vuoi continuare?");
            }
            while (Console.ReadLine() != "0");
            cliente.toString();
            Console.ReadLine();
        }
    }
}
