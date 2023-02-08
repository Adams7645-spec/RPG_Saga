using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Saga
{
    internal class Character
    {
        protected int health;
        protected int strengh;
        protected int burnDamage;

        protected string characterName;
        protected string className;

        protected bool statusStan;
        protected bool statusBurn;

        public Character(int health, int strengh)
        {
            this.health = health;
            this.strengh = strengh;


            statusStan = false;
            statusBurn = false;
        }

        public void Burn()
        {
            statusBurn = true;
        }
        public void Stan()
        {
            statusStan = true;
        }
        public virtual void AttackEnemy(Character enemy)
        {
            Console.WriteLine($"{Info()} атакует {enemy.Info()}");
            enemy.TakeDamage(strengh);
        }
        public virtual void TakeDamage(int damage)
        {
            health -= damage;
            Console.WriteLine($"{Info()} получает {damage} единиц урона\n");
        }
        public bool CheckDeath()
        {
            return health <= 0;
        }
        public string Info()
        {
            return $"[{className}] {characterName} [{health} HP]";
        }
    }
}