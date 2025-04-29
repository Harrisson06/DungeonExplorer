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
        public List<object> inventory;

        // Initializes the inventory in the constructor.  
        public Inventory()
        {
            inventory = new List<object>();
        }

        public void PickUpItem(object item)
        {
            // Add the item to the inventory.  
            inventory.Add(item);
        }

        // Removes an item from the inventory.  
        public void RemoveItem(object item)
        {
            inventory.Remove(item);
        }

        // Returns the contents of the Inventory list with a comma separator.  
        public string InventoryContents()
        {
            return string.Join(", ", inventory.Select(i => i.ToString()));
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

