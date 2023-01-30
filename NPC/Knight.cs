using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Saga
{
    internal class Knight : Character
    {
        string sword;
        double abilityDamage;

        public Knight(int strength, int health, string charName, string sword, string className) : base(strength, health, charName, className)
        {
            this.sword = sword;
            this.className = className;
            this.charName = fantasyNames[GetRandom.Next(fantasyNames.Length)];
        }
        public override void CharAbility()
        {
            abilityDamage = strength * 30 / 100;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Character name: {charName}\n" +
                  $"Class name: {className}\n" +
                  $"Sword: {sword}\n" +
                  $"Strength: {strength}\n" +
                  $"Ability damage: {abilityDamage}\n" +
                  $"Health: {health}\n");
        }
    }
}
