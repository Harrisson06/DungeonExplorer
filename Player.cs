using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; set; }

        private List<string> inventory = new List<string>();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }

        public class PlayerItems
        {
            public int HealthPotion { get; private set; }
            public int Sword { get; private set; }
        }

            public void PickUpItem(string itemName)
        {
            new List<string> {};
            inventory.Add(itemName);
        }

        public void RemoveItem(string itemName)
        {
            inventory.Remove(itemName);
        }

        public string InventoryContents()
        {
            return string.Join(", ", inventory);
        }
    }
}