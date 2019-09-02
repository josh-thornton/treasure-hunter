﻿using System;
using TreasureHunter.Models;
using TreasureHunter.Interfaces;

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
