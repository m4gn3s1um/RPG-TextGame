using RPG_TextGame.Interface;
using RPG_TextGame.PlayerInformation;

namespace RPG_TextGame.Functionality;

public class CombatHandler
{

    public void Fight(IEnemy enemy, Player player)
    {
        Console.WriteLine("\nA battle has been initiated.\n");
        
        string userInput = Console.ReadLine();

        CheckRarity cr = new CheckRarity();
        ItemDrop iDrop = new ItemDrop();
        
        
        
        
        
        

        int enemyHealth = enemy.getHealth();

        switch (userInput)
        {
            case "y":
                while (enemyHealth > 0 && player.playerHealth > 0)
                {
            
                    Console.WriteLine($"It's your turn to strike. You deal {player.GetPlayerDamage()} damage.");
            
                    enemyHealth = enemyHealth - player.GetPlayerDamage();
            
                    if (enemyHealth <= 0)
                    {
                        Console.WriteLine($"{cr.HandleEnemyRarity(enemy)} falls over.");
                        break;
                    }
                    Console.WriteLine($"{cr.HandleEnemyRarity(enemy)} has {enemyHealth} health left. His turn to strike has come. He deals {enemy.getDamage()} damage.");


                    player.playerHealth = player.playerHealth - enemy.getDamage();

                    if (player.playerHealth <= 0)
                    {
                        Console.WriteLine($"{player.playerName} falls over.");
                        break;
                    }

                    Console.WriteLine($"You have {player.playerHealth} health left.");
            
                }
        
                if (player.playerHealth <= 0)
                {
                    Console.WriteLine($"{player.playerName} has been slain by {cr.HandleEnemyRarity(enemy)}. Better luck next time.");
                }
        
                if (enemyHealth <= 0)
                {
                    Console.WriteLine($"{player.playerName} has slain {cr.HandleEnemyRarity(enemy)}. Good job.");
                    iDrop.DropItem(player);
                    player.LevelUp();
                }
                break;
            
            case "n":
                Console.WriteLine("You denied the fight. You can hear laughing coming from the heaven. The Gods are laughing at your cowardice.");
                break;
            default:
                Console.WriteLine("Invalid key...");
                break;
        }
    }
}