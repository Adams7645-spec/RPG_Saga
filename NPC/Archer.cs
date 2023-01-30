using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Saga
{
    internal class Archer : Character
    {
        string bow;
        double totalDamage;
        double bonusDamage;
        bool isBuffed;

        public Archer(int strength, int health, string charName, string bow, string className) : base(strength, health, charName, className)
        {
            this.bow = bow;
            this.className = className;
            this.charName = fantasyNames[GetRandom.Next(fantasyNames.Length)];
        }
        public override void CharAbility()
        {
            isBuffed = true;
            if (isBuffed == true) 
            { bonusDamage += 2; }
            else 
            { bonusDamage = 0; }
            this.totalDamage = strength + bonusDamage;
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"Character name: {charName}\n" +
                              $"Class name: {className}\n" +
                              $"Bow: {bow}\n" +
                              $"Total damage: {totalDamage}\n" +
                              $"Strength: {strength}\n" +
                              $"Bonus damage: {bonusDamage}\n" +
                              $"Is buffed: {isBuffed}\n" +
                              $"Health: {health}\n");
        }
    }
}
