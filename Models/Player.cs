using System.Collections.Generic;
using TreasureHunter.Interfaces;

namespace TreasureHunter.Models
{
  public class Player
  {
    public string Name { get; set; }
    public List<IItem> Inventory { get; set; }
    public Player(string name)
    {
      Name = name;
      Inventory = new List<IItem>();
    }
  }
}