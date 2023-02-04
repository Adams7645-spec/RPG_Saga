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
            Random random = new Random();
            int counter = 0;
            int charIndex;
            string[] fantasyNames = { "King Sadon", "Squire Otis", "Earl Aunger", "Cardinal Fulco", "Duke Jake", "Bishop Owen",
                                      "Georholan", "Frearyza", "Waldsulen", "Ridan", "Samorddic", "Vadephar",
                                      "Halcamo","Meragortar", "Ivari", "Beriax"};

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

                //Создаем выбранного персонажа
                switch (selectedClassName)
                {
                    case 1:
                        Console.Clear();
                        nps.Add(new Archer(random.Next(15, 25), random.Next(80, 95), fantasyNames[random.Next(fantasyNames.Length)], "Daedalus", "Archer"));
                        break;
                    case 2:
                        Console.Clear();
                        nps.Add(new Knight(random.Next(15, 20), random.Next(90, 110), fantasyNames[random.Next(fantasyNames.Length)], "Excalibur", "Knight"));
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
            //Зациклить до момента, пока длина листа не будет равна 1, погибшие персонажи удаляются из листа
            while (nps.Count != 1) {
                //Шаг charIndex в 2 единицы для имитации пар
                for (charIndex = 0; charIndex < nps.Count; charIndex += 2)
                {
                    Console.WriteLine("\n┌──────────────────────────────────────┐");
                    Console.WriteLine($"Новая пара соперников: {nps[charIndex].CharName} против {nps[charIndex + 1].CharName}\n" +
                                      $"Сведения о соперниках: \n");
                    nps[charIndex].ShowInfo();
                    nps[charIndex + 1].ShowInfo();
                    counter = 0;

                    do
                    {
                        //Считаем ходы
                        counter++;
                        Console.WriteLine($"─\nХод №{counter}\n─");

                        //Может атаковать пока жив
                        if (nps[charIndex].Health > 0)
                        {
                            if (random.Next(0, 100) <= nps[charIndex].AbilityProcChance)
                            {
                                nps[charIndex].CharAbility();
                                Console.WriteLine($"\n{nps[charIndex].CharName} использует { nps[charIndex].AbilityName}\n");
                                nps[charIndex].AttackWithAbbility(nps[charIndex], nps[charIndex + 1]);
                            }
                            else
                            {
                                nps[charIndex].AttackEnemy(nps[charIndex], nps[charIndex + 1]);
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{nps[charIndex].CharName} погиб!");
                            nps[charIndex].IsAlive = false;
                            break;
                        }

                        if (nps[charIndex + 1].Health > 0)//Может атаковать пока жив
                        {
                            if (random.Next(0, 100) <= nps[charIndex + 1].AbilityProcChance)
                            {
                                nps[charIndex + 1].CharAbility();
                                Console.WriteLine($"\n{nps[charIndex + 1].CharName} использует { nps[charIndex + 1].AbilityName}\n");
                                nps[charIndex + 1].AttackWithAbbility(nps[charIndex + 1], nps[charIndex]);
                            }
                            else
                            {
                                nps[charIndex + 1].AttackEnemy(nps[charIndex + 1], nps[charIndex]);
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{nps[charIndex + 1].CharName} погиб!");
                            nps[charIndex + 1].IsAlive = false;
                            break;
                        }

                        nps[charIndex].ShowInfo();
                        nps[charIndex + 1].ShowInfo();
                        Console.WriteLine("────────────────────────────────────────");
                    }
                    while (nps[charIndex].Health > 0 || nps[charIndex + 1].Health > 0);

                    Console.WriteLine("\n└──────────────────────────────────────┘\n");
                }

                //Удаляем поверженых соперников из листа
                for (int charIndexDEL = 0; charIndexDEL < nps.Count; charIndexDEL++)
                {
                    if (nps[charIndexDEL].IsAlive == false)
                    {
                        nps.Remove(nps[charIndexDEL]);
                    }
                }
            }
            Console.WriteLine($"Победил {nps[0].CharName}");
            Console.ReadLine();
        }
    }
}