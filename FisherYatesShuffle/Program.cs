using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherYatesShuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            //Spells "Algorithms"
            string[] mumbo = { "A", "L", "G", "O", "R",
                                "I", "T", "H", "M", "S" };
            //Executes the shuffle class made previously
            mumbo.FYShuffleArray();

            //Time to see if the program works
            foreach(string jumbo in mumbo)
            {
                //Writes each letter in mumbo
                Console.Write($"{jumbo} ");
            }
            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
        }
    }
}
