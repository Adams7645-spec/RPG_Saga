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

        public Knight(int strength, int health, string charName, string sword, string className)
        {
            this.Strength = strength;
            this.Health = health;
            this.sword = sword;
            this.className = className;
            this.charName = charName;
        }

        public override void CharAbility()
        {
            abilityDamage = Strength * 30 / 100;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Character name: {charName}\n" +
                  $"Class name: {className}\n" +
                  $"Sword: {sword}\n" +
                  $"Strength: {Strength}\n" +
                  $"Ability damage: {abilityDamage}\n" +
                  $"Health: {Health}\n");
        }
        public override void AttackEnemy(Character ally, Character enemy)
        {
            throw new NotImplementedException();
        }
    }
}
