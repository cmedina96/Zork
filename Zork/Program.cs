// Name: Cristian Medina
// Date: 9/11/2019
// Assignment: "2 - Looking Around and Quitting"

using System;

namespace Zork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            string inputString = Console.ReadLine();
            inputString = inputString.ToUpper();

            if (inputString == "QUIT")
            {
                Console.WriteLine("Thank you for playing.");
            }

            else if (inputString == "LOOK")
            {
                Console.WriteLine("This is an open field west of white house, with a boarded front door.\nArubber mat saying 'Welcome to Zork!' lies by the door.");
            }

            else
            {
                Console.WriteLine("Unrecognized command.");
            }
        }
    }
}
