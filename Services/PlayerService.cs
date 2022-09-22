using Depth_Chart_Test.Interfaces;
using Depth_Chart_Test.Models;

namespace Depth_Chart_Test.Services;
internal class PlayerService : IPlayerService
{
    private List<Player> _players; //Players object list

    public PlayerService()
    {
        _players = new List<Player>();
    }

    public void AddPlayerToDepthChart(string position, Player player, int? depth)
    {
        if (!depth.HasValue)  // When the Depth is not passed with any value
        {
            var maxDepth = _players.Where(x => x.Position == position).Max(x => x.Depth) + 1; //Have to take the max depth

            AddPlayerToList(player.Number, player.Name, position, maxDepth); //Adding the player at the end of the depth
        }
        else
        {
            var backupPlayers = _players.Where(x => x.Position == position && x.Depth >= depth.Value); //Getting all the backup player of the particular position and Depth

            foreach (var backupPlayer in backupPlayers)
            {
                backupPlayer.Depth += 1;  //Increasing the Depth of the backup players by 1. 
            }

            AddPlayerToList(player.Number, player.Name, position, depth.Value); //Adding the new player to the Depth Chart at particular position and depth. 
        }
    }

    private void AddPlayerToList(int number, string name, string position, int depth) //Generic method to add the players to the list. 
    {
        var newPlayer = new Player(number, name);
        newPlayer.Position = position;
        newPlayer.Depth = depth;
        _players.Add(newPlayer);
    }

    public List<Player> GetBackups(string position, Player player) 
    {
        var list = new List<Player>();

        var existingPlayer = _players.SingleOrDefault(x => x.Position == position && x.Number == player.Number && x.Name == player.Name); //To get the existing player at particular position, with number and name. 

        if (existingPlayer == null) return list; //Returning the empty list if no existing player is there. 

        var backupPlayers = _players.Where(x => x.Position == position && x.Depth > existingPlayer.Depth).ToList(); //Getting the backup players depends on the existing player depth. 

        if (backupPlayers == null) return list;

        list.AddRange(backupPlayers);
        return list;
    }

    public void GetFullDepthChart()
    {
        var positions = _players.GroupBy(x => x.Position) //Getting all the positions. 
            .Select(g => g.First().Position)
            .ToList();

        foreach (var position in positions)
        {
            var playersInThisPosition = _players.Where(x => x.Position == position).OrderBy(x => x.Depth).ToList(); //Getting all the players at the particular position. 

            var output = $"{position} - ";

            foreach (var player in playersInThisPosition)
            {
                output += $"(#{player.Number}, {player.Name}), ";
            }

            output = output.TrimEnd(' ').TrimEnd(','); //Removing the extra comma's at the end. 

            Console.WriteLine(output);
        }
    }

    public List<Player> RemovePlayerFromDepthChart(string position, Player player)
    {
        var list = new List<Player>();

        var playerToRemove = _players.SingleOrDefault(x => x.Position == position && x.Number == player.Number && x.Name == player.Name); //Getting the player details that to be removed. 

        if (playerToRemove == null) return list; //Is no player is to be removed then returning the empty list. 

        _players.Remove(playerToRemove); //Removing from the list. 

        list.Add(playerToRemove); //Adding the removed player details to list. 
        return list;
    }
}
