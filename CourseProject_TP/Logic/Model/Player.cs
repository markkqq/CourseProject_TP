using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Model
{
    public class Player
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Club Club { get; set; }
        public Player(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}
