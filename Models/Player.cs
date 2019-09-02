using System.Collections.Generic;
using TreasureHunter.Interfaces;

namespace TreasureHunter.Models
{
  public class Player : IPlayer
  {
    public List<IItem> Inventory { get; set; }
    public Player()
    {
      Inventory = new List<IItem>();
    }
  }
}