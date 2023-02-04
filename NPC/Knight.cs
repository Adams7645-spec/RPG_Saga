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
            this.ClassName = className;
            this.CharName = charName;
            DefaultDamage = strength;
            IsAlive = true;
            AbilityProcChance = 25;
            AbilityName = "";
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"Character name: {CharName}\n" +
                  $"Class name: {ClassName}\n" +
                  $"Sword: {sword}\n" +
                  $"Strength: {Strength}\n" +
                  $"Ability damage: {AbilityDamage}\n" +
                  $"Health: {Health}\n");
        }
        public override void CharAbility()
        {
            AbilityName = "Vengeance Strike";
            AbilityDamage = DefaultDamage + DefaultDamage * 30 / 100;
        }
        public override void AttackEnemy(Character ally, Character enemy)
        {
            enemy.Health -= Convert.ToInt32(ally.DefaultDamage);
        }

        public override void AttackWithAbbility(Character ally, Character enemy)
        {
            ally.CharAbility();
            enemy.Health -= Convert.ToInt32(ally.AbilityDamage);
        }
    }
}
