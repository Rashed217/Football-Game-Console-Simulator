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

        }

    }

}
