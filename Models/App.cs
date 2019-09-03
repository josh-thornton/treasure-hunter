using System;
using System.Collections.Generic;
using System.Linq;
using TreasureHunter.Interfaces;

namespace TreasureHunter.Models
{
  public class App : IApp
  {
    public IPlayer Player { get; set; }
    public IBoundary Location { get; set; }
    public List<IItem> Inventory { get; set; }
    public bool Exploring { get; set; }

    public void Greeting()
    {
      Console.WriteLine("The year is 20XX.\n\nA Space Vessel known as the Space Rocker, long thought vanished, has suddenly reappeared in Titan's orbit. You were once a Space Engineer for the Royal Space Army, but grew disillusioned with their constant drive to conquer all of space, because it turns out space is empty so it's pretty boring out there.\n\nAnyway, after leaving the Space Army you found your calling as a Space Scavenger. And buddy, you got a whole-ass Spaceship to scavenge.\n\nAs you approach the Rocker, it's quite apparent that the Space Engines aren't in order. Luckily, the hangar Space Bay is open, which makes landing inside quite easy. If you want to scavenge a whole-ass Spaceship, you had better get those Space Engines working!");
      Console.WriteLine("Being the goofball you are, you normally choose a new name at the start of every salvage operation. At this point, you're not sure who the real you is. What'll it be this time?");
      string name = Console.ReadLine();
      Player.Name = name;
      Console.WriteLine($"{Player.Name}, huh? Not your finest work, but it will do. Take a look around the hangar you find yourself in.");
    }


    public void Setup()
    {
      Boundary recRoom = new Boundary("RecRoom", "The entire bow of the Rocker is dedicated to keeping the minds of the crew engaged during long space voyages -- a huge window wraps around the Space Lounge at the front, providing a panoramic view of the world outside and comfortable Space Seating to enjoy it. An island Space Bar stands in the middle of the room, ringed with Space Viewing Screens. The port side of the room features several Space Pool Tables and other games, like Space Shuffleboard and Space Darts. The starbord side is taken up nearly completely by the Space Bumper Cars and virtual reality rooms.\n\nHumankind learned early on in our spacefaring days that a Good Time is the only way to avoid the Space Madness, and ever since even the most militant-minded vessel hasn't skimped on ways to provide the crew with one. As you have recently learned, not all of the horrors of the void can simply be washed away with Space Alcohol and virtual reality, however.\n\nThe rec room is nearly untouched; if it weren't for a few more broken bottles than normal, an obvserver who hasn't seen what you have would assume all is well. Perhaps the crew, even in the throes of their madness, remember this as being an area to enjoy.");
      Boundary bridge = new Boundary("Bridge", "The Space Bridge of the Rocker is in complete dissaray. It would be safe to assume that this is where whatever ailed these spacefarers took root here.\n\nSeveral bodies are strewn throughout the area. Light from the broken holodeck in the middle of the bridge intermittently lances out, coating the area in a ghoulish green. You spot the glint of a Keycard dangling off of the Space Captain's body during one of these bursts.");
      Boundary hangar = new Boundary("Hangar", "It doesn't take long to realize that the only ship in working order on the Rocker's bridge is the one you flew in on. It appears that one or two may be missing, and several others are heavily damaged and most show evidence of fire damage.\n\nOne, however, seems to be unburned and salvageable.");
      Boundary comms = new Boundary("Communications", "Interstellar communication isn't easy. Modern spacecraft must devote a sizeable amount of attention to ensuring that messages are recieved quickly and efficiently. The Space Comms crew is also responsible for making sure the crew has new VR diversions on a weekly basis as well as helping them to keep up-to-date on their favorite Space RomComs and Space Sports.\n\nThe room is nearly completely dark; lit only by the blue glow of Space Computer Screens. It does not appear that anything of note can be found here.");
      Boundary labs = new Boundary("Labs", "Being a science vessel at its core, the Rocker has an extensive Space Laboratory. You aren't sure what most of the things in here are for -- that's far above your paygrade -- but you know it all looks awfully expensive and probably has to do with Space.\n\nThere must be some sort of high-powered Laser in here, as you aren't sure what else could cause the linear scorch marks you see across some of the Space walls.");
      Boundary armory = new Boundary("Armory", "The Space Airlock to the leading to the Armory is ringed with red; it looks like there has been heavy damage within. Luckily, your Space Suit is in good condition.\n\nUpon entering, it's apparent that a large Space Explosion ripped through the area; anything that was not strapped down (spoilers: That's everything) was whisked out into space through a large gash down the port side of the vessel.");
      Boundary maintenance = new Boundary("Maintenance", "The rigors of interstellar travel can take their toll, and without a solid corps of Space Engineers such as yourself to keep entropy at bay ships cannot travel far.\n\nEverything you will need to get the Voice back up and running should be in this room. It would be wise to search for some Tools.");
      Boundary galley = new Boundary("Galley", "Even a Space Man gotta eat, but not what you can find here -- the remaining Space Food hasn't kept well, to say the least.\n\nWhile here, you can Go to the Labs or to Maintenance.");
      Boundary engine = new Boundary("Engine", "An interstellar spacecraft requires two different sorts of Space Engines, and although you quickly ascertain that both are currently inoperable, you're only worried about the Hyperspace Space Engine.\n\nIt's definitely fucked up.");
      Boundary dormitories = new Boundary("Dormitories", "Well, you knew it had to happen eventually. Upon entering the dorms, you find the last remaining member of the Rocker's crew. He's a pretty surly fella, though, and doesn't take kindly to your presence.");

      Item laser = new Item("Space Laser", "There's a trigger, which you've found. So we are good to go here.");
      Item keycard = new Item("Space Laboratory Keycard", "A keycard for the labs, through which you can access much of the ship.");
      Item tools = new Item("Space Tools", "This should be everything an experienced Space Engineer such as yourself needs.");

      recRoom.AddNeighborBoundary(bridge, true);
      recRoom.AddNeighborBoundary(hangar, true);
      bridge.AddNeighborBoundary(hangar, true);
      hangar.AddNeighborBoundary(labs, true);
      labs.AddNeighborBoundary(dormitories, true);
      labs.AddNeighborBoundary(armory, true);
      labs.AddNeighborBoundary(comms, true);
      labs.AddNeighborBoundary(maintenance, true);
      labs.AddNeighborBoundary(galley, true);
      dormitories.AddNeighborBoundary(armory, true);
      maintenance.AddNeighborBoundary(galley, true);
      maintenance.AddNeighborBoundary(engine, true);

      labs.Items.Add(laser);
      bridge.Items.Add(keycard);
      maintenance.Items.Add(tools);

      Player = new Player("");
      Player.Inventory.Clear();
      Location = hangar;
      Exploring = true;
    }
    public void Run()
    {
      Greeting();
      while (Exploring)
      {
        CaptureUserInput();
      }
    }
    public void CaptureUserInput()
    {
      Console.WriteLine("What would you like to do? Type 'help' to see options.");
      string userInput = Console.ReadLine().ToLower();
      string[] words = userInput.Split(' ');
      string command = words[0];
      string option = "";
      if (words.Length > 1)
      {
        option = words[1];
      }
      switch (command)
      {
        case "inventory":
          DisplayPlayerInventory();
          break;
        case "look":
          DisplayRoomDescription();
          break;
        case "help":
          DisplayHelpInfo();
          break;
        case "enter":
          ChangeLocation(option);
          break;
        case "search":
          TakeItem(option);
          break;
        case "quit":
          Exploring = false;
          break;
        default:
          Console.WriteLine("Invalid entry");
          break;
      }
    }
    public void DisplayHelpInfo()
    {
      Console.Clear();
      Console.WriteLine("While onboard the Space Rocker, you have a few different options:\n\nType 'look' to examine your surroundings and see where you can go next.\n\nType 'Search (object)' to rummage about and see what items you can find.\n\nType 'Enter (room)' to change locations.\n\nType 'inventory' to see what you're holding.\n\nType 'quit' to abandon your journey.\n\nPress any key to continue.");
      Console.ReadLine();
    }
    public void DisplayRoomDescription()
    {
      Console.Clear();
      Console.WriteLine($"{Location.Description}");
      Console.WriteLine($"From the {Location.Name}, you can reach:");
      foreach (KeyValuePair<string, IBoundary> kvp in Location.NeighborBoundaries)
      {
        Console.WriteLine(kvp.Key);
      }
    }
    public void ChangeLocation(string locationName)
    {
      if (Location.NeighborBoundaries.ContainsKey(locationName))
      {
        Location = Location.NeighborBoundaries[locationName];
        DisplayRoomDescription();
      }
      else
      {
        Console.WriteLine("Invalid room choice.");
      }
    }
    public void DisplayPlayerInventory()
    {
      Console.WriteLine("You are currently holding:");
      foreach (var item in Inventory)
      {
        Console.WriteLine($"{item.Name}\n     {item.Description}");
      }
      Console.WriteLine("Press any key to continue.");
      Console.ReadLine();
    }
    public void TakeItem(string itemName)
    {
      // if (CurrentBoundary.Items.Contains(itemName))
      {
        //  Inventory.Add(itemName);
      }
    }
  }
}