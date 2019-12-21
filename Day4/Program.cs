using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    class Program
    {
        static int lowbound = 158126;
        static int highbound = 624574;
        static void Main(string[] args)
        {
            var numberOfPasswords = 0;
            for(var password = lowbound; password <= highbound; password++)
            {
                //Console.WriteLine($"Current Password: {password}");
                if(ValidatePassword(password)) {
                    numberOfPasswords++;
                }
            }

            Console.WriteLine(numberOfPasswords);
        }

        static bool ValidatePassword(int password) {
            var stringSplit = password.ToString().ToArray();
            int[] splitDigits = Array.ConvertAll(stringSplit, c => (int)Char.GetNumericValue(c));
            Dictionary<int,int> numberHolder = new Dictionary<int, int>();

            for(var i = 0; i < splitDigits.Length - 1; i++ ) {
                if (splitDigits[i] > splitDigits[i+1]) {
                    return false;
                }
                
                if (splitDigits[i] == splitDigits [i+1]) {
                    numberHolder.TryGetValue(splitDigits[i], out var currentCount);
                    numberHolder[splitDigits[i]] = currentCount += 1;
                }
            }

            if (numberHolder.ContainsValue(1)) {
                return true;
            } else {
                return false;
            }
            
        }
    }
}
