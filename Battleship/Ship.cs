namespace Battleship
{
    class Ship
    {
        public string Name;
        public int Length;
        public List<(int, int)> Coordinates;
        public int Hits;

        public Ship(string name, int length)
        {
            Name = name;
            Length = length;
            Coordinates = new List<(int, int)>();
            Hits = 0;
        }

        public bool IsSunk()
        {
            return Hits >= Length;
        }
    }
}
