//using мама
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Model
{
    public class GameSession
    {
        public Tournament Tournament { get; set; }
        public int FirstClubResult { get; set; }
        public int SecondClubResult { get; set; }
        public List<Club> Clubs { get; set; } = new List<Club>(2);
    }
}
