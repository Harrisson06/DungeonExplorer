using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class Inventory
    {
        // Declare a private field to store the inventory.
        public List<string> inventory;

        // Initializes the inventory in the constructor.
        public Inventory()
        {
            inventory = new List<string>(); 
        }

        public void PickUpItem(string itemName)
        {
            // Add the item to the inventory.
            inventory.Add(itemName); 
        }

        // Removes an item from the inventory.
        public void RemoveItem(string itemName)
        {
            inventory.Remove(itemName); 
        }

        // Returns the contents of the Inventory list with a comma separator.
        public string InventoryContents()
        {
            return string.Join(", ", inventory.Select(i => i.Name)); 
        }

        public IEnumerable<Weapons> GetWeapons()
        {
            return inventory.OfType<Weapons>();
        }

        public IEnumerable<Potions> GetPotions()
        {
            return inventory.OfType<Potions>();
        }
    }
}

