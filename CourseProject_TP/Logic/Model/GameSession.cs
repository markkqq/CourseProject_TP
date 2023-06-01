using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_TP.Logic.Model
{
    public class GameSession
    {
        public List<Club> Clubs { get; set; } = new List<Club>(2);
        public DateTime Date { get; set; }
        public Tournament Tournament { get; }
        public Club Winner { get; set; }
        
    }
}
