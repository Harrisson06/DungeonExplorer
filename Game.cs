using System;
using System.Diagnostics;
using System.Media;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private ItemCheck check;
        private Inventory inventory = new Inventory();
        public Game(MapRoute map)
        public Game()
        {
        }

        public void Start()
        {
            //Welcome message to the user.
            Console.WriteLine("Welcome to Dungeon Explorer!" + "\n");

            //Getting user information.
            Console.Write("Enter your name: ");
            string Name = Console.ReadLine();

            //Initializes the while loop to keep the game running.
            bool playing = true;
            while (playing)
            {
                Player user = new Player(Name, 50);
                new Map().MapRoute();



            }
        }
    }
}
