using System.Collections.Generic;

namespace TreasureHunter.Interfaces
{
  public interface IPlayer
  {
    string Name { get; set; }
    List<IItem> Inventory { get; set; }
  }
}