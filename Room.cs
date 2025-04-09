namespace DungeonExplorer
{
    public class Room
    {
        private string description;

        public Room(string description)
        {
            this.description = description;
        }

        public string GetDescription()
        {
            return description;
        }
        
        public void CreateRooms()
        {
            Room Basement = new Room("You awaken, hurt and confused in a cold dark room. A basement perhaps? lights come from the top of a stairwell");
            Room Cave = new Room("A dark and damp cave.");
            Room Meadow = new Room("A bright and sunny meadow.");
            Room hauntedHouse = new Room("A spooky haunted house.");
            Room AncientTemple = new Room("A mysterious ancient temple.");
            Room Dungeon = new Room("A Large circular arena," + 
                "Desolate but loud with memories.");
        }
    }
}  