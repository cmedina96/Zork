// Name: Cristian Medina
// Date: 9/22/2019
// Assignment: "5 - The Game World"

using System;

namespace Zork
{
    class Program
    {
        private static string[] Rooms =
        {
         "Forest",
         "West of House",
         "Behind House",
         "Clearing",
         "Canyon View"
        };

        private static int CurrentRoom = 1;

        /*
        - On every iteration of the game loop, display the location of the player (the name of the room).

        - Move takes in Commands, return bool if move was successful.
        - Within Move, check if Commands is valid input North, South, East, & West.
        - Throw exception if invalid Commands
        - Use a Switch for the possible movements
        - Use length when getting the total length of Rooms arr, don't hardcode.
        - If they try to move outside array bounds, display "The way is shut!"
        - Call Move within the switch statements in Main
        */

        private static bool Move(Commands command)
        {
            switch (command)
            {
                case Commands.NORTH:
                case Commands.SOUTH:
                    Console.WriteLine("The way is shut!");
                    return false;

                case Commands.WEST:
                    if (CurrentRoom > 0)
                    {
                        CurrentRoom--;
                        Console.WriteLine("You moved WEST.");
                        Console.WriteLine(Rooms[CurrentRoom]);
                        return true;
                    }

                    else
                    {
                        Console.WriteLine("The way is shut!");
                        return false;
                    }

                case Commands.EAST:
                    if (CurrentRoom < Rooms.Length - 1)
                    {
                        CurrentRoom++;
                        Console.WriteLine("You moved EAST.");
                        Console.WriteLine(Rooms[CurrentRoom]);
                        return true;
                    }

                    else
                    {
                        Console.WriteLine("The way is shut!");
                        return false;
                    }

                default:
                    Console.WriteLine("Invalid commands.");
                    break;
            }

            return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!\n" + Rooms[CurrentRoom]);

            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                // string outputString;
                switch (command)
                {
                    case Commands.QUIT:
                        // outputString = "Thank you for playing!";
                        Console.WriteLine("Thank you for playing!");
                        break;

                    case Commands.LOOK:
                        // outputString = "This is an open field west of a white house, with a boarded front door. A rubber mat saying 'Welcome to Zork!' lies by the door.";
                        Console.WriteLine("This is an open field west of a white house, with a boarded front door. A rubber mat saying 'Welcome to Zork!' lies by the door.");
                        break;

                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.WEST:
                    case Commands.EAST:
                        Move(command);
                        // outputString = "You moved " + command;
                        break;

                    default:
                        // outputString = "Unknown command.";
                        Console.WriteLine("Unknown command.");
                        break;
                }

                // Console.WriteLine(outputString);
            }
        }

        private static Commands ToCommand(string commandString) => Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;
    }
}
