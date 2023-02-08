using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Saga
{
    internal class Knight : Character
    {
        Random random = new Random();
        public Knight(int health, int strengh, string characterName) : base(health, strengh)
        {
            this.health = health;
            this.strengh = strengh;
            this.characterName = characterName;

            className = "Knight";
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
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{Info()} использует Удар Возмездия на {enemy.Info()}");
                enemy.TakeDamage(strengh + strengh * 50 / 100);
                Console.ResetColor();
            }
            else
            {
                base.AttackEnemy(enemy);
            }
        }
    }
}
