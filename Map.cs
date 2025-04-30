using System;
using System.CodeDom;
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
        public Room FinalRoom { get; set; }

        //This is where the game resources are created. 
        //Creating the resources like this allow the game to be more customizable, you can simply create more rooms and monsters and potions 
        public void MapRoute()
        {
            // Creating a set of weapons to be used in the game using Three parameters, Name, Description and Damage.
            var WoodenSword = new Weapons("Wooden Sword", "A Wooden sword, not very effective.", 10);
            var IronSword = new Weapons("Iron Sword", "An Iron sword, much more durable.", 16);
            var SteelSword = new Weapons("Steel Sword", "A steel sword, much more durable.", 27);

            // Creating a set of potions to be used in the game using Three parameters, Name, Description and Health.
            var HealthPotion = new Potions("Health Potion", "A potion that gives you 60 health", 60);
            var StrongHealthPotion = new Potions("Strong Health Potion", "This one has quite a kick. [100HP]", 100);

            // Creating a set of monsters to be used in the game using Three parameters, Name, Health and Damage.
            var Goblin = new Monster("Goblin", 15, 12);
            var Skeleton = new Monster("Skeleton", 20, 17);
            var Dragon = new Monster("Dragon", 50, 20);
            
            // Creating a set of rooms to be used in the game using Three parameters, Description, monster and potion.
            // Null is used to set the monster or potion to nothing, this is used to create rooms that do not have a monster or potion in them.

            var Basement = new Room("\n{Basement}\n" 
                + "\nYou awaken, hurt and confused in a cold dark room. you must be in the basement?"
                + "\nTheres something on the floor, Do you want to pick it up?\n", null, HealthPotion);

            var MainHallway = new Room("\n{Downstairs Hallway}\n" 
                + "\nYou walk up the stairs, and see a hallway with doors on either side."
                + "\nYou hear a noise coming from the right door?", null, null);

            var LivingRoom = new Room("\n{Living Room}\n" 
                + "\nYou go into the living room. The TV is still on," +
                " \nThey must have left in a hurry. ", null, WoodenSword);

            var Kitchen = new Room("\n{Kitchen}\n" 
                + "\nYou Enter the Kitchen. There's pots and pans on the floor, maybe there was a struggle."
                , Goblin, null);

            var MasterBedroom = new Room("\n{Master Bedroom}\n" 
                + "\nWalking into the Master Bedroom. Theres a faint object glowing under the duvet," 
                + "\nYou should investigate\n. Do you want to pick it up?", null, StrongHealthPotion);

            var UpstairsHallway = new Room("\n{Upstairs Hallway}\n" 
                + "\nAfter leaving the MasterBedroom, you come across a scrpaing sound at the end of the hallway."
                , Skeleton, SteelSword);

            var DiningRoom = new Room("\n{Dining Room}\n" 
                + "\nThe tabale is set, where did they all go?", null, StrongHealthPotion, IronSword);

            var Attic = new Room("\n{Attic}\n" 
                + "\nA densly populated room with lots of treasure" 
                + "\nyou have completed the Decrepid house."
                , Dragon, null);

            // Setting the pathing for the rooms, the basement has only one way out, up the stiars.
            Basement.UpRoom = MainHallway;

            // Three routes, the living room and the kitchen, or upstairs to the hallway.
            MainHallway.LeftRoom = LivingRoom;
            MainHallway.RightRoom = Kitchen;
            MainHallway.UpRoom = UpstairsHallway;

            // The Kitchen allows you to go back to the hallway, or into the dining room.
            Kitchen.BackRoom = MainHallway;
            Kitchen.RightRoom = DiningRoom;

            // The Diningroom only allows you to go back to the kitchen.
            DiningRoom.BackRoom = Kitchen;

            // The Livingroom only allows you to go back to the hallway.
            LivingRoom.BackRoom = MainHallway;

            // The upstairs hallway allows you to go back down to the Downstairs hallway, into the master bedroom or up to the attic.
            UpstairsHallway.DownRoom = MainHallway;
            UpstairsHallway.LeftRoom = MasterBedroom;
            UpstairsHallway.UpRoom = Attic;

            // The Attic only allows you to go back downstairs. 
            Attic.BackRoom = UpstairsHallway;

            // The important rooms are set to the start and final rooms.
            StartRoom = Basement;
            FinalRoom = Attic;
        }
    }
}
