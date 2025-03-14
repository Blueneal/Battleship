using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Battleship
{
    internal class Program
    {

        static void Main(string[] args)
        {
            bool isPlaying = false;

            TitleScreen();
            Console.WriteLine("Press Enter Key to Continue...");
            Console.ReadLine();
            isPlaying = true;
            while (isPlaying == true)
            {
                Console.WriteLine("[1]One Player");
                Console.WriteLine("[2]Two Players");
                Console.WriteLine("[3]Quit");
                string? input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("Player vs AI Selected");
                    Grid.PrintGrid();
                }
                else if (input == "2")
                {
                    Console.WriteLine("Multiplayer Selected");
                }
                else if (input == "3")
                {
                    isPlaying = false;
                    Console.WriteLine("Thank You For Playing!");
                }
            }
        }

        public static void TitleScreen()
        {
            Console.WriteLine(" ____        _   _   _           _     _");
            Console.WriteLine("|  _ \\      | | | | | |         | |   (_)");
            Console.WriteLine("| |_) | __ _| |_| |_| | ___  ___| |__  _ _ __");
            Console.WriteLine("|  _ < / _' |  _|  _| |/ _ \\/ __| '_ \\| | '_ \\");
            Console.WriteLine("| |_) | (_| | |_| |_| |  __/\\__ \\ | | | | |_) |");
            Console.WriteLine("|____/ \\__._|__/|__/|_|\\___||___/_| |_|_| .__/");
            Console.WriteLine("                                        | |");
            Console.WriteLine("                                        |_|");
        }
    }
}

