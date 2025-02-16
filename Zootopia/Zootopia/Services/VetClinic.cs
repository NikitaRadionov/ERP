using Models;

namespace Services
{
    public class VetClinic
    {
        public virtual bool CheckHealth(Animal animal) => new Random().Next(0, 2) == 1;
    }
}
