using System.Collections.Generic;
using System.Dynamic;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;

        public Room LeftRoom { get; set; }
        public Room RightRoom { get; set; }
        private List<Items> Items { get; set; }

        public Room(string description, Monsters monster = null, params PlayerItems[] items)
        {
            this.description = description;
        }

        public string GetDescription()
        {
            return description;
        }
        
        public void CreateRooms()
        {
            Room Basement = new Room("You awaken, hurt and confused in a cold dark room. A basement perhaps? lights come from the top of a stairwell.");
            Room LivingRoom = new Room("Food rotting on the plates at the dinner table, they left in a hurry.");
            Room Kitchen = new Room("Theres pots and pans on the floor, maybe there was a strugle ");
            Room MasterBedroom = new Room("The bed .");
            Room Bathroom = new Room("A mysterious ancient temple.");
            Room DiningRoom = new Room("A Large circular arena," + 
                "Desolate but loud with memories.");
        }
    }
}  