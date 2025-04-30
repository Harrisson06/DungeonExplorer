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
}
