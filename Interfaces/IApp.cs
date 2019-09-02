namespace TreasureHunter.Interfaces
{
  public interface IApp
  {
    IPlayer Player { get; set; }
    IBoundary Location { get; set; }
    bool Exploring { get; set; }

    void Greeting();
    void Setup();
    void Run();
    void CaptureUserInput();
    void DisplayRoomDescription();
    void ChangeLocation(string locationName);
    void TakeItem(string itemName);
    void DisplayPlayerInventory();
    void DisplayHelpInfo();

    //NOTE [STRETCH GOALS] - Basic requirements first and then extend your application.
    // void UseItem(string itemName); //NOTE [STRETCH GOAL] - to use an item you must check that your player has the target item in their Inventory and then if so modify the value of a property on the Location. You may keep or remove the item from the player's inventory according to what makes the most sense with your story.
  }
}