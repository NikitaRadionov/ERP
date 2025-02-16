

namespace Models
{
    public class Animal : IAlive, IInventory
    {
        public int Food { get; set; }
        public int Number { get; set; }

        public Animal(int number, int food)
        {
            Number = number;
            Food = food;
        }
    }
}
