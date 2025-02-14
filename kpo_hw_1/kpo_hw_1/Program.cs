using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

interface IAlive
{
    int Food { get; set; }
}

interface IInventory
{
    int Number { get; set; }
}




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

class Herbo : Animal
{
    public int Kindness { get; set; }
    public Herbo(int number, int food = 10, int kindness = 5): base(number, food)
    {
        Kindness = kindness;
    }
}

class Predator : Animal
{
    public Predator(int number, int food = 10): base(number, food) { }
}

class Monkey : Herbo { public Monkey(int number, int food = 10, int kindness = 5) : base(number, food, kindness) { } }
class Rabbit : Herbo { public Rabbit(int number, int food = 10, int kindness = 5) : base(number, food, kindness) { } }
class Tiger : Predator { public Tiger(int number, int food = 10) : base(number, food) { } }
class Wolf : Predator { public Wolf(int number, int food = 10) : base(number, food) { } }




class Thing : IInventory
{
    public int Number { get; set; }

    public Thing(int number) { Number = number; }
}

class Table : Thing
{
    public Table(int number) : base(number) { }
}

class Computer : Thing
{
    public Computer(int number) : base(number) { }
}


class VetClinic
{
    public bool CheckHealth(Animal animal) => new Random().Next(0, 2) == 1;
}

// Зоопарк
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
            Console.WriteLine($"{item.GetType().Name}, Инв. №{item.Number}");
    }
}



class Program
{
    static void Main(string[] args)
    {
    }
}