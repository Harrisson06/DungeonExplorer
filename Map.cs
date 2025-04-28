using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DungeonExplorer
{
    class Map
    {
        public Room StartRoom { get; set; }

        //this 
        public void MapRoute()
        {
            // Creating a set of weapons to be used in the game using Three parameters, Name, Description and Damage.
            var WoodenSword = new Weapons("Wooden Sword", "A Wooden sword, not very effective.", 10);
            var IronSword = new Weapons("Iron Sword", "An Iron sword, much more durable.", 16);
            var SteelSword = new Weapons("Steel Sword", "A steel sword, much more durable.", 27);

            // Creating a set of potions to be used in the game using Three parameters, Name, Description and Health.
            var HealthPotion = new Potions("Health Potion", "A potion that heals you.", 40);

            // Creating a set of monsters to be used in the game using Three parameters, Name, Health and Damage.
            var Goblin = new Monster("Goblin", 15, 12);
            var Skeleton = new Monster("Skeleton", 20, 17);
            var Zombie = new Monster("Zombie", 25, 24);
            var Dragon = new Monster("Dragon", 50, 30);

            var Basement = new Room("You awaken, hurt and confused in a cold dark room. A basement perhaps?"
                + "Theres something on the floor, Do you want to pick it up?\n", null, HealthPotion);

            var LivingRoom = new Room("Food rotting on the plates at the dinner table, they left in a hurry.\n"
                + "You see an object on the floor should you pick it up?", null, WoodenSword);

            var Kitchen = new Room("There's pots and pans on the floor, maybe there was a struggle,"
                + "A goblin jumps up from the counter and attacks you, what do you want to do?", Goblin, null);

            var MasterBedroom = new Room("The bed.", null, HealthPotion);
            var Bathroom = new Room("A mysterious ancient temple.", null, HealthPotion);
            var DiningRoom = new Room("A Large circular arena, desolate but loud with memories.", null, HealthPotion);
        }
    }
}
