using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace DungeonExplorer
{
    internal class ItemCheck
    {
        public bool CheckItem(Inventory inventory)
        {
            // Use the provided inventory instance to access the inventory list
            if (inventory.inventory.Count() > 0)
                return true;

            else return false;

            // If it does, return true
            // If it doesn't, return false
        }
    }

    public class RoomCheck
    {
        public bool CheckRoom()
        {
            // Use the provided map instance to access the current room
            if (Game.currentRoom != null)
                return true;

            else return false;
        }
    }
}
