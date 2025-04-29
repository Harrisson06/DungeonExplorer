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
        public Player user;
        public Room currentRoom;
        private ItemCheck check;
        private Inventory inventory = new Inventory();

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
                 + "[UP | DOWN | LEFT | RIGHT ]");
                string Keyinput = Console.ReadLine();
                Keyinput.ToLower();
                if (Keyinput == "up" && currentRoom.UpRoom != null)
                {
                    currentRoom = currentRoom.UpRoom;
                    Console.WriteLine("\nYou have gone up the stairs.");
                    break;
                }

                else if (Keyinput == "down" && currentRoom.BackRoom != null)
                {
                    currentRoom = currentRoom.BackRoom;
                    Console.WriteLine("\nYou have gone Down the stairs.");
                    break;
                }

                else if (Keyinput == "left" && currentRoom.LeftRoom != null)
                {
                    currentRoom = currentRoom.LeftRoom;
                    Console.WriteLine("\nYou have gone Left");
                    break;
                }

                else if (Keyinput == "right" && currentRoom.RightRoom != null)
                {
                    currentRoom = currentRoom.RightRoom;
                    Console.WriteLine("\nYou have gone Right");
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
                        Console.WriteLine("You have picked up the item: " + currentRoom.Items[0].Name);
                        inventory.PickUpItem(currentRoom.Items[0]);
                        Console.WriteLine("\nYour inventory now contains: " + inventory.InventoryContents());
                        currentRoom.Items.RemoveAt(0);
                    }
                }
                // If the user doesnt want to pick it up nothing happens and they leave it.
                else if (PickItemUp == "no")
                {
                    Console.WriteLine("You have chosen not to pick up the item.\n");
                }
                // Error handling for erroneous input
                else
                {
                     Console.WriteLine("Invalid input, You Left the item.\n");
                }
            }

        }

        public void Start()
        {
            // Welcome message to the user.  
            Console.WriteLine("Welcome to the Decrepid House!" + "\n");

            // Getting user information.  
            Console.Write("Enter your name: ");
            string UserName = Console.ReadLine();

            // Initializes the while loop to keep the game running.  
            bool playing = true;
            while (playing)
            {
                // Creating a Map in the loop to be called upon. 
                Map map = new Map(); 
                map.MapRoute();


                // Setting the starting room to the basement by using the StartRoom defined in Map.cs
                currentRoom = map.StartRoom; 
                Console.WriteLine(currentRoom.GetDescription());
                PickItem();
                Direction();

                Console.ReadKey();
                playing = false;
            }
        }
    }
}
