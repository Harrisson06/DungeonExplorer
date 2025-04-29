using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;

        public Room LeftRoom { get; set; }
        public Room RightRoom { get; set; }
        public Room UpRoom { get; set; }
        public Room BackRoom { get; set; }

        public List<PlayerItems> Items { get; set; }
        public Monster Monster { get; set; }

        public Room(string description, Monster monster = null, params PlayerItems[] items)
        {
            this.description = description;
            this.Monster = monster;
            if (items is null)
                this.Items = new List<PlayerItems>();
            else
                this.Items = new List<PlayerItems>(items);
        }

        public string GetDescription()
        {
            var ItemDescription = (Items != null && Items.Count > 0
                ? "You see: " + string.Join(", ", Items.Select(i => i.Name))
                : "No items have been found in the room.");

            var MonsterDescription = Monster != null
                ? "You see a " + Monster.GetName() + " in the room."
                : "No monsters have been found in the room.";


            return description + "\n" + ItemDescription + "\n" + MonsterDescription;
        }
    }
}