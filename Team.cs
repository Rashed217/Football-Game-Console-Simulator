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
            Name = name; // Name of the team
            Players = new List<Player>(); // List to store the generated players
            Score = 0; // Default value is set by 0
        }

        public void GeneratePlayers()
        {
            Random random = new Random();

            Players.Add(new Player("Goalkeeper", Position.Goalkeeper, random.Next(1, 100))); // To generate only one Goalkeeper for a team with a random skill level

            for (int i = 0; i < 10; i++) // Used to add the remaining 10 players from (Forward, MidFielder, Defenders)
            {
                Position position;

                if (i < 3)
                {
                    position = Position.Forward; // First three players will be Forwards
                }

                else if (i < 6)
                {
                    position = Position.MidFielder; // Next three players will be MidFielders
                }

                else
                {
                    position = Position.Defender; // Last four players will be Defenders
                }

                string playerName = $"Player{i + 1}"; // Generating names for players for example (Player 1, Player 2, etc..)

                int skill = random.Next(1, 100); // Assigning Skill levels for the players

                Players.Add(new Player(playerName, position, skill)); // Adding the generated players to the list
            }
        }

        public int GetAttackSkill() // Method for calculating the total attacking power of the players
        {
            int attackSkill = 0; // Variable to store the total attacking power

            foreach (Player player in Players) // Iterates over all players
            {
                if (player.Position == Position.Forward || player.Position == Position.MidFielder) // Checks if players positions are Forward or Midfielder
                {
                    attackSkill += player.Skill; // Combine the skill levels of all players (Forwards and MidFielders)
                }
            }

            return attackSkill;
        }

        public int GetDefenseSkill() // Method for calculating the total defending power of the players
        {
            int defenseSkill = 0; // Variable to store the total defending power

            foreach (Player player in Players) // Iterates over all players
            {
                if  (player.Position == Position.Defender || player.Position == Position.Goalkeeper) // Checks if players position are Defender or Goalkeeper
                {
                    defenseSkill += player.Skill; // Combine the skill levels of all players (Defenders and Goalkeeper)
                }
            }

            return defenseSkill;
        }

    }
}
