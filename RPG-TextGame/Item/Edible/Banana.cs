using RPG_TextGame.Interface;
using RPG_TextGame.PlayerInformation;

namespace RPG_TextGame.Tool.Edible;

public class Banana : ITool
{
    public String Name = "Banana";
    
    public int HealthAdd = 35;
    
    public void Act(Player player)
    {
        player.playerHealth = player.playerHealth + HealthAdd;
    }

    public string GetName()
    {
        return Name;
    }
}