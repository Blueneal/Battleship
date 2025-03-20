namespace Battleship
{
    class BasePlayer
    {
        public static string[] shipNames = { "Carrier", "Battleship", "Cruiser", "Submarine", "Destroyer" };
        public static int[] shipLength = { 5, 4, 2, 3, 4 };

        private Grid grid;
        private Random rand;

        public BasePlayer()
        {
            grid = new Grid();
            rand = new Random();
            PlaceShips();
        }

        public void PlaceShips() //Randomly places the ships on the board, and checks to make sure there is no overlap or out of bounds ships
        {
            Random rand = new Random();


                for (int i = 0; i < shipNames.Length; i++)
                {
                    string direction = "H";
                    if (rand.Next(0, 2) == 0)
                    {
                        direction = "V";
                    }
                    if (!grid.PlaceShip(new Ship(shipNames[i], shipLength[i]), rand.Next(grid.BoardLength()), rand.Next(grid.BoardHeight()), direction))
                    {
                        i--;
                    }
                }
        }
        public bool PlayerAttack(Grid enemyGrid) //Prompts the player for an attack via x and y coordinates
        {
            Console.WriteLine("Enter a Number for the Y coordinate");
            int x = Convert.ToInt32(Console.ReadLine());
            if (x >= 11 || x <= 0)
            {
                Console.WriteLine("Incorrect Number, number must be between 1-10");
                x = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Enter a Number for the X coordinate");
            int y = Convert.ToInt32(Console.ReadLine());
            if (y >= 11 || y <= 0)
            {
                Console.WriteLine("Incorrect Number, number must be between 1-10");
                y = Convert.ToInt32(Console.ReadLine());
            }
            bool didHit = enemyGrid.MakeGuess(x-1, y-1);
            
            return didHit;
        }

        public bool Attack(Grid enemyGrid)
        {
            rand = new Random();
            int x, y;
            do
            {
                x = rand.Next(10);
                y = rand.Next(10);
            }
            while (enemyGrid.MakeGuess(x, y));
            return true;
        }

        public Grid GetGrid()
        {
            return grid;
        }
    }
}
