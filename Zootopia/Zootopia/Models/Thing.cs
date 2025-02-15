

namespace Models
{
    class Thing : IInventory
    {
        public int Number { get; set; }

        public Thing(int number) { Number = number; }
    }
}
