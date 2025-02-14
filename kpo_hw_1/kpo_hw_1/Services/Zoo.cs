using System;
using Models;

namespace Services
{
    class Zoo
    {
        readonly List<Animal> _animals = new();
        readonly List<Thing> _inventory = new();
        readonly VetClinic _vetClinic;

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

        public void AddThing(Thing thing) => _inventory.Add(thing);

        public void ReportFoodConsumption() => Console.WriteLine($"Животные потребляют {_animals.Sum(a => a.Food)} кг еды в день.");

        public void ListContactZooAnimals()
        {
            var contactAnimals = _animals.OfType<Herbo>().Where(a => a.Kindness > 5);
            Console.WriteLine("Животные контактного зоопарка:");
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
