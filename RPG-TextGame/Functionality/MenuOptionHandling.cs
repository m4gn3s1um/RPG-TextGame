using RPG_TextGame.Enemy;
using RPG_TextGame.Enemy.CommonEnemy;
using RPG_TextGame.Interface;
using RPG_TextGame.PlayerInformation;
using RPG_TextGame.Tool.Edible;
using RPG_TextGame.Tool.Weapon;
using RPG_TextGame.World;

namespace RPG_TextGame.Functionality;

public class MenuOptionHandling
{

    bool going = true;
    
    TextPromt tp = new TextPromt();
    
    Sword s = new Sword();
    
    public void OptionHandle()
    {
        
        tp.startPrompt();
        
        Player p1 = new Player(Console.ReadLine());
        
        tp.playerWelcomeMessage(p1);
        p1.Equip(s);
        
        
        while (going == true && p1.playerHealth != 0)
        {
            string userInput = Console.ReadLine();
            
            HandleMainMenuChoice(userInput, p1);
        }
    }
    
    public void HandleMainMenuChoice(string? option, Player p)
    {
        switch (option)
        {
            case "m":
                MovePlayer(p);
                break;
            case "i":
                SeeInventory(p);
                break;
            case "p":
                SeeStats(p);
                break;
            case "b":
                MovePlayerBack(p);
                break;
            case "q":
                Exit();
                break;
            default:
                Console.WriteLine("Press a valid button");
                break;
        }
    }
    
    
    public void MovePlayer(Player p)
    {
        switch (p.wl)
        {
            case WorldLocation.START:
                p.wl = WorldLocation.ROAD;
                Console.WriteLine($"You have moved to {p.wl}");
                SpawnEnemies(p);
                break;
            case WorldLocation.ROAD:
                p.wl = WorldLocation.CITY;
                Console.WriteLine($"You have moved to {p.wl}");
                break;
            case WorldLocation.CITY:
                p.wl = WorldLocation.CAVE;
                Console.WriteLine($"You have moved to {p.wl}");
                break;
            default:
                Console.WriteLine("You are at the end of the road");
                break;
        }
    }
    
    public void MovePlayerBack(Player p)
    {
        switch (p.wl)
        {
            case WorldLocation.START:
                Console.WriteLine("You cannot move back any further.");
                break;
            case WorldLocation.ROAD:
                p.wl = WorldLocation.START;
                Console.WriteLine($"You have moved to {p.wl}");
                break;
            case WorldLocation.CITY:
                p.wl = WorldLocation.ROAD;
                Console.WriteLine($"You have moved to {p.wl}");
                break;
            case WorldLocation.CAVE:
                p.wl = WorldLocation.CITY;
                Console.WriteLine($"You have moved to {p.wl}");
                break;
        }
    }
    
    
    public void SeeInventory(Player p)
    {
        InventoryHandler ih = new InventoryHandler();
        
        ih.CheckInventory(p);
    }
    
    public void SeeStats(Player p)
    {
        Console.WriteLine($"\n{p.playerName}: Has {p.playerHealth} health, lvl: {p.playerLevel} and is currently at {p.wl}");
        
    }
    
    public void KeepGoing()
    {
        Console.WriteLine("\nPress a key to make a move");
        Console.ReadKey();
    }

    public void SpawnEnemies(Player p)
    {
        EnemySpawns es = new EnemySpawns();
        
        es.SpawnEnemies(p);
    }
    
    public void Exit()
    {
        Console.WriteLine("See you on the other side, traveller.");
        going = false;
    }
}