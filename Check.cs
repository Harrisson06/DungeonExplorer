using System;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace DungeonExplorer
{
    internal class ItemCheck
    {
        public bool CheckItem(string itemName, Inventory inventory)
        {
            // Use the provided inventory instance to access the inventory list
            return inventory.inventory.Contains(itemName);

            

            // If it does, return true
            // If it doesn't, return false
        }
    }

    internal class DamageCheck
    {
        public bool? CheckDamage(string name, Inventory inventory)
        {
            return null;
        }
    }
}