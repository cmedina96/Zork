// Name: Cristian Medina
// Date: 9/22/2019
// Assignment: "6 - Expanding the Frontier"

using System;

namespace Zork
{
    class Program
    {
        private static string[,] Rooms =
        {
            { "Rocky Trail", "South of House", "Canyon View" },
            { "Forest", "West of House", "Behind House" },
            { "Dense Woods", "North of House", "Clearing" }
        };

        /// Store current room location
        // private static int CurrentRoom = 1;
        private static int LocationRow = 1;
        private static int LocationColumn = 1;

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
                    if (LocationRow > 0)
                    {
                        LocationRow--;
                        // Console.WriteLine("You moved NORTH.");
                        Console.WriteLine(Rooms[LocationRow, LocationColumn]);
                        return true;
                    }

                    else
                    {
                        Console.WriteLine("The way is shut!");
                        Console.WriteLine(Rooms[LocationRow, LocationColumn]);
                        return false;
                    }

                case Commands.SOUTH:
                    if (LocationRow < Rooms.GetLength(0) - 1) // Check length of rows
                    {
                        LocationRow++;
                        // Console.WriteLine("You moved SOUTH.");
                        Console.WriteLine(Rooms[LocationRow, LocationColumn]);
                        return true;
                    }

                    else
                    {
                        Console.WriteLine("The way is shut!");
                        Console.WriteLine(Rooms[LocationRow, LocationColumn]);
                        return false;
                    }

                case Commands.WEST:
                    if (LocationColumn > 0)
                    {
                        LocationColumn--;
                        // Console.WriteLine("You moved WEST.");
                        Console.WriteLine(Rooms[LocationRow, LocationColumn]);
                        return true;
                    }

                    else
                    {
                        Console.WriteLine("The way is shut!");
                        Console.WriteLine(Rooms[LocationRow, LocationColumn]);
                        return false;
                    }

                case Commands.EAST:
                    if (LocationColumn < Rooms.GetLength(1) - 1) // Check the length of columns
                    {
                        LocationColumn++;
                        // Console.WriteLine("You moved EAST.");
                        Console.WriteLine(Rooms[LocationRow, LocationColumn]);
                        return true;
                    }

                    else
                    {
                        Console.WriteLine("The way is shut!");
                        Console.WriteLine(Rooms[LocationRow, LocationColumn]);
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
            Console.WriteLine("Welcome to Zork!\n" + Rooms[LocationRow, LocationColumn]);

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
