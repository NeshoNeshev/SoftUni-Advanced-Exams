using System;
using System.Linq;

namespace Guild
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Guild guild = new Guild("Weekend Raiders", 20);
            //Initialize entity
            Console.WriteLine(guild.RemovePlayer("sasas"));
            Player player = new Player("Mark", "Rogue");
            //Print player
           Console.WriteLine(player);//Player Mark: Rogue
                                       //Rank: Trial
                                       //Description: n/a

            //Add player
            guild.AddPlayer(player);
            Console.WriteLine(guild.Count); //1
            Console.WriteLine(guild.RemovePlayer("Gosho")); //False
            Console.WriteLine(guild.RemovePlayer("Gosho1"));
            Player firstPlayer = new Player("Pep", "Warrior");
            Player secondPlayer = new Player("Lizzy", "Priest");
            Player thirdPlayer = new Player("Mike", "Rogue");
            Player fourthPlayer = new Player("Marlin", "Mage");
            Player fourthPlayer1 = new Player("Lizzy", "Mage");
            //Add description to player
            secondPlayer.Description = "Best healer EU";

            //Add players
            guild.AddPlayer(firstPlayer);
            guild.AddPlayer(secondPlayer);
            guild.AddPlayer(thirdPlayer);
            guild.AddPlayer(fourthPlayer);
            guild.AddPlayer(fourthPlayer1);

            //Promote player
            guild.PromotePlayer("Lizzy");
            guild.DemotePlayer("Lizzy");
            //RemovePlayer
            Console.WriteLine(guild.RemovePlayer("Pep"));

            Player[] kickedPlayers = guild.KickPlayersByClass("Rogue");
            Console.WriteLine(string.Join(", ", kickedPlayers.Select(p => p.Name))); //Mark, Mike

            Console.WriteLine(guild.Report());

        }
    }
}
