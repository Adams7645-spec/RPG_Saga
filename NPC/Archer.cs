using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Saga
{
    internal class Archer : Character
    {
        Random random = new Random();
        public Archer(int health, int strengh, string characterName) : base(health, strengh)
        {
            this.health = health;
            this.strengh = strengh;
            this.characterName = characterName;

            burnDamage = 0;

            className = "Archer";
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
            if (random.Next(100) >= 50)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{Info()} поджигает {enemy.Info()}");
                enemy.Burn();
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
