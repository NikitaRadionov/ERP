using System;

namespace Models
{
    class Animal : IAlive, IInventory
    {
        public int Food { get; set; }
        public int Number { get; set; }

        public Animal(int number, int food = 10)
        {
            Number = number;
            Food = food;
        }
    }
}
