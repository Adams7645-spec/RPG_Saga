using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_Saga
{
    internal class Game
    {
        public static Random random = new Random();
        static public string GetCharNameGenerator()
        {
            string[] syllable1 = { "Khu", "Humb", "Ril", "Quro", "Dern" };
            string[] syllable2 = { "jie", "quro", "wood", "der", "orn" };
            string[] syllable3 = { "Bler", "Buva", "Th", "Assu", "Liz" };
            string[] syllable4 = { "spi", "mald", "gl", "ider", "vif" };

            return $"{syllable1[random.Next(syllable1.Length)] + syllable2[random.Next(syllable2.Length)]} {syllable3[random.Next(syllable3.Length)] + syllable4[random.Next(syllable4.Length)]}";
        }
        static void Main(string[] args)
        {
            Character archer = new Archer(random.Next(100, 120), random.Next(20, 30), GetCharNameGenerator());
            Character mage = new Mage(random.Next(120, 140), random.Next(15, 20), GetCharNameGenerator());

            while (true)
            {
                archer.AttackEnemy(mage);
                if (mage.CheckDeath()) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{mage.Info()} погиб!");
                    Console.ResetColor();
                    break;
                }
                mage.AttackEnemy(archer);
                if (archer.CheckDeath())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{archer.Info()} погиб!");
                    Console.ResetColor();
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}