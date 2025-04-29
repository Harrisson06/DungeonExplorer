using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace DungeonExplorer
{
    class Map
    {
        public Room StartRoom { get; set; }

        //This is where the game resources are created. 
        //Creating the resources like this allow the game to be more customizable, you can simply create more rooms and monsters and potions 
        public void MapRoute()
        {
            // Creating a set of weapons to be used in the game using Three parameters, Name, Description and Damage.
            var WoodenSword = new Weapons("Wooden Sword", "A Wooden sword, not very effective.", 10);
            var IronSword = new Weapons("Iron Sword", "An Iron sword, much more durable.", 16);
            var SteelSword = new Weapons("Steel Sword", "A steel sword, much more durable.", 27);

            // Creating a set of potions to be used in the game using Three parameters, Name, Description and Health.
            var HealthPotion = new Potions("Health Potion", "A potion that gives you 40 health", 40);
            var StrongHealthPotion = new Potions("Strong Health Potion", "Another health potion, this one has quite a kick.", 80);

            // Creating a set of monsters to be used in the game using Three parameters, Name, Health and Damage.
            var Goblin = new Monster("Goblin", 15, 12);
            var Skeleton = new Monster("Skeleton", 20, 17);
            var Zombie = new Monster("Zombie", 25, 24);
            var Dragon = new Monster("Dragon", 50, 30);

            // Creating a set of rooms to be used in the game using Three parameters, Description, monster and potion.
            // Null is used to set the monster or potion to nothing, this is used to create rooms that do not have a monster or potion in them.

            var Basement = new Room("You awaken, hurt and confused in a cold dark room. A basement perhaps?"
                + "Theres something on the floor, Do you want to pick it up?\n", null, HealthPotion);

            var DownstairsHallway = new Room("You walk up the stairs, and see a hallway with doors on either side.\n"
                + "You hear a noise coming from the left door, do you want to investigate?", null, null);

            var LivingRoom = new Room("Food rotting on the plates at the dinner table, they left in a hurry.\n"
                + "You see an object on the floor should you pick it up?", null, WoodenSword);

            var Kitchen = new Room("There's pots and pans on the floor, maybe there was a struggle,"
                + "A goblin jumps up from the counter and attacks you, what do you want to do?", Goblin, null);

            var MasterBedroom = new Room("The bed is creaky, you see a faint glow underneath the bed, you investigate\n"
                + "Do you want to pick it up?", null, StrongHealthPotion);

            var UpstairsHallway = new Room("After leaving the MasterBedroom, you come across a scrpaing sound at the end of the hallway.\n"
                + "A skeleton jumps you, What do you want to do?\n", Skeleton, IronSword);

            var DiningRoom = new Room("A Large circular arena, desolate but loud with memories.", null, StrongHealthPotion, SteelSword);

            var Attic = new Room("A densly populated room with lots of treasure, you hear a faint noise coming from the corner of the room, ITS A BABY DRAGON,"
                + "It looks hungry, what do you want to do?", Dragon, null);

            // Setting the pathing for the rooms, the basement has only one way out, up the stiars.
            Basement.UpRoom = DownstairsHallway;

            // Three routes, the living room and the kitchen, or upstairs to the hallway.
            DownstairsHallway.LeftRoom = LivingRoom;
            DownstairsHallway.RightRoom = Kitchen;
            DownstairsHallway.UpRoom = UpstairsHallway;

            // The Kitchen allows you to go back to the hallway, or into the dining room.
            Kitchen.BackRoom = DownstairsHallway;
            Kitchen.RightRoom = DiningRoom;

            // The Diningroom only allows you to go back to the kitchen.
            DiningRoom.BackRoom = Kitchen;

            // The Livingroom only allows you to go back to the hallway.
            LivingRoom.BackRoom = DownstairsHallway;

            // The upstairs hallway allows you to go back down to the Downstairs hallway, into the master bedroom or up to the attic.
            UpstairsHallway.BackRoom = DownstairsHallway;
            UpstairsHallway.LeftRoom = MasterBedroom;
            UpstairsHallway.UpRoom = Attic;

            // The Attic only allows you to go back downstairs. 
            Attic.BackRoom = UpstairsHallway;

            // The Starting room.
            StartRoom = Basement;

        }
    }
}
