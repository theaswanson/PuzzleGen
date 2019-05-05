using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzle
{
    class Menu
    {
        public void Start()
        {
            int input = 0;

            do
            {
                Console.WriteLine("\nPuzzle Generator Menu");
                Console.WriteLine("[1] Get next space");
                Console.WriteLine("[2] Get previous space");
                Console.WriteLine("[0] Quit");

                input = ReadInt();

                switch (input)
                {
                    case 0:
                        break;
                    case 1:
                        GetNextSpacesFunction();
                        break;
                    case 2:
                        GetAllSpacesFunction();
                        break;
                }

            }
            while (input != 0);

            Wait();
        }

        private static void GetNextSpacesFunction()
        {
            Console.WriteLine("Enter an integer: ");
            int input = ReadInt();

            List<int> nextSpaces = GetNextSpaces(input);

            Console.WriteLine("Next spaces:");
            foreach (int space in nextSpaces)
            {
                Console.WriteLine(space);
            }
        }

        private static void GetAllSpacesFunction()
        {
            var table = new ConsoleTables.ConsoleTable("Space", "Space 1", "Space 2", "Space 3");

            for (int i = 1; i < 50; i++)
            {
                table.AddRow(i, string.Join(", ", GetNextSpaces(i)));
            }

            table.Write();
        }

        /// <summary>
        /// Returns a list of the next possible spaces based on the value of the space provided.
        /// </summary>
        /// <param name="input">Value of the current space.</param>
        /// <returns>List of all of the next possible spaces.</returns>
        private static List<int> GetNextSpaces(int input)
        {
            List<int> spaces = new List<int>();
            List<int> primes = new List<int>()
            {
                2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101
            };

            spaces.Add(input + 3);

            if (input % 2 == 0)
                spaces.Add(input / 2);

            if (primes.Contains(input) && primes.IndexOf(input) != primes.Count - 1)
            {
                int nextPrime = primes[primes.IndexOf(input) + 1];
                spaces.Add(nextPrime);
            }

            spaces.Sort();

            return spaces;

        }

        /// <summary>
        /// Reads user input and parses it as an integer.
        /// </summary>
        /// <returns>Integer as parsed from user input.</returns>
        private static int ReadInt()
        {
            string input;
            int result = 0;
            bool parsedInput = false;

            while (!parsedInput)
            {
                input = Console.ReadLine();

                if (int.TryParse(input, out result) == false)
                    Console.WriteLine("Not a valid integer. Try again.");
                else
                    parsedInput = true;
            }

            return result;
        }

        /// <summary>
        /// Waits for user key input.
        /// </summary>
        /// <param name="message">Message to display while awaiting key input.</param>
        private static void Wait(string message = "Press any key to continue...")
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
