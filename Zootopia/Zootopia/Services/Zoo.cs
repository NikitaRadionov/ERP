using System;
using Models;

namespace Services
{
    public class Zoo
    {
        readonly List<Animal> _animals = new();
        readonly List<Thing> _inventory = new();
        readonly VetClinic _vetClinic;

        public List<Thing> Inventory { get { return _inventory; } }
        public List<Animal> Animals { get { return _animals; } }

        public Zoo(VetClinic vetClinic) => _vetClinic = vetClinic;

        public void AddAnimal(Animal animal)
        {
            if (_vetClinic.CheckHealth(animal))
            {
                _animals.Add(animal);
                Console.WriteLine($"Животное {animal.GetType().Name} принято в зоопарк.");
            }
            else
            {
                Console.WriteLine($"Животное {animal.GetType().Name} не прошло проверку здоровья.");
            }
        }

        public List<Herbo> GetContactZooAnimals()
        {
            List<Herbo> contactAnimals = _animals.OfType<Herbo>().Where(a => a.Kindness >= 5).ToList();
            return contactAnimals;
        }

        public void GetAnimalCount() => Console.WriteLine($"Животных в зоопарке {_animals.Count}");

        public void AddThing(Thing thing) => _inventory.Add(thing);

        public int GetFoodConsumption() => _animals.Sum(a => a.Food);

        public void ReportFoodConsumption() => Console.WriteLine($"Животные потребляют {_animals.Sum(a => a.Food)} кг еды в день.");

        public void ListContactZooAnimals()
        {
            var contactAnimals = _animals.OfType<Herbo>().Where(a => a.Kindness >= 5);
            Console.WriteLine("Животные, которые могут быть помещены в контактный зоопарк:");
            foreach (var animal in contactAnimals)
                Console.WriteLine(animal.GetType().Name);
        }

        public void ListInventory()
        {
            Console.WriteLine("Инвентарь зоопарка:");
            foreach (var item in _inventory)
                Console.WriteLine($"{item.GetType().Name}, Номер. №{item.Number}");
        }
    }
}
