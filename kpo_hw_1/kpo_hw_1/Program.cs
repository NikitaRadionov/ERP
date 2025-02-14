using System;
using Microsoft.Extensions.DependencyInjection;
using DI;
using Services;
using Models;



class Program
{
    static void Main(string[] args)
    {

        var serviceProvider = DependencyInjection.ConfigureServices();
        var zoo = serviceProvider.GetRequiredService<Zoo>();

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Добавить животное");
            Console.WriteLine("2. Добавить вещь");
            Console.WriteLine("3. Показать контактных животных");
            Console.WriteLine("4. Показать инвентарь");
            Console.WriteLine("5. Отчет по еде");
            Console.WriteLine("6. Exit");
            Console.Write("Выберите действие: ");

            switch (Console.ReadLine())
            {
                case "1":
                    zoo.AddAnimal(new Monkey(3, 7));
                    break;
                case "2":
                    zoo.AddThing(new Thing(5));
                    break;
                case "3":
                    zoo.ListContactZooAnimals();
                    break;
                case "4":
                    zoo.ListInventory();
                    break;
                case "5":
                    zoo.ReportFoodConsumption();
                    break;
                case "6":
                    break;
                default:
                    Console.WriteLine("Неверный ввод!");
                    break;
            }
        }
    }
}