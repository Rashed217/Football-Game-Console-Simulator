using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Game_Console_Simulator
{
    public class Team
    {
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public int Score { get; set; }

        public Team(string name)
        {
            Name = name;
            Players = new List<Player>();
            Score = 0;
        }


    }
}
