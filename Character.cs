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

        abstract public void CharAbility();
        abstract public void ShowInfo();
    }
}