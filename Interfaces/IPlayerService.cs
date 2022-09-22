using Depth_Chart_Test.Models;

namespace Depth_Chart_Test.Interfaces;
internal interface IPlayerService
{
    void AddPlayerToDepthChart(string position, Player player, int? depth); //To add the player to the Depth Chart
    List<Player> RemovePlayerFromDepthChart(string position, Player player); //To remove the player from the Depth Chart
    List<Player> GetBackups(string position, Player player); //To get the backups of the player
    void GetFullDepthChart(); //To get the full Depth Chart
}
