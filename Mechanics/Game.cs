using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Saga
{
    internal class Game
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 20);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Random random = new Random();
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

                switch (selectedClassName)
                {
                    case 1:
                        Console.Clear();
                        nps.Add(new Archer(random.Next(15, 25), random.Next(50, 70), fantasyNames[random.Next(fantasyNames.Length)], "Daedalus", "Archer"));
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
            //Вывод информации о персонажах 
            for (int i = 0; i < n; i++)
            {
                nps[i].ShowInfo();
            }
            //Сражение персонажей (тест самого процесса)
            for (charIndex = 0; charIndex < nps.Count; charIndex += 2)//Шаг charIndex в 2 единицы для имитации пар
            {
                while (nps[charIndex].Health > 0 || nps[charIndex+1].Health > 0)
                {
                    if (nps[charIndex].Health > 0)
                    {
                        if (random.Next(0, 100) >= 75)
                        {
                            nps[charIndex].CharAbility();
                        }
                        nps[charIndex].AttackEnemy(nps[charIndex], nps[charIndex+1]);
                    }
                    else
                    {
                        break;
                    }

                    if (nps[charIndex+1].Health > 0)
                    {
                        if (random.Next(0, 100) >= 75)
                        {
                            nps[charIndex+1].CharAbility();
                        }
                        nps[charIndex+1].AttackEnemy(nps[charIndex+1], nps[charIndex]);
                    }
                    else 
                    { 
                        break; 
                    }

                    nps[charIndex].ShowInfo();
                    nps[charIndex+1].ShowInfo();
                }
            }

            Console.ReadLine();
        }
    }
}