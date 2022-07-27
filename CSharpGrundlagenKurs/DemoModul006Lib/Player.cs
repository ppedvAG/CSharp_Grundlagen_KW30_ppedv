using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoModul006Lib.People
{
    public class Player
    {
        public Player(string firstName, string lastName, Position pos, int goals)
        {
            FirstName = firstName;
            LastName = lastName;
            Pos = pos;
            Goals = goals;
        }

        public Player(Player player)
        {
            this.FirstName = player.FirstName;
            this.LastName = player.LastName;
            this.Pos = player.Pos;
            this.Goals = player.Goals;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Position Pos { get; set; }

        public int Goals { get; set; }
    }

    public enum Position {  TW, LV, IV, RV, DM, ZM, OFF, LM, RM, LA, ST, HS, RA } 
}
