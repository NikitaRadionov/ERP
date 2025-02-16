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
        bool run = true;

        while (run)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Добавить животное");
            Console.WriteLine("2. Добавить вещь");
            Console.WriteLine("3. Показать количество животных в зоопарке");
            Console.WriteLine("4. Показать контактных животных");
            Console.WriteLine("5. Показать инвентарь");
            Console.WriteLine("6. Отчет по еде");
            Console.WriteLine("7. Exit");
            Console.Write("Выберите действие: ");

            switch (Console.ReadLine())
            {
                case "1":
                    int number, food;

                    while (true)
                    {
                        Console.Write("Введите инвертаризационный номер (число): ");

                        if (int.TryParse(Console.ReadLine(), out number) && number > 0)
                        {
                            break;
                        }

                        Console.WriteLine("Ошибка! Введите целое число больше нуля.");
                    }

                    while (true)
                    {
                        Console.Write("Введите количество потребляемой еды в сутки (число): ");

                        if (int.TryParse(Console.ReadLine(), out food) && food > 0)
                        {
                            break;
                        }

                        Console.WriteLine("Ошибка! Введите целое число больше нуля.");
                    }



                    Console.WriteLine("1. Добавить хищника");
                    Console.WriteLine("2. Добавить травоядное");
                    Console.Write("Выберите действие: ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("1. Добавить тигра");
                            Console.WriteLine("2. Добавить волка");
                            Console.Write("Выберите действие: ");

                            switch(Console.ReadLine())
                            {
                                case "1":
                                    zoo.AddAnimal(new Tiger(number, food));
                                    break;
                                case "2":
                                    zoo.AddAnimal(new Wolf(number, food));
                                    break;
                                default:
                                    Console.WriteLine("Введен некорректный код.");
                                    break;
                            }

                            break;
                        case "2":
                            Console.WriteLine("1. Добавить кролика");
                            Console.WriteLine("2. Добавить обезьяну");
                            Console.Write("Выберите действие: ");

                            switch (Console.ReadLine())
                            {
                                case "1":
                                    zoo.AddAnimal(new Rabbit(number, food));
                                    break;
                                case "2":
                                    zoo.AddAnimal(new Monkey(number, food));
                                    break;
                                default:
                                    Console.WriteLine("Введен некорректный код.");
                                    break;
                            }

                            break;

                        default:
                            Console.WriteLine("Введен некорректный код.");
                            break;
                    }
                    break;
                case "2":

                    while (true)
                    {
                        Console.Write("Введите инвертаризационный номер (число): ");

                        if (int.TryParse(Console.ReadLine(), out number) && number > 0)
                        {
                            break;
                        }

                        Console.WriteLine("Ошибка! Введите целое число больше нуля.");
                    }

                    Console.WriteLine("1. Добавить стол");
                    Console.WriteLine("2. Добавить компьютер");
                    Console.Write("Выберите действие: ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            zoo.AddThing(new Table(number));
                            break;
                        case "2":
                            zoo.AddThing(new Computer(number));
                            break;
                        default:
                            Console.WriteLine("Введен некорректный код.");
                            break;
                    }
                    break;
                case "3":
                    zoo.GetAnimalCount();
                    break;
                case "4":
                    zoo.ListContactZooAnimals();
                    break;
                case "5":
                    zoo.ListInventory();
                    break;
                case "6":
                    zoo.ReportFoodConsumption();
                    break;
                case "7":
                    run = false;
                    break;
                default:
                    Console.WriteLine("Введен некорректный код.");
                    break;
            }
        }
    }
}