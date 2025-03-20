namespace Battleship
{
    class Program
    {
        static void Main()
        {
            bool isPlaying = false;

            TitleScreen();
            Console.WriteLine("");
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

            isPlaying = true;
            while (isPlaying == true) //Starts with a prompt for the player to select game mode or to stop playing
            {
                Console.Clear();
                Console.WriteLine("Select a Game Mode");
                Console.WriteLine("");
                Console.WriteLine("[1] One Player");
                Console.WriteLine("[2] Two Players");
                Console.WriteLine("[3] Quit");
                string? input = Console.ReadLine();

                if (input == "1") //section of code that handles the player vs AI game mode
                {
                    BasePlayer player = new BasePlayer();
                    BasePlayer ai = new BasePlayer();
                    Grid aiGrid = ai.GetGrid();
                    Grid playerGrid = player.GetGrid();
                    int shots = 0;

                    isPlaying = true;
                    while (isPlaying)
                    {
                        Console.Clear();
                        Console.WriteLine("AI's Board (Shots Fired):");
                        aiGrid.DisplayBoard(true);

                        Console.WriteLine("\nYour Board:");
                        playerGrid.DisplayBoard(false);
                        player.PlayerAttack(aiGrid);

                        shots++;
                        if (aiGrid.CheckWin()) //Ends the game and prompts the player if they want to play again
                        {
                            Console.Clear();
                            Console.WriteLine("You win in " + shots + " shots!");
                            
                            Console.WriteLine("Want to play another game? <y/n>");
                            Console.ReadLine();
                            if (Console.ReadLine() == "y" || Console.ReadLine() == null)
                            {
                                continue;
                            }
                            else if (Console.ReadLine() == "n")
                            {
                                isPlaying = false;
                                Console.WriteLine("Thank You For Playing!");
                                break;
                            }
                        }
                        ai.Attack(playerGrid);
                        if (playerGrid.CheckWin()) 
                        {
                            Console.WriteLine("AI wins!");
                            
                            Console.WriteLine("Want to play another game? <y/n>");
                            Console.ReadLine();
                            if (Console.ReadLine() == "y" || Console.ReadLine() == null)
                            {
                                continue;
                            }
                            else if (Console.ReadLine() == "n")
                            {
                                isPlaying = false;
                                Console.WriteLine("Thank You For Playing!");
                                break;
                            }
                        }
                    }
                }
                else if (input == "2") //section of code that handles the player vs player game mode
                {
                    Console.WriteLine("Player One's Name: ");
                    string? Player1Name = Console.ReadLine();
                    Console.WriteLine("Player Two's Name: ");
                    string? Player2Name = Console.ReadLine();

                    BasePlayer player1 = new BasePlayer();
                    BasePlayer player2 = new BasePlayer();
                    Grid player1Grid = player1.GetGrid();
                    Grid player2Grid = player2.GetGrid();
                    int shots = 0;

                    int i = 0;

                    isPlaying = true;
                    while (isPlaying)
                    {
                        if (i == 0)
                        {
                            Console.Clear();
                            Console.WriteLine(Player2Name + " Board:");
                            player2Grid.DisplayBoard(true);

                            Console.WriteLine(Player1Name + " Board:");
                            player1Grid.DisplayBoard(false);
                            player1.PlayerAttack(player2Grid);

                            shots++;
                            i++;
                        }
                        else if (i == 1)
                        {
                            Console.Clear();
                            Console.WriteLine(Player1Name + " Board:");
                            player1Grid.DisplayBoard(true);

                            Console.WriteLine(Player2Name + " Board:");
                            player2Grid.DisplayBoard(false);
                            player2.PlayerAttack(player1Grid);

                            shots++;
                            i--;
                        }

                        if (player1Grid.CheckWin()) //Ends the game and prompts the player if they want to play again
                        {
                            Console.WriteLine(Player2Name + " wins in " + shots + " shots!");
                            isPlaying = false;
                            break;
                        }
                        if (player2Grid.CheckWin())
                        {
                            Console.WriteLine(Player1Name + " wins in " + shots + " shots!");
                            isPlaying = false;
                            break;
                        }
                    }
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