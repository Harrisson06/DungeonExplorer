using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    // This class is used to hold all room objects.
    public class Room
    {
        private string description;

        // Directions that the user can travel in the game.
        public Room LeftRoom { get; set; }
        public Room RightRoom { get; set; }
        public Room UpRoom { get; set; }
        public Room BackRoom { get; set; }
        public Room DownRoom { get; set; }

        // Adding two items to the constructor, Player items under parameters and monster.
        public List<PlayerItems> Items { get; set; }
        public Monster Monster { get; set; }

        // Room constructor for generating rooms for the game.
        public Room(string description, Monster monster = null, params PlayerItems[] items)
        {
            this.description = description;
            this.Monster = monster;
            if (items is null)
                this.Items = new List<PlayerItems>();
            else
                this.Items = new List<PlayerItems>(items);
        }

        // Function to Define if there is an item or a monster in the room.
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