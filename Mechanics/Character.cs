using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Saga
{
    internal abstract class Character
    {
        private int strength;
        private int health;
        private double totalDamage;
        private string charName;
        protected string className;

        public int Health { get => health; set => health = value; }
        public int Strength { get => strength; set => strength = value; }
        public double TotalDamage { get => totalDamage; set => totalDamage = value; }
        public string CharName { get => charName; set => charName = value; }

        abstract public void CharAbility();
        abstract public void ShowInfo();
        abstract public void AttackEnemy(Character ally, Character enemy);
        abstract public void AttackWithAbbility(Character ally, Character enemy);
    }
}