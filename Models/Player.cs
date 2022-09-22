namespace Depth_Chart_Test.Models;

internal class Player
{
    public Player(int number, string name) //Constructor
    {
        Number = number;
        Name = name;
    }

    public int Number { get; }  //Player Number
    public string? Name { get; } //Player name
    public string? Position { get; set; } //Player Position
    public int Depth { get; set; } //Player Depth
}
