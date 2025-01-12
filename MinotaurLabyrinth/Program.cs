﻿namespace MinotaurLabyrinth
{
    static class Program
    {
        static void Main()
        {
            string seed = "";
            ConsoleHelper.Write("Do you want to play a small, medium, or large game? ", ConsoleColor.White);

            // Default game setting in the event user does not input a proper size.
            Size mapSize = Console.ReadLine() switch
            {
                "small" => Size.Small,
                "large" => Size.Large,
                _ => Size.Medium // Make a medium game if input is "medium" or anything else
            };


            Console.Write("Enter a seed to generate specific map layout: ");

            bool result = SeedIsValid(seed);

            if (result)
            {
                int newSeed = Int32.Parse(seed);
                LabyrinthGame game = new(mapSize, newSeed);
                game.Run();
            }

            else
            {
                ConsoleHelper.Write("User input is invalid random map will be generated \n", ConsoleColor.Yellow);
                int newSeed = Guid.NewGuid().GetHashCode();
                Console.WriteLine($"generted new seed that user can use to play again: {0}", newSeed);
                LabyrinthGame game = new(mapSize, newSeed);
                game.Run();
            }

            bool SeedIsValid(string seed)
            {
                if (seed.All(char.IsDigit) && seed != "")
                    return true;
                else
                {
                    return false;
                }
            }
        }
    }
}
