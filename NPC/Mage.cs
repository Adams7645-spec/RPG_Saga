using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Saga
{
    internal class Mage : Character
    {
        Random random = new Random();
        public Mage(int health, int strengh, string characterName) : base(health, strengh)
        {
            this.health = health;
            this.strengh = strengh;
            this.characterName = characterName;
            className = "Mage";
        }
        public override void AttackEnemy(Character enemy)
        {
            if (statusBurn)
            {
                TakeDamage(burnDamage = 5);
            }
            if (statusStan)
            {
                return;
            }
            if (random.Next(100) >= 75)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Info()} завораживает {enemy.Info()}");
                enemy.Stan();
                base.AttackEnemy(enemy);
                Console.ResetColor();
            }
            else
            {
                base.AttackEnemy(enemy);
            }
        }
    }
}
