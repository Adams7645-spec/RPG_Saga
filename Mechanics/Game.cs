using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_Saga
{
    internal class Game
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 20);
            Console.ForegroundColor = ConsoleColor.White;
            Random random = new Random();
            int counter = 0;
            int charIndex;
            string[] fantasyNames = { "King Sadon", "Squire Otis", "Earl Aunger", "Cardinal Fulco", "Duke Jake", "Bishop Owen" };

            //Тут хранятся экземпляры персонажей
            List<Character> nps = new List<Character>();

            Console.Write("Введите число игроков: ");
            int n = Convert.ToInt32(Console.ReadLine());

            //Запихиваем указанное кол-во персонажей в лист
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nВыберите класс персонажа №{i + 1}: \n" +
                                  $"1 - Archer\n" +
                                  $"2 - Knight\n" +
                                  $"3 - Mage (пока не работает)\n");

                int selectedClassName = int.Parse(Console.ReadLine());

                switch (selectedClassName)//Создаем выбранного персонажа
                {
                    case 1:
                        Console.Clear();
                        nps.Add(new Archer(random.Next(15, 25), random.Next(65, 80), fantasyNames[random.Next(fantasyNames.Length)], "Daedalus", "Archer"));
                        break;
                    case 2:
                        Console.Clear();
                        nps.Add(new Knight(random.Next(20, 30), random.Next(70, 90), fantasyNames[random.Next(fantasyNames.Length)], "Excalibur", "Knight"));
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Выбран несуществующий класс!");
                        break;
                }
            }
            //Вывод информации о персонажах (Для тестов)
            //for (int i = 0; i < n; i++)
            //{
            //    nps[i].ShowInfo();
            //}

            //Сражение персонажей (тест самого процесса)
            for (charIndex = 0; charIndex < nps.Count; charIndex += 2)//Шаг charIndex в 2 единицы для имитации пар
            {
                Console.WriteLine("┌──────────────────────────────────────┐");
                Console.WriteLine($"Новая пара соперников: {nps[charIndex].CharName} против {nps[charIndex + 1].CharName}\n" +
                                  $"Сведения о соперниках: \n");
                nps[charIndex].ShowInfo();
                nps[charIndex + 1].ShowInfo();
                counter = 0;
                do
                {
                    counter++;//Считаем ходы

                    if (nps[charIndex].Health > 0)//Может атаковать пока жив
                    {
                        if (random.Next(0, 100) >= 75)
                        {
                            nps[charIndex].CharAbility();
                            nps[charIndex].AttackWithAbbility(nps[charIndex], nps[charIndex + 1]);
                        }
                        nps[charIndex].AttackEnemy(nps[charIndex], nps[charIndex + 1]);
                    }
                    else
                    {
                        Console.WriteLine($"\n{nps[charIndex].CharName} погиб!\n");
                        break;
                    }

                    if (nps[charIndex + 1].Health > 0)//Может атаковать пока жив
                    {
                        if (random.Next(0, 100) >= 75)
                        {
                            nps[charIndex + 1].CharAbility();
                            nps[charIndex + 1].AttackWithAbbility(nps[charIndex + 1], nps[charIndex]);
                        }
                        nps[charIndex + 1].AttackEnemy(nps[charIndex + 1], nps[charIndex]);
                    }
                    else
                    {
                        Console.WriteLine($"\n{nps[charIndex + 1].CharName} погиб!\n");
                        break;
                    }

                    Console.WriteLine($"─\nХод №{counter}\n─");
                    nps[charIndex].ShowInfo();
                    nps[charIndex + 1].ShowInfo();
                    Console.WriteLine("────────────────────────────────────────");
                } while (nps[charIndex].Health > 0 || nps[charIndex + 1].Health > 0);
                Console.WriteLine("└──────────────────────────────────────┘");
            }

            Console.ReadLine();
        }
    }
}