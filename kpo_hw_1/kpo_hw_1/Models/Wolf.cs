using System;

namespace Models
{
    class Wolf : Predator
    {
        public Wolf(int number, int food = 10) : base(number, food) { }
    }
}
