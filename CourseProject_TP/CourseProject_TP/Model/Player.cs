using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_TP.Model
{
    public class Player
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronym { get; set; }
        public Club Club { get; set; }
        public Player(string name, string surname, string patronym)
        {
            Name = name;
            Surname = surname;
            Patronym = patronym;
        }
        public Player(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}
