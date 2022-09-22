using Depth_Chart_Test.Interfaces;
using Depth_Chart_Test.Models;
using Depth_Chart_Test.Services;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static IServiceProvider _serviceProvider;

    private static void Main(string[] args)                                                 //Main method
    {
        Task.Run(async () => new Program().ConfigureServices().Run()).Wait();
    }

    private Program ConfigureServices()                                                     //Configuring the service. 
    {
        var services = new ServiceCollection();
        services.AddSingleton<IPlayerService, PlayerService>();

        _serviceProvider = services.BuildServiceProvider();
        return this;
    }

    private void Run()
    {
        var playerService = _serviceProvider.GetService<IPlayerService>();

        var tomBrady = new Player(12, "Tom Brady");                                         //Declaring all the players with their number and name. 
        var blaineGabbert = new Player(11, "Blaine Gabbert");
        var kyleTrask = new Player(2, "Kyle Trask");
        var mikeEvans = new Player(13, "Mike Evans");
        var jaelonDarden = new Player(1, "Jaelon Darden");
        var scottMiller = new Player(10, "Scott Miller");

        playerService.AddPlayerToDepthChart("QB", tomBrady, 0);                             //Adding the players to the Depth Chart with the Position, name and Depth. 
        playerService.AddPlayerToDepthChart("QB", blaineGabbert, 1);
        playerService.AddPlayerToDepthChart("QB", kyleTrask, 2);

        playerService.AddPlayerToDepthChart("LWR", mikeEvans, 0);
        playerService.AddPlayerToDepthChart("LWR", jaelonDarden, 1);
        playerService.AddPlayerToDepthChart("LWR", scottMiller, 2);

        var backupPlayers = playerService.GetBackups("QB", tomBrady);                       //Getting the backup players of Tom Brady.
        PrintBackupPlayers(backupPlayers);

        backupPlayers = playerService.GetBackups("LWR", jaelonDarden);                      //Getting the backup players of Jaelon Darden.
        PrintBackupPlayers(backupPlayers);

        backupPlayers = playerService.GetBackups("QB", mikeEvans);                          //Getting the backup players of Mike Evans.
        PrintBackupPlayers(backupPlayers);

        backupPlayers = playerService.GetBackups("QB", blaineGabbert);                      //Getting the backup players of Blaine Gabbert.
        PrintBackupPlayers(backupPlayers);

        backupPlayers = playerService.GetBackups("QB", kyleTrask);                          //Getting the backup players of Kyle Trask.
        PrintBackupPlayers(backupPlayers);

        playerService.GetFullDepthChart();                                                  //Getting the Full Depth Chart

        var removedPlayers = playerService.RemovePlayerFromDepthChart("LWR", mikeEvans);    //Removing the player from the Depth CHart
        if (removedPlayers.Any())
        {
            Console.WriteLine($"#{removedPlayers.First().Number} - {removedPlayers.First().Name}");
        }

        playerService.GetFullDepthChart();                                                  //Getting the Full Depth Chart


        Console.WriteLine("Press any key");
        Console.ReadKey();
    }

    private static void PrintBackupPlayers(List<Player> backupPlayers)
    {
        if (!backupPlayers.Any())                                                           //If there is no Back up player in the chart then printing the empty list. 
        {
            Console.WriteLine("<NO LIST>");
        }
        else
        {
            foreach (var backupPlayer in backupPlayers)                                     // Printing the backup players.
            {
                Console.WriteLine($"#{backupPlayer.Number} - {backupPlayer.Name}");
            }
        }
    }
}