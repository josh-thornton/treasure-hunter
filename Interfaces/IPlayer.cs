using System.Collections.Generic;

namespace TreasureHunter.Interfaces
{
  public interface IPlayer
  {
    List<IItem> Inventory { get; set; }
  }
}