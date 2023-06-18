using MinotaurLabyrinth;

namespace MinotaurLabyrinthTest
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void UserGeneratedTunnel()
        {
            Room room = RoomFactory.Instance.BuildRoom(RoomType.Tunnel);
            string className = room.GetType().Name;
            Assert.AreEqual(className, "Tunnel");
        }

        [TestMethod]
        public void DeactivateTunnelIsActiveToFalse()
        {

            Tunnel tunnel = new Tunnel();
            tunnel.DeactivateTunnel();
            Assert.IsFalse(tunnel.IsActive);
        }

        [TestMethod]
        public void PitRoomTest()
        {
            int seedVar = 1;
            RandomNumberGenerator.SetSeed(seedVar);
            Pit pitRoom = new Pit();
            Location start = new Location(0, 1);
            Hero hero = new Hero(start);
            Map map = new Map(1, 1);

            pitRoom.Activate(hero, map);
            Assert.AreEqual(pitRoom.IsActive, false);
            Assert.AreEqual(hero.IsAlive, true);

            hero.HasSword = true;
            pitRoom.Activate(hero, map);
            Assert.AreEqual(hero.IsAlive, true);

            Pit newPitRoom = new Pit();
            newPitRoom.Activate(hero, map);
            Assert.AreEqual(hero.IsAlive, true);

            newPitRoom.Activate(hero, map);
            newPitRoom = new Pit();
            newPitRoom.Activate(hero, map);
            newPitRoom = new Pit();
            newPitRoom.Activate(hero, map);
            Assert.AreEqual(hero.IsAlive, false);
        }
    }
}
