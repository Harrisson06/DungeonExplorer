using System;
using System.Media;
using System.Security.Authentication;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private readonly Room currentRoom;

        public Game()
        {

        }
        //Creating a function to start the game.
        public void Start()

        {
            //Welcome message to the user.
            Console.WriteLine("Welcome to Dungeon Explorer!" + "\n");

            //Getting user information.
            Console.Write("Enter your name: ");
            string Name = Console.ReadLine();

            //Initiates the while loop to keep the game running.
            bool playing = true;
            while (playing)
            {

                player = new Player(Name, 50);

                //Creating a new room object and displaying the description of the room.
                Room Basement = new Room("You awaken, hurt and confused in a cold dark room. A basement perhaps? lights come from the top of a stairwell");
                string BasementDescription = Basement.GetDescription();
                Console.WriteLine(BasementDescription);
                PlayerStats();

                Console.WriteLine("In the basement, you see a Potion on the ground, It could heal you. Do you want to pick it up? (yes/no)");
                string response = Console.ReadLine();
                response.ToLower();
                //Using Switch case to check if the user wants to pick up the potion or not. 
                switch (response)
                {
                    case "yes":
                        player.PickUpItem("HealthPotion");
                        Console.WriteLine("You picked up the HealthPotion, do you want to use it?" + "\n");
                        PlayerStats();
                        Console.WriteLine("Inventory: " + player.InventoryContents() + "\n");
                        break;
                    case "no":
                        Console.WriteLine("You did not pick up the potion" + "\n");
                        PlayerStats();
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again");
                        break;
                }

                //Using switch case to check if the user wants to use the potion or not.
                //If the user uses the potion, their health will increase by 50 and they lose the potion. 
                //if the user does not use the potion it remains in their inventory.
                string answer = Console.ReadLine();
                answer.ToLower();
                switch (answer)
                {
                    case "yes":
                        player.Health += 50;
                        Console.WriteLine("You used the potion, your health has been increased" + "\n");
                        PlayerStats();
                        player.RemoveItem("HealthPotion");

                        Console.WriteLine(player.InventoryContents());
                        break;
                    case "no":
                        Console.WriteLine("You didint use the potion" + "\n");
                        PlayerStats();
                        Console.WriteLine(player.InventoryContents());
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again");
                        break;
                }
            }
                //Allows the user to exit the game at the end of the loop.
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            {
                playing = false;
            }
        }
     
        //Creating a function to display the stats of the player.
        private void PlayerStats()
        {
            Console.WriteLine("USER STATS" + "\n" + "Name: " + player.Name + "\n" + "Health:" + player.Health + "\n");
        }
     }
}