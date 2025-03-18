namespace Battleship
{
    class BasePlayer
    {
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
            int x = 5;
            int y = 5;

            string direction = "H";
            if (rand.Next(0, 2) == 0)
            {
                direction = "V";
            }
            
            grid.PlaceShip(new Ship("Battleship", 4), x, y, direction);
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
