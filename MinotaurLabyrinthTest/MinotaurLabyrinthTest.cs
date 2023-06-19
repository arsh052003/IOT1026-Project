using MinotaurLabyrinth;

namespace MinotaurLabyrinthTest
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        // This test checks when tunnel room is generated and compare the name of class created created.
        public void UserGeneratedTunnel()
        {
            Room room = RoomFactory.Instance.BuildRoom(RoomType.Tunnel);
            string className = room.GetType().Name;
            Assert.AreEqual(className, "Tunnel");
        }

        [TestMethod]
        // This test check that DeactivateTunnel method in the tunnel class correctly sets the IsActive property to false.
        public void DeactivateTunnelIsActiveToFalse()
        {

            Tunnel tunnel = new Tunnel();
            tunnel.DeactivateTunnel();
            Assert.IsFalse(tunnel.IsActive);
        }

        [TestMethod]
        // This test checks the functionality of the pit room
        public void PitRoomTest()
        {
            //sets a seed value for the random number.
            int seedVar = 1;
            RandomNumberGenerator.SetSeed(seedVar);
            Pit pitRoom = new Pit();
            Location start = new Location(0, 1);
            Hero hero = new Hero(start);
            Map map = new Map(1, 1);

            // pitRoom activates with hero and map object.
            pitRoom.Activate(hero, map);
            Assert.AreEqual(pitRoom.IsActive, false);
            Assert.AreEqual(hero.IsAlive, true);

            // sets the HasSword property of hero to true and activates the pitRoom again.
            hero.HasSword = true;
            pitRoom.Activate(hero, map);
            Assert.AreEqual(hero.IsAlive, true);

            // Create a new instance of pit
            Pit newPitRoom = new Pit();
            newPitRoom.Activate(hero, map);
            Assert.AreEqual(hero.IsAlive, true);

            // activates the newPitRoom
            newPitRoom.Activate(hero, map);
            newPitRoom = new Pit();
            newPitRoom.Activate(hero, map);
            newPitRoom = new Pit();
            newPitRoom.Activate(hero, map);
            Assert.AreEqual(hero.IsAlive, false);
        }
    }
}
