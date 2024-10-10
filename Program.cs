using System.ComponentModel.DataAnnotations;

namespace Football_Game_Console_Simulator
{
    public class Program
    {

        static void DisplayTeamInfo(Team team) // (team) is a parameter for class (Team)
        {
            Console.WriteLine($"Team{team.Name}:"); // Displays Team's Name

            for (int i = 0; i < team.Players.Count; i++) // Iterates over each player on the team
            {
                var player = team.Players[i]; // Access players by using team.Players[i]
                Console.WriteLine($"{i + 1}.{player.Name} - {player.Position} (Skill: {player.Skill})"); // Displays players info (Name, Position and Skill level)
            }
            Console.WriteLine(); // Empty line
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Football Game Simulator Program");

            Console.WriteLine("Enter the name of Team 1 :");
            Team Team1 = new Team(Console.ReadLine()); // Asks the user to enter the name of the first team

            Console.WriteLine("Enter the name of Team 2 :");
            Team Team2 = new Team(Console.ReadLine()); // Asks the user to enter the name of the second team

            Team1.GeneratePlayers(); // Generates players automatically for Team 1
            Team2.GeneratePlayers(); // Generates players automatically for Team 2

            Console.WriteLine($"\nGenerating Players for both Teams... \n");

            DisplayTeamInfo(Team1); // Display all players Info of Team 1 (Names, Positions and Skill levels)
            DisplayTeamInfo(Team2); // Display all players Info of Team 2 (Names, Positions and Skill levels)


            Random random = new Random(); // Random class to generate random number

            bool WhoseAttacking = random.Next(2) == 0; // Choose between (true = 0) or (false = 1) randomly
            string StartingTeamName; // Variable to hold the name of the starting team

            if (WhoseAttacking)
            {
                StartingTeamName = Team1.Name; // WhoseAttacking = True (0)
            }
            else
            {
                StartingTeamName = Team2.Name; // WhoseAttacking = False (1)
            }

            Console.WriteLine($"\nCoin toss... {StartingTeamName} will start the game.\n");


            SimulatingMatch(Team1, Team2, WhoseAttacking);
        }

        static void SimulatingMatch(Team Team1, Team Team2, bool WhoseAttacking) // Simulate a match between Team1 and Team2, and determines which team will start by using (bool WhoseAttacking)
        {
            for (int half = 0; half < 2; half++) // Simulates two halves for the match
            {
                Console.WriteLine($"--- Half {(half + 1)} ---"); // Displays the current half of the match

                for (int turn = 1; turn < 5; turn++) // Iterates four times to represent four turns (2 Attacks and 2 Defenses)
                {
                    Team AttackingTeam; // Parameter to hold the Attacking Team
                    Team DefendingTeam; // Parameter to hold the Defending Team

                    if (WhoseAttacking) // The attacking and defending teams are determined based on the value of (WhoseAttacking boolean)
                    {
                        AttackingTeam = Team1;  // If the value of (WhoseAttacking is true), Team1 will attack
                        DefendingTeam = Team2;
                    }
                    else
                    {
                        AttackingTeam = Team2; // If the value of (WhoseAttacking is false), Team2 will attack
                        DefendingTeam = Team1;
                    }

                    int attackSkill = AttackingTeam.GetAttackSkill(); // Get the total power of the attacking team by calling GetAttackSkill() method
                    int defenseSkill = DefendingTeam.GetDefenseSkill(); // Get the total power of the defending team by calling GetDefenseSkill() method

                    if (attackSkill > defenseSkill) // Compare between the attack skill and the defense skill of the two teams
                    {
                        AttackingTeam.Score++; // If attack skill > the defense skill, increase score by 1
                        Console.WriteLine($"Turn {turn}: {AttackingTeam.Name} are attacking... Goal!");
                    }
                    else // If attack skill < the defense skill, keep the score value as it is
                    {
                        Console.WriteLine($"Turn {turn}: {AttackingTeam.Name} are attacking... Defended Successfully!");
                    }

                    Console.WriteLine($"Current Score: {Team1.Name}:{Team1.Score} | {Team2.Name}: {Team2.Score}");

                    WhoseAttacking = !WhoseAttacking; // Switch the attacking team to the next turn by toggling the WhoseAttacking boolean
                }
            }

        }

    }

}
