

namespace Models
{
    public class Herbo : Animal
    {
        public int Kindness { get; set; }
        public Herbo(int number, int food, int kindness = 5) : base(number, food)
        {
            Kindness = kindness;
        }
    }
}
