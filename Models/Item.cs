
using TreasureHunter.Interfaces;

namespace TreasureHunter.Models
{
  public class Item : IItem
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public Item(string name, string description)
    {
      Name = name;
      Description = description;
    }
  }
}