using Models;

namespace Services
{
    class VetClinic
    {
        public bool CheckHealth(Animal animal) => new Random().Next(0, 2) == 1;
    }
}
