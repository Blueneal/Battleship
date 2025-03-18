namespace Battleship
{
    class BasePlayer
    {
        public static string[] shipNames = { "Carrier", "Battleship", "Cruiser", "Submarine", "Destroyer" };
        public static int[] shipLength = { 5, 4, 2, 3, 4};

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
