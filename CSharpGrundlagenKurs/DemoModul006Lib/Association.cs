using DemoModul006Lib.ErstesNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoModul006Lib
{
    public class Association
    {
        public List<Club> Clubs { get; set; }

        public Association()
        {
            Clubs = new List<Club>();
        }

        public void InsertClub (Club newClub)
        {
            Clubs.Add(newClub);
        }
    }
}
