namespace Battleship
{
    class Program
    {
        static void Main()
        {
            bool isPlaying = false;

            BasePlayer player = new BasePlayer();
            BasePlayer ai = new BasePlayer();
            Grid aiGrid = ai.GetGrid();
            Grid playerGrid = player.GetGrid();
            int shots = 0;

            TitleScreen();
            Console.WriteLine("");
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

            isPlaying = true;
            while (isPlaying == true)
            {
                Console.Clear();
                Console.WriteLine("Select a Game Mode");
                Console.WriteLine("");
                Console.WriteLine("[1] One Player");
                Console.WriteLine("[2] Two Players");
                Console.WriteLine("[3] Quit");
                string? input = Console.ReadLine();

                if (input == "1")
                {
                    isPlaying = true;
                    while (isPlaying)
                    {
                        Console.Clear();
                        Console.WriteLine("AI's Board (Shots Fired):");
                        aiGrid.DisplayBoard(false);

                        Console.WriteLine("\nYour Board:");
                        playerGrid.DisplayBoard(false);
                        player.PlayerAttack(aiGrid);

                        shots++;
                        if (aiGrid.CheckWin())
                        {
                            Console.WriteLine("You win in " + shots + " shots!");
                            isPlaying = false;
                            break;
                        }
                        ai.Attack(playerGrid);
                        if (playerGrid.CheckWin())
                        {
                            Console.WriteLine("AI wins!");
                            isPlaying = false;
                            break;
                        }
                    }
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