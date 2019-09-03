using System;
using TreasureHunter.Interfaces;
using TreasureHunter.Models;

namespace TreasureHunter
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.Clear();
      App app = new App();
      app.Setup();
      app.Run();
    }
  }
}
