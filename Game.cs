using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Saga
{
    internal class Game
    {
        static void Main(string[] args)
        {
            Archer archer = new Archer(10, 50, "Test", "Daedalus", "Archer");
            Knight knight = new Knight(15, 75, "Test2", "Excalibur", "Knight");

            archer.CharAbility();
            archer.ShowInfo();

            knight.CharAbility();
            knight.ShowInfo();

            Console.ReadLine();
        }
    }
}
