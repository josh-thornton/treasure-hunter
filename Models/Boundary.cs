using System.Collections.Generic;
using TreasureHunter.Interfaces;

namespace TreasureHunter.Models
{
  public class Boundary
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<IItem> Items { get; set; }
    public Dictionary<string, Boundary> NeighborBoundaries { get; set; }
    public Boundary(string name, string description)
    {
      Name = name;
      Description = description;
      Items = new List<IItem>();
      NeighborBoundaries = new Dictionary<string, Boundary>();
    }
  }
}