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

        public void PlaceShips()
        {
            for (int i = 0; i < shipNames.Length; i++)
            {
                Console.WriteLine("Insert a x coordinate for " + shipNames[i]);
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Insert a y coordinate for " + shipNames[i]);
                int y = Convert.ToInt32(Console.ReadLine()); 
                Console.WriteLine("Select [H] Horizontal or [V] Vertical");
                string? direction = Console.ReadLine();
                if (direction == null)
                {
                    Console.WriteLine("Incorrect input, select H or V");
                    continue;
                }
                if (!grid.PlaceShip(new Ship(shipNames[i], shipLength[i]), x, y, direction))
                {
                    i--;
                }
            }
        }

        public bool PlayerAttack(Grid enemyGrid)
        {
            Console.WriteLine("Enter a Number for the x coordinate");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a Number for the Y coordinate");
            int y = Convert.ToInt32(Console.ReadLine());
            List<Ship>enemyShips = enemyGrid.Ships;
            for (int i = 0; i < enemyShips.Count; i++)
            {
                if (enemyShips[i].IsSunk())
                {
                    continue;
                }
                for (int j = 0; j < enemyShips[i].Coordinates.Count; j++)
                {
                    if (enemyShips[i].Coordinates[j].Item1 == x && enemyShips[i].Coordinates[j].Item2 == y)
                    {
                        enemyGrid.MakeGuess(x, y);
                        //enemyShips[i].Hits++;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Attack(Grid enemyGrid)
        {
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
