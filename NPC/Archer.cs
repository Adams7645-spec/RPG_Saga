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
        bool isBuffed;

        public Archer(int strength, int health, string charName, string bow, string className)
        {
            this.Strength = strength;
            this.Health = health;
            this.bow = bow;
            this.ClassName = className;
            this.CharName = charName;
            DefaultDamage = strength;
            TotalDamage = DefaultDamage;
            AbilityProcChance = 25;
            AbilityName = "";
            IsAlive = true;
            isBuffed = false;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Character name: {CharName}\n" +
                              $"Class name: {ClassName}\n" +
                              $"Bow: {bow}\n" +
                              $"Total damage: {TotalDamage}\n" +
                              $"Strength: {Strength}\n" +
                              $"Bonus damage: {AbilityDamage}\n" +
                              $"Is buffed: {isBuffed}\n" +
                              $"Health: {Health}\n");
        }

        public override void AttackEnemy(Character ally, Character enemy)
        {
            enemy.Health -= Convert.ToInt32(ally.TotalDamage);
        }
        public override void CharAbility()
        {
            AbilityName = "Fiery fury";
            isBuffed = true;
            if (isBuffed == true)
            { 
                AbilityDamage += 15; 
            }
            else
            { 
                AbilityDamage = 0; 
            }
            TotalDamage = DefaultDamage + AbilityDamage;
        }

        public override void AttackWithAbbility(Character ally, Character enemy)
        {
        }
    }
}
