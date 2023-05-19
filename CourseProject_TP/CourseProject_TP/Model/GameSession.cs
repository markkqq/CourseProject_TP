using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_TP.Model
{
    public class GameSession
    {
        Club[] Clubs { get; } = new Club[2];
        DateTime DateTime { get; }
        Tournament Tournament { get; }
        Club Winner { get; }
    }
}
