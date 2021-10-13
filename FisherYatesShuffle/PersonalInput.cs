using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherYatesShuffle

{
    public static class PersonalInput
    {
        public static void CreateArray(this object[] obj)
        {
            //Adds a null check to the arguement
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            //creates the number of cases in the array
            int n = 5;
            //defines the array obj so it can have values inserted
            //Small introduction
            Console.WriteLine("Welcome to the Fisher-Yates Shuffle!");
            Console.WriteLine("Enter in 5 string values one at a time:");

            //Cycles inputs until all the slots in the array are filled
            for (int i = 0; i < n; i++)
            {
                obj[i] = Console.ReadLine();
                Console.WriteLine(obj[i]);
            }

        }
    }
}
