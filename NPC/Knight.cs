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

        public Knight(int strength, int health, string charName, string sword, string className)
        {
            this.Strength = strength;
            this.Health = health;
            this.sword = sword;
            this.className = className;
            this.CharName = charName;
            TotalDamage = strength;
        }

        public override void CharAbility()
        {
            AbilityDamage = Strength * 30 / 100;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Character name: {CharName}\n" +
                  $"Class name: {className}\n" +
                  $"Sword: {sword}\n" +
                  $"Strength: {Strength}\n" +
                  $"Ability damage: {AbilityDamage}\n" +
                  $"Health: {Health}\n");
        }
        public override void AttackEnemy(Character ally, Character enemy)
        {
            enemy.Health -= Convert.ToInt32(ally.TotalDamage);
        }

        public override void AttackWithAbbility(Character ally, Character enemy)
        {
            ally.CharAbility();
            enemy.Health -= Convert.ToInt32(ally.AbilityDamage);
        }
    }
}
