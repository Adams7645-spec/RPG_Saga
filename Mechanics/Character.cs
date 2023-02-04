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
        private double defaultDamage;
        private double abilityDamage;
        private double abilityProcChance;
        private string abilityName;
        private string charName;
        private string className;
        private bool isAlive;

        public int Health { get => health; set => health = value; }
        public int Strength { get => strength; set => strength = value; }
        public double TotalDamage { get => totalDamage; set => totalDamage = value; }
        public string CharName { get => charName; set => charName = value; }
        public double AbilityDamage { get => abilityDamage; set => abilityDamage = value; }
        public double DefaultDamage { get => defaultDamage; set => defaultDamage = value; }
        public double AbilityProcChance { get => abilityProcChance; set => abilityProcChance = value; }
        protected string ClassName { get => className; set => className = value; }
        public string AbilityName { get => abilityName; set => abilityName = value; }
        public bool IsAlive { get => isAlive; set => isAlive = value; }

        abstract public void CharAbility();
        abstract public void ShowInfo();
        abstract public void AttackEnemy(Character ally, Character enemy);
        abstract public void AttackWithAbbility(Character ally, Character enemy);
    }
}