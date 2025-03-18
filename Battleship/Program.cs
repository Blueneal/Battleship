namespace Battleship
{
    class Program
    {
        static void Main()
        {
            BasePlayer player = new BasePlayer();
            BasePlayer ai = new BasePlayer();
            Grid aiGrid = ai.GetGrid();
            Grid playerGrid = player.GetGrid();
            int shots = 0;


            TitleScreen();
            Console.WriteLine("Welcome to Battleship! Press Enter to start.");
            Console.ReadLine();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("AI's Board (Shots Fired):");
                aiGrid.DisplayBoard(false);

                Console.WriteLine("\nYour Board:");
                playerGrid.DisplayBoard(false);
                Console.WriteLine("Enter to fire random shots");
                Console.ReadLine();
                player.Attack(aiGrid);

                shots++;
                if (aiGrid.CheckWin())
                {
                    Console.WriteLine("You win in " + shots + " shots!");
                    break;
                }
                ai.Attack(playerGrid);
                if (playerGrid.CheckWin())
                {
                    Console.WriteLine("AI wins!");
                    break;
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