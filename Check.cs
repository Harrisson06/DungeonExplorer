using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DungeonExplorer
{
    // Checking the Inventory for items.
    internal class ItemCheck
    {
        public bool CheckItem(Inventory inventory)
        {
            // Use the provided inventory instance to access the inventory list
            if (inventory.inventory.Count() > 0)
                return true;

            else return false;
        }
    }

    public class Testing
    {
        // Function to check if the item was added to the inventory.
        public static bool CheckItemAdded(List<object>inventory, object item)
        {
            bool ItemAdded = inventory.Contains(item);
            Debug.Assert(ItemAdded, "Item was not added to the inventory.");
            return ItemAdded;
        }

        // Function to check if the item was removed from the inventory.
        public static bool CheckItemRemoved(List<object>inventory, object item)
        {
            bool ItemRemoved = !inventory.Contains(item);
            Debug.Assert(ItemRemoved, "Item was not removed from the inventory.");
            return ItemRemoved;
        }
    }
}
