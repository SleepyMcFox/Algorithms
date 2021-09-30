using System;

namespace BigO
{
    class Program
    {
        public static void Main()
        {

        }
        //This first example is for O(1) or Constant
        //No matter how big the name is if it starts
        //with B it will return true other wise it is
        //false
        public bool DoesNameStartWithB(string name)
        {
            //This takes out the first letter of the name.
            //We use this to check if firstLetter is 'b' or
            //not
            string firstLetter = name.Substring(0, 1);
            //If b is the first letter of name it returns
            //true, otherwise it will return false
            return firstLetter == "b";
        }
        //The second example is for O(n) or Linear
        //Depending on how large the array of integers
        //is or how long it takes for it to reach the
        //desired number, the longer it may take for the
        //program to reach its desired destination.
        //This can be useful for pulling out certain data
        //in the array
        public int FindTheNumber(int[] numbers, int desiredNumber)
        {
            //This iterates through the array of
            //integers 'numbers' in order to find
            //out if the int 'number' is equal to
            //'desiredNumber'
            foreach(int number in numbers)
            {
                //If the desired number is reached,
                //then it will return
                //the desiredNumber and break the loop
                if(number == desiredNumber)
                {
                    return desiredNumber;
                }
            }
            //if the number is not found then it will
            //return nothing
            return 0;
        }
        //The third example is for O(n^2) or Quadratic
        //Since this depends on two separate instances of
        //n, such as looking for a match, the time and space
        //depend on how large the array is and how long it 
        //will take to reach the desired destination
        public bool MatchingNumbers(int[] numbers)
        {
            //This iterates through an array both from
            //the beginning and the end of the array to
            //search for two matching numbers
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = numbers.Length; j > numbers.Length; j--)
                {
                    //if at any point the matching numbers are
                    //found, then it returns true and breaks the
                    //for loop, otherwise it will keep iterating
                    //until it finds nothing
                   if(numbers[i] == numbers[j])
                    {
                        return true;
                    }
                }
            }
            //If the nested for loop does not find duplicate
            //numbers, then it will return false
            return false;
        }



    }
}
