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
            this.className = className;
            this.CharName = charName;
            TotalDamage = strength;
            isBuffed = false;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Character name: {CharName}\n" +
                              $"Class name: {className}\n" +
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
            isBuffed = true;
            if (isBuffed == true)
            { AbilityDamage += 5; }
            else
            { AbilityDamage = 0; }
            TotalDamage = Strength + AbilityDamage;
        }

        public override void AttackWithAbbility(Character ally, Character enemy)
        {
        }
    }
}
