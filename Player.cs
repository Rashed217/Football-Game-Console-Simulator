using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Game_Console_Simulator
{
    public enum Position
    {
        Forward,
        MidFielder,
        Defender,
        Goalkeeper
    }

    public class Player
    {
        public string Name { get; set; }
        public Position Position { get; set; }
        public int Skill {  get; set; }

        public Player(string name, Position position, int skill)
        {
            Name = name;
            Position = position;
            Skill = skill;
        }
    }
}
