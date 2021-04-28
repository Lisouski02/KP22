using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        class HouseExсeption : Exception
        {
            public HouseExсeption(string message): base(message)
            {}
        }

        class House
        {
            string NameOfStreet;
            int NumberOfHouse;
            int AmountOfFlors;
            int AmountOfPorch;
            int AmountOfFlatOnTheFloor;

            public House(string nameOfStreet, int numberOfHouse, int amountOfFlors, int amountOfPorch, int amountOfFlatOnTheFloor)
            {
                NameOfStreet1 = nameOfStreet;
                NumberOfHouse1 = numberOfHouse;
                AmountOfFlors1 = amountOfFlors;
                AmountOfPorch1 = amountOfPorch;
                AmountOfFlatOnTheFloor1 = amountOfFlatOnTheFloor;
            }

            public House()
            {}

            public string NameOfStreet1
            {
                get => NameOfStreet;
                set
                {
                    int s = 0;
                    int s1 = 0;
                    for (int i = 0; i < value.Length; i++)
                        if (char.IsUpper(value[i]))
                            s1++;
                    

                    for (int i = 0; i < 1; i++)
                    {
                        if (char.IsUpper(value[0]))
                            s++;
                        if (s == 0 | s1 > 1)
                            throw new HouseExсeption("Название улици введено с маленькой буквы или присутствуют несколько заглавных.");
                        else
                            NameOfStreet = value;
                    }
                }
            }
            public int NumberOfHouse1
            {
                get => NumberOfHouse;
                set
                {
                    if (value <= 0)
                        throw new HouseExсeption("Номер дома не может быть отрицательным или равным нулю.");
                    else
                        NumberOfHouse = value;
                }
            }
            public int AmountOfFlors1
            {
                get => AmountOfFlors;
                set
                {
                    if (value <= 0)
                        throw new HouseExсeption("Количество этажей не может быть отрицательным или равным нулю.");
                    else
                        AmountOfFlors = value;
                }
            }
            public int AmountOfPorch1
            {
                get => AmountOfPorch;
                set
                {
                    if (value <= 0)
                        throw new HouseExсeption("Количество подъездов не может быть отрицательным или равным нулю.");
                    else
                        AmountOfPorch = value;
                }
            }
            public int AmountOfFlatOnTheFloor1
            {
                get => AmountOfFlatOnTheFloor;
                set
                {
                    if (value <= 0)
                        throw new HouseExсeption("Количество квартир на этаже не может быть отрицательным или ранво нулю.");
                    else
                        AmountOfFlatOnTheFloor = value;
                }
            }

            public void Show()
            {
                Console.WriteLine("Название улице: " + NameOfStreet);
                Console.WriteLine("Номер дома: " + NumberOfHouse);
                Console.WriteLine("Количество этажей: " + AmountOfFlors);
                Console.WriteLine("Количество подъездов: " + AmountOfPorch);
                Console.WriteLine("Количество квартир на этаже: " + AmountOfFlatOnTheFloor);
                Console.WriteLine();
            }

            public void Enter()
            {
                bool w = true;
                while (w)
                {
                    try
                    {
                        Console.Write("Введите название улицы: ");
                        NameOfStreet1 = Console.ReadLine();
                        Console.Write("Введите Номер дома: ");
                        NumberOfHouse1 = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите количество этажей: ");
                        AmountOfFlors1 = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите количество подъездов : ");
                        AmountOfPorch1 = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите количество квартир на этаже: ");
                        AmountOfFlatOnTheFloor1 = Convert.ToInt32(Console.ReadLine());
                        w = false;
                    }
                    catch (HouseExсeption e)
                    {
                        w = true;
                        Console.WriteLine(e.Message);
                    }

                }
            }
        }

        static void ShowInfo(List<House> houses)
        {
            for (int i = 0; i < houses.Count; i++)
                houses[i].Show();
        }
        

        static void Main(string[] args)
        {
            List<House> houses = new List<House>()
            {
                new House("Хорошая",15,9,1,7),
                new House("Одинцова",15,6,10,4),
                new House("Якубовского",9,9,5,8),
                new House("Бурдейного",5,9,9,5),
                new House("Хорошая",12,2,1,4),
                new House("Адоевского",1,9,15,8),
                new House("Куйбышего",55,12,6,4),
                new House("Лидская",22,5,7,13),
                new House("Хорошая",16,5,5,7),
                new House("Плохая",33,2,12,6)
            };

            Console.WriteLine("Меню:");
            Console.WriteLine("1. Вывод текущего списка.");
            Console.WriteLine("2. Добавление объектов в текущий список.");
            Console.WriteLine("3. Выполнение запросов.");
            Console.WriteLine("4. Повторить действие.");
            Console.WriteLine("5. Выход из программы.");
            int a = 0;
            bool again = true;
            while(again)
            {
                Console.Write("Вберете пункт меню: ");
                int b = a;
                a = Convert.ToInt32(Console.ReadLine());
                
                switch (a)
                {
                    case 1:
                        {
                            ShowInfo(houses);
                        }
                        break;
                    case 2:
                        {
                            houses.Add(new House());
                            houses[houses.Count - 1].Enter();
                        }
                        break;
                    case 3:
                        {
                            var HOUSES = from house in houses
                                         orderby house.NameOfStreet1, house.NumberOfHouse1
                                         ascending
                                         select house;
                            Console.WriteLine("\nОтсортированный список:");
                            foreach (var house in HOUSES)
                            {
                                house.Show();
                                Console.WriteLine();
                            }

                            Console.WriteLine("Дома на одной улице:");

                            var HWON = from house in houses
                                       group house by house.NameOfStreet1;
                            foreach (var street in HWON)
                            {
                                if (street.Count() > 1)
                                {
                                    Console.WriteLine(street.Key + ':');
                                    foreach (var house in street)
                                        Console.WriteLine(house.NumberOfHouse1);
                                    Console.WriteLine();
                                }
                            }

                            Console.WriteLine("Дома у которых количество подъездов и квартир нечётное:");

                            var h1 = from house in houses
                                     where (house.AmountOfPorch1 % 2 != 0) & (house.AmountOfFlatOnTheFloor1 % 2 != 0)
                                     select house;
                            foreach (var house in h1)
                                house.Show();

                            Console.WriteLine("Общее колличество кваритр в доме и по списку:");

                            int hata = 0, sumhata = 0;
                            foreach (var house in houses)
                            {
                                hata = house.AmountOfFlatOnTheFloor1 * house.AmountOfPorch1 * house.AmountOfFlors1;
                                sumhata += hata;
                                Console.WriteLine($"Количество квартир в доме ({house.NameOfStreet1} {house.NumberOfHouse1}) : {hata}");
                            }

                            Console.WriteLine("Количество квартир во всех домах: " + sumhata);

                            Console.WriteLine("Группировка по каждому полю:");

                            var Name = from house in houses
                                       group house by house.NameOfStreet1;
                            Console.WriteLine("\nГруппировка по названию улицы:");
                            foreach (var street in Name)
                            {
                                if (street.Count() > 1)
                                {
                                    Console.WriteLine(street.Key + ':');
                                    foreach (var house in street)
                                        Console.WriteLine(house.NumberOfHouse1);
                                    Console.WriteLine();
                                }
                            }

                            var Number = from house in houses
                                         group house by house.NumberOfHouse1;
                            Console.WriteLine("\nГруппировка по номеру дома:");
                            foreach(var street in Number)
                            {
                                if (street.Count() > 1)
                                {
                                    Console.WriteLine(street.Key + ':');
                                    foreach (var house in street)
                                        Console.WriteLine(house.NumberOfHouse1);
                                    Console.WriteLine();
                                }
                            }
                            var Floors = from house in houses
                                         group house by house.AmountOfFlors1;
                            Console.WriteLine("\nГруппировка по количеству этажей в доме:");
                            foreach (var street in Floors)
                            {
                                if (street.Count() > 1)
                                {
                                    Console.WriteLine(street.Key + ':');
                                    foreach (var house in street)
                                        Console.WriteLine(house.NumberOfHouse1);
                                    Console.WriteLine();
                                }
                            }

                            var Porchs = from house in houses
                                         group house by house.AmountOfPorch1;
                            foreach (var street in Porchs)
                            {
                                if (street.Count() > 1)
                                {
                                    Console.WriteLine(street.Key + ':');
                                    foreach (var house in street)
                                        Console.WriteLine(house.NumberOfHouse1);
                                    Console.WriteLine();
                                }
                            }

                            var Floors1 = from house in houses
                                          group house by house.AmountOfPorch1;
                            Console.WriteLine("\nГруппировка по количеству квартир на этаже:");
                            foreach (var street in Floors1)
                            {
                                if (street.Count() > 1)
                                {
                                    Console.WriteLine(street.Key + ':');
                                    foreach (var house in street)
                                        Console.WriteLine(house.NumberOfHouse1);
                                    Console.WriteLine();
                                }
                            }

                        }
                        break;
                    case 4:
                        {
                            switch (b)
                            {
                                case 1:
                                    {
                                        ShowInfo(houses);
                                    }
                                    break;
                                case 2:
                                    {
                                        houses.Add(new House());
                                        houses[houses.Count - 1].Enter();
                                    }
                                    break;
                                case 3:
                                    {
                                        var HOUSES = from house in houses
                                                     orderby house.NameOfStreet1, house.NumberOfHouse1
                                                     ascending
                                                     select house;
                                        Console.WriteLine("\nОтсортированный список:");
                                        foreach (var house in HOUSES)
                                        {
                                            house.Show();
                                            Console.WriteLine();
                                        }

                                        Console.WriteLine("Дома на одной улице:");

                                        var HWON = from house in houses
                                                   group house by house.NameOfStreet1;
                                        foreach (var street in HWON)
                                        {
                                            if (street.Count() > 1)
                                            {
                                                Console.WriteLine(street.Key + ':');
                                                foreach (var house in street)
                                                    Console.WriteLine(house.NumberOfHouse1);
                                                Console.WriteLine();
                                            }
                                        }

                                        Console.WriteLine("Дома у которых количество подъездов и квартир нечётное:");

                                        var h1 = from house in houses
                                                 where (house.AmountOfPorch1 % 2 != 0) & (house.AmountOfFlatOnTheFloor1 % 2 != 0)
                                                 select house;
                                        foreach (var house in h1)
                                            house.Show();

                                        Console.WriteLine("Общее колличество кваритр в доме и по списку:");

                                        int hata = 0, sumhata = 0;
                                        foreach (var house in houses)
                                        {
                                            hata = house.AmountOfFlatOnTheFloor1 * house.AmountOfPorch1 * house.AmountOfFlors1;
                                            sumhata += hata;
                                            Console.WriteLine($"Количество квартир в доме ({house.NameOfStreet1} {house.NumberOfHouse1}) : {hata}");
                                        }

                                        Console.WriteLine("Количество квартир во всех домах: " + sumhata);

                                        Console.WriteLine("Группировка по каждому полю:");

                                        var Name = from house in houses
                                                   group house by house.NameOfStreet1;
                                        Console.WriteLine("\nГруппировка по названию улицы:");
                                        foreach (var street in Name)
                                        {
                                            if (street.Count() > 1)
                                            {
                                                Console.WriteLine(street.Key + ':');
                                                foreach (var house in street)
                                                    Console.WriteLine(house.NumberOfHouse1);
                                                Console.WriteLine();
                                            }
                                        }

                                        var Number = from house in houses
                                                     group house by house.NumberOfHouse1;
                                        Console.WriteLine("\nГруппировка по номеру дома:");
                                        foreach (var street in Number)
                                        {
                                            if (street.Count() > 1)
                                            {
                                                Console.WriteLine(street.Key + ':');
                                                foreach (var house in street)
                                                    Console.WriteLine(house.NumberOfHouse1);
                                                Console.WriteLine();
                                            }
                                        }
                                        var Floors = from house in houses
                                                     group house by house.AmountOfFlors1;
                                        Console.WriteLine("\nГруппировка по количеству этажей в доме:");
                                        foreach (var street in Floors)
                                        {
                                            if (street.Count() > 1)
                                            {
                                                Console.WriteLine(street.Key + ':');
                                                foreach (var house in street)
                                                    Console.WriteLine(house.NumberOfHouse1);
                                                Console.WriteLine();
                                            }
                                        }

                                        var Porchs = from house in houses
                                                     group house by house.AmountOfPorch1;
                                        foreach (var street in Porchs)
                                        {
                                            if (street.Count() > 1)
                                            {
                                                Console.WriteLine(street.Key + ':');
                                                foreach (var house in street)
                                                    Console.WriteLine(house.NumberOfHouse1);
                                                Console.WriteLine();
                                            }
                                        }

                                        var Floors1 = from house in houses
                                                      group house by house.AmountOfPorch1;
                                        Console.WriteLine("\nГруппировка по количеству квартир на этаже:");
                                        foreach (var street in Floors1)
                                        {
                                            if (street.Count() > 1)
                                            {
                                                Console.WriteLine(street.Key + ':');
                                                foreach (var house in street)
                                                    Console.WriteLine(house.NumberOfHouse1);
                                                Console.WriteLine();
                                            }
                                        }

                                    }
                                    break;
                                default:
                                    Console.WriteLine("Такого пункта нету.");
                                    break;
                            }
                        }
                        break;
                    case 5:
                        {
                            again = false;
                        }
                        break;
                    default:
                        Console.WriteLine("Такого пункта нету.");
                        break;
                }
            }
        }
    }
}
