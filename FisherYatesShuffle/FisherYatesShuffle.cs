using System;

namespace FisherYatesShuffle
{
    /// <summary>
    /// The class is static since it is a predermined
    /// fashion for which to shuffle, if it is edited
    /// then it is no longer the Fisher-Yates Shuffle,
    /// it's an abomination.
    /// </summary>

    public static class FisherYatesShuffle
    {
        ///This generates a random number and stores it
        ///within the _rNumber variable. The reason why
        ///it is static is because I want there to be no
        ///external changes to this number other than it's
        ///generation
        private static Random _rNumber = new Random();
        
        /// <summary>
        /// The primary reason for creating an array of
        /// objects in the method is simply because we
        /// don't need to keep any of the information for
        /// future use at least in this class, if it were
        /// for sorting arrays randomly then you would want
        /// to put in something like (List[] list) for input.
        /// </summary>
        /// <param name="obj"></param>
        public static void FYShuffleArray(this object[] obj)
        {
            //This iterates throught the array obj
            for (int i = obj.Length - 1; i > 0; i--)
            {
                //We need a temp obj to store the value
                //in order to initiate a swap.
                object temp = obj[i];

                //Stores the number j between 1 and i
                int j = _rNumber.Next(i + 1);

                //Swaps the two places of the array
                obj[i] = obj[j];

                //Stores the previous value of i into temp
                obj[j] = temp;
            }
        }




    
    
    }

}
