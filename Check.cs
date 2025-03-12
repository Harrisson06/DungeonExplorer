using System;


namespace DungeonExplorer
{
    public class Check
    {
        public bool CheckInventory(Player player, string item)
        {
            return player.InventoryContents().Contains(item);
        }
    }
}