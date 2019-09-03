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
    public string ReqItem { get; set; }
    public string CurrentLocation { get; set; }
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
      Boundary RecRoom = new Boundary("recroom", "The entire bow of the Rocker is dedicated to keeping the minds of the crew engaged during long space voyages -- a huge window wraps around the Space Lounge at the front, providing a panoramic view of the world outside and comfortable Space Seating to enjoy it. An island Space Bar stands in the middle of the room, ringed with Space Viewing Screens. The port side of the room features several Space Pool Tables and other games, like Space Shuffleboard and Space Darts. The starbord side is taken up nearly completely by the Space Bumper Cars and virtual reality rooms.\n\nHumankind learned early on in our spacefaring days that a Good Time is the only way to avoid the Space Madness, and ever since even the most militant-minded vessel hasn't skimped on ways to provide the crew with one. As you have recently learned, not all of the horrors of the void can simply be washed away with Space Alcohol and virtual reality, however.\n\nThe rec room is nearly untouched; if it weren't for a few more broken bottles than normal, an obvserver who hasn't seen what you have would assume all is well. Perhaps the crew, even in the throes of their madness, remember this as being an area to enjoy.", "balls");
      Boundary Bridge = new Boundary("bridge", "The Space Bridge of the Rocker is in complete dissaray. It would be safe to assume that this is where whatever ailed these spacefarers took root here.\n\nSeveral bodies are strewn throughout the area. Light from the broken holodeck in the middle of the bridge intermittently lances out, coating the area in a ghoulish green. You spot the glint of a Keycard dangling off of the Space Captain's body during one of these bursts.", "balls");
      Boundary Hangar = new Boundary("hangar", "It doesn't take long to realize that the only ship in working order on the Rocker's bridge is the one you flew in on. It appears that one or two may be missing, and several others are heavily damaged and most show evidence of fire damage.\n\nOne, however, seems to be unburned and salvageable.", "balls");
      Boundary Communications = new Boundary("comms", "Interstellar communication isn't easy. Modern spacecraft must devote a sizeable amount of attention to ensuring that messages are recieved quickly and efficiently. The Space Comms crew is also responsible for making sure the crew has new VR diversions on a weekly basis as well as helping them to keep up-to-date on their favorite Space RomComs and Space Sports.\n\nThe room is nearly completely dark; lit only by the blue glow of Space Computer Screens. It does not appear that anything of note can be found here.", "balls");
      Boundary Labs = new Boundary("labs", "Being a science vessel at its core, the Rocker has an extensive Space Laboratory. You aren't sure what most of the things in here are for -- that's far above your paygrade -- but you know it all looks awfully expensive and probably has to do with Space.\n\nThere must be some sort of high-powered Laser in here, as you aren't sure what else could cause the linear scorch marks you see across some of the Space walls.", "keycard");
      Boundary Armory = new Boundary("armory", "The Space Airlock to the leading to the Armory is ringed with red; it looks like there has been heavy damage within. Luckily, your Space Suit is in good condition.\n\nUpon entering, it's apparent that a large Space Explosion ripped through the area; anything that was not strapped down (spoilers: That's everything) was whisked out into space through a large gash down the port side of the vessel. Turns out, you're not strapped down either. You quickly lose your footing and are whisked off into the void.", "balls");
      Boundary Maintenance = new Boundary("maintenance", "The rigors of interstellar travel can take their toll, and without a solid corps of Space Engineers such as yourself to keep entropy at bay ships cannot travel far.\n\nEverything you will need to get the Voice back up and running should be in this room. It would be wise to search for some Tools.", "balls");
      Boundary Galley = new Boundary("galley", "Even a Space Man gotta eat, but not what you can find here -- the remaining Space Food hasn't kept well, to say the least.", "balls");
      Boundary EngineRoom = new Boundary("engine", "An interstellar spacecraft requires two different sorts of Space Engines, and although you quickly ascertain that both are currently inoperable, you're only worried about the Hyperspace Space Engine.\n\nIt's definitely fucked up.", "tools");
      Boundary Dormitories = new Boundary("dormitories", "Well, you knew it had to happen eventually. Upon entering the dorms, you find the last remaining member of the Rocker's crew. He's a pretty surly fella, though, and doesn't take kindly to your presence.", "laser");

      Item Laser = new Item("laser", "There's a trigger, which you've found. So we are good to go here.");
      Item Keycard = new Item("keycard", "A keycard for the labs, through which you can access much of the ship.");
      Item Tools = new Item("tools", "This should be everything an experienced Space Engineer such as yourself needs.");
      Item Balls = new Item("balls", "You need a sturdy set of these to be a Space Scavenger.");

      RecRoom.AddNeighborBoundary(Bridge, true);
      RecRoom.AddNeighborBoundary(Hangar, true);
      Bridge.AddNeighborBoundary(Hangar, true);
      Hangar.AddNeighborBoundary(Labs, true);
      Labs.AddNeighborBoundary(Dormitories, true);
      Labs.AddNeighborBoundary(Armory, true);
      Labs.AddNeighborBoundary(Communications, true);
      Labs.AddNeighborBoundary(Maintenance, true);
      Labs.AddNeighborBoundary(Galley, true);
      Dormitories.AddNeighborBoundary(Armory, true);
      Maintenance.AddNeighborBoundary(Galley, true);
      Maintenance.AddNeighborBoundary(EngineRoom, true);

      Inventory = new List<IItem>();

      Labs.Items.Add(Laser);
      Bridge.Items.Add(Keycard);
      Maintenance.Items.Add(Tools);

      Player = new Player("");
      Player.Inventory.Add(Balls);
      Location = Hangar;
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
          ChangeLocation(option.ToLower());
          break;
        case "search":
          TakeItem(option.ToLower());
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
      if (Exploring == true)
      {
        Console.Clear();
        Console.WriteLine($"{Location.Description}");
        Console.WriteLine($"From the {Location.Name}, you can reach:");
        foreach (KeyValuePair<string, IBoundary> kvp in Location.NeighborBoundaries)
        {
          Console.WriteLine(kvp.Key);
        }
      }
    }
    public void ReqItemCheck()
    {

    }
    public void ChangeLocation(string locationName)
    {
      if (Location.NeighborBoundaries.ContainsKey(locationName))
      {
        var location = Location.NeighborBoundaries[locationName];
        if (Player.Inventory.Any(i => i.Name.ToLowerInvariant() == location.ReqItem.ToLowerInvariant()))
        {
          Location = Location.NeighborBoundaries[locationName];
          if (Location.Name == "armory")
          {
            Console.WriteLine("The Space Airlock to the leading to the Armory is ringed with red; it looks like there has been heavy damage within. Luckily, your Space Suit is in good condition.\n\nUpon entering, it's apparent that a large Space Explosion ripped through the area; anything that was not strapped down (spoilers: That's everything) was whisked out into space through a large gash down the port side of the vessel. Turns out, you're not strapped down either. You quickly lose your footing and are taken off into the void, never to be seen again.");
            Console.WriteLine("GAME OVER");
            Exploring = false;
          }
          if (Location.Name == "engine")
          {
            Console.WriteLine("An interstellar spacecraft requires two different sorts of Space Engines, and although you quickly ascertain that both are currently inoperable, you're only worried about the Hyperspace Space Engine.");
            Console.WriteLine("You do what you were trained to do, and the Space Rocker is (barely) operable again. Time to get home!");
            Console.WriteLine("Congrats! You win.");
            Exploring = false;
          }
          DisplayRoomDescription();
        }
        else
        {
          Console.WriteLine("It looks like you're missing an item.");
        }
      }
      else
      {
        Console.WriteLine("Invalid room choice.");
      }
    }

    public void DisplayPlayerInventory()
    {
      Console.WriteLine("You are currently holding:");
      foreach (var item in Player.Inventory)
      {
        Console.WriteLine($"{item.Name}\n     {item.Description}");
      }
      Console.WriteLine("Press any key to continue.");
      Console.ReadLine();
    }
    public void TakeItem(string itemName)
    {
      IItem item = Location.Items.Find(c => c.Name.ToLower() == itemName);
      if (item is null)
      {
        Console.WriteLine("Try searching somewhere else.");
        return;
      }
      if (Location.Items.Contains(item))
      {
        Player.Inventory.Add(item);
        Console.WriteLine($"While scrounging about, you found the {item.Name}. You quickly stuff it in your pack.");
        Location.Items.Remove(item);
      }
    }
  }
}