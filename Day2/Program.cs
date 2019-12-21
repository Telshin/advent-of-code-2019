using System;

namespace Day2
{
    class Program
    {
        static string[] nonStrippedInstructions = System.IO.File.ReadAllLines("data.txt");
        static string[] tempInstructions = nonStrippedInstructions[0].Split(",");
        private static int noun;
        private static int verb;

        static void Main(string[] args)
        {
            Console.WriteLine(CalculateGravityWithInput(12, 2));

            for (noun = 0; noun < 100; noun++) {
                for (verb = 0; verb < 100; verb++) {
                    if (CalculateGravityWithInput(noun, verb) == 19690720) {
                        Console.WriteLine($"Our input is {100 * noun + verb}");
                        break;
                    }
                }
            }
        }

        private static int CalculateGravityWithInput(int noun, int verb)
        {
            int[] Instructions = Array.ConvertAll(tempInstructions, int.Parse);
            // Overwrite key pieces
            Instructions[1] = noun;
            Instructions[2] = verb;

            // Setup the variables
            bool addition = false;
            int opCodeValue = 0;
            int currentStep = 0;
            int finalValue = 0;
            
            foreach (var instruction in Instructions)
            {
                // Step counter for OpCode
                if (currentStep == 0)
                {
                    if (instruction == 1)
                    {
                        addition = true;
                    }
                    else if (instruction == 2)
                    {
                        addition = false;
                    }
                    else if (instruction == 99)
                    {
                        finalValue = Instructions[0];
                    }
                }

                if (currentStep == 1)
                {
                    opCodeValue = Instructions[instruction];
                }

                if (currentStep == 2)
                {
                    if (addition)
                    {
                        opCodeValue += Instructions[instruction];
                    }
                    else
                    {
                        opCodeValue = opCodeValue * Instructions[instruction];
                    }
                }

                if (currentStep == 3)
                {
                    Instructions[instruction] = opCodeValue;
                    currentStep = 0;
                    opCodeValue = 0;
                    continue;
                }

                currentStep += 1;
            }

            return finalValue;
        }
    }                    
}
