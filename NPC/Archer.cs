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
        double bonusDamage;
        bool isBuffed;

        public Archer(int strength, int health, string charName, string bow, string className)
        {
            this.Strength = strength;
            this.Health = health;
            this.bow = bow;
            this.className = className;
            this.charName = charName;
            TotalDamage = strength;
            isBuffed = false;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Character name: {charName}\n" +
                              $"Class name: {className}\n" +
                              $"Bow: {bow}\n" +
                              $"Total damage: {TotalDamage}\n" +
                              $"Strength: {Strength}\n" +
                              $"Bonus damage: {bonusDamage}\n" +
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
            { bonusDamage += 5; }
            else
            { bonusDamage = 0; }
            TotalDamage = Strength + bonusDamage;
        }
    }
}
