using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_TP.Model
{
    public class GameSession
    {
        public Club[] Clubs { get; } = new Club[2];
        public DateTime DateTime { get; }
        public Tournament Tournament { get; }
        public Club Winner { get; set; }
        
    }
}
