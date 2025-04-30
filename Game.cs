using System;
using System.Diagnostics;
using System.Media;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace DungeonExplorer
{
    internal class Game
    {
        public Room currentRoom;
        public Room FinalRoom;

        public Game()
        {

        }

        // Function to handle the direction the user would like to go.
        // This is to reduce the amount of switch statements in the main function.
        public void Direction()
        {
            while (true)
            {
                Console.WriteLine("Which direction would you like to go?\n"
                 + "[UP | DOWN | LEFT | RIGHT | BACK]");
                string Keyinput = Console.ReadLine();
                Keyinput.ToLower();
                if (Keyinput == "up" && currentRoom.UpRoom != null)
                {
                    currentRoom = currentRoom.UpRoom;
                    Console.WriteLine("\nYou have gone up the stairs.");
                    break;
                }

                else if (Keyinput == "down" && currentRoom.DownRoom != null)
                {
                    currentRoom = currentRoom.DownRoom;
                    Console.WriteLine("\nYou have gone down the stairs.");
                    break;
                }
                else if (Keyinput == "back" && currentRoom.BackRoom != null)
                {
                    currentRoom = currentRoom.BackRoom;
                    Console.WriteLine("\nYou have gone back into the previous room.");
                    break;
                }

                else if (Keyinput == "left" && currentRoom.LeftRoom != null)
                {
                    currentRoom = currentRoom.LeftRoom;
                    Console.WriteLine($"\nYou have gone into the left room.");
                    break;
                }

                else if (Keyinput == "right" && currentRoom.RightRoom != null)
                {
                    currentRoom = currentRoom.RightRoom;
                    Console.WriteLine("\nYou have gone into the right room.");
                    break;
                }
                // Error handling for erroneous input
                else
                    Console.WriteLine("There is no room that way.\n");
            }
        }


        // Function to handle the picking up of items in each room
        // Reducing the amount of switch statements in the main function.
        public void PickItem()
        {
            while (true)
            {
                if (currentRoom.Items.Count > 0)
                {
                    // Giving the user the option to pick up the item in the room.
                    Console.WriteLine("Do you want to pick up the item?\n", "[ yes | no ]");
                    string PickItemUp = Console.ReadLine();

                    // Converting the String to lowercase so that the input isnt case sensitive.
                    PickItemUp.ToLower();

                    // If the user wants to pick up the item, it will be added to the inventory.
                    if (PickItemUp == "yes")
                    {
                        while (currentRoom.Items.Count > 0)
                        {
                            Console.WriteLine($"You have picked up the item: " + currentRoom.Items[0].Name);
                            Player.User.inventory.PickUpItem(currentRoom.Items[0]);
                            Console.WriteLine($"\nYour inventory now contains: " + Player.User.inventory.InventoryContents() + "\n");
                            currentRoom.Items.RemoveAt(0);
                            
                        }
                        break;
                    }
                    // If the user doesnt want to pick it up nothing happens and they leave it.
                    else if (PickItemUp == "no")
                    {
                        Console.WriteLine("You have chosen not to pick up the item.\n");
                        break;
                    }
                    // Error handling for erroneous input
                    else
                    {
                        Console.WriteLine("Invalid input, Please try again.\n");
                    }
                }
                // Handles any other erroneous input
                else
                {
                    break;
                }
            }

        }
        // Method for controlling all Monster combat in the game.
        // Contains the combat loop for the player and monster.
        // Player attacks first for simplicity.
        public void MonsterCombat()
        { 
            if (currentRoom.Monster != null)
            {
                Console.WriteLine($"A {currentRoom.Monster.GetName()} has appeared!");
                while (currentRoom.Monster.Health > 0)
                {
                    Player.User.PlayerAttack(currentRoom.Monster);
                    currentRoom.Monster.MonsterAttack();
                    Console.WriteLine($"You have {Player.User.Health} health left.");
                    if (Player.User.Health <= 0)
                    {
                        Console.WriteLine("You have died!");
                        Environment.Exit(0);
                    }
                }
                Console.WriteLine($"You have defeated the {currentRoom.Monster.GetName()}!");
                currentRoom.Monster = null;
            }
        }

        // Main fucntion for the game to run.
        public void Start()
        {
            // Welcome message to the user.  
            Console.WriteLine("Welcome to the Decrepid House!" + "\n");

            // Getting user information.  
            Console.Write("Enter your name: ");
            string UserName = Console.ReadLine();

            Player.User = new Player(UserName, 100, 5);
            // Creating a Map in the loop to be called upon. 
            Map map = new Map();
            map.MapRoute();

            // Setting the starting room to the basement by using the StartRoom defined in Map.cs
            currentRoom = map.StartRoom;
            FinalRoom = map.FinalRoom;

            // Initializes the while loop to keep the game running.  
            bool playing = true;
            while (playing)
            {
                Console.WriteLine(currentRoom.GetDescription());
                PickItem();
                Direction();
                MonsterCombat();

                // If the current room is the final room, the game will end.
                if (currentRoom == FinalRoom && currentRoom.Monster == null)
                {
                    Console.WriteLine("You have Defeated the Final Boss!");
                    Console.WriteLine("Congratulations! You have completed the game!");
                    Environment.Exit(0);
                }
                else
                    continue;
            }
        }
    }
}
