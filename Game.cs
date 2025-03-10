using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private  Player player;
        private readonly Room currentRoom;

        public Game()
        { 
        }
        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                Console.WriteLine("Welcome to Dungeon Explorer!" + "\n");


                //Collecting users input for their name and creating a new player object.
                Console.Write("Enter your name: ");
                string Name = Console.ReadLine();
                player = new Player(Name, 50);

                //Creating a new room object and displaying the description of the room.
                Room Basement = new Room("You awaken, hurt and confused in a cold dark room. A basement perhaps? lights come from the top of a stairwell");
                string BasementDescription = Basement.GetDescription();
                Console.WriteLine(BasementDescription);
                PlayerStats();

                Console.WriteLine("In the basement, you see a Potion on the ground, It could heal you. Do you want to pick it up? (yes/no)");
                string response = Console.ReadLine();
                response.ToLower();
                //If statement to check if the user picks up the potion or not.
                if (response == "yes")
                {
                    player.PickUpItem("HealthPotion");
                    Console.WriteLine("Inventory: " + "\n" + player.InventoryContents() + "\n");

                    Console.WriteLine("You picked up the HealthPotion, do you want to use it?" + "\n");
                    string answer = Console.ReadLine();
                    answer.ToLower();
                    if (answer == "yes")
                    {
                        player.Health += 50;
                        Console.WriteLine("You used the potion, your health is now " + player.Health + "\n");
                    }
                    else
                    {
                        Console.WriteLine("You didint use the potion" + "\n");
                    }
                }

                else
                {
                    Console.WriteLine("You left the potion on the ground." + "\n");
                }

                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                    {
                        playing = false;
                    }
                }
            } 
        //Creating a function to display the stats of the player.
        private void PlayerStats()
        {
            Console.WriteLine("USER STATS" + "\n" + "Name: " + player.Name + "\n" + "Health:" + player.Health + "\n");
        }
     }
}