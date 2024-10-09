using System.ComponentModel.DataAnnotations;

namespace Football_Game_Console_Simulator
{
    public class Program
    {

        static void DisplayTeamInfo(Team team)
        {
            Console.WriteLine($"Team{team.Name}:");

            for (int i = 0; i < team.Players.Count; i++)
            {
                var player = team.Players[i];
                Console.WriteLine($"{i + 1}.{player.Name} - {player.Position} (Skill: {player.Skill})");
            }
            Console.WriteLine();
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

        }

    }

}
