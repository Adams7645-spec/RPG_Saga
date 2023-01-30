using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Saga
{
    internal abstract class Character
    {
        protected int strength;
        protected int health;
        protected string charName;
        protected string className;

        protected Random GetRandom = new Random();

        protected string[] fantasyNames = { "King Sadon", "Squire Otis", "Earl Aunger", "Cardinal Fulco", "Duke Jake", "Bishop Owen" };
        public Character(int strength, int health, string charName, string className)
        {
            this.strength = strength;
            this.health = health;
            this.charName = charName;
            this.className = className;
        }
        abstract public void CharAbility();
        abstract public void ShowInfo();
    }
}
