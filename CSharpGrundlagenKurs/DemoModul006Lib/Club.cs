using DemoModul006Lib.People;
using System;
using System.Collections.Generic;

namespace DemoModul006Lib.ErstesNamespace
{
    public class Club
    {
        public Player HallOfFamePlayer { get; set; } //Hierrüber kann ich erstens nur den DEfaukt-Konstruktor aufrufen 
        public List<Player> Team { get; set; }

        public Club()
        {
            Team = new List<Player>();  //Instanziiert, sonst Null-REference
        }

        //Für eine Spielvereinigung -> wäre in einer Methode eigentlich viel viel Besser
        public Club(params Club[] clubs)
            :this()
        {
            foreach (Club currentClub in clubs)
            {
                Team.AddRange(currentClub.Team.ToArray());
            }
        }

        public Club(Player HallOfFamePlayer)
            : this()
        {
            this.HallOfFamePlayer = HallOfFamePlayer;
            //this.HallOfFamePlayer.FirstName = "Roberto";
            //this.HallOfFamePlayer.LastName = "Blanco";
        }



       
    }   

   
}

namespace DemoModul006Lib.ZweitesNamespace
{
    public class Club
    {
    }
}
