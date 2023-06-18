using Microsoft.VisualStudio.TestPlatform.TestHost;
using MinotaurLabyrinth;

namespace MinotaurLabyrinthTest
{
    [TestClass]
    public class Tests
    {
        [TestMethod]

        public void UserGenerated_tunnel()
        {
            Room room = RoomFactory.Instance.BuildRoom(RoomType.Tunnel);
            string className = room.GetType().Name;
            Assert.AreEqual(className, "Tunnel");
        }

        [TestMethod]
        public void DeactivateTunnel_ShouldSetIsActiveToFalse()
        {

            Tunnel tunnel = new Tunnel();
            tunnel.DeactivateTunnel();
            Assert.IsFalse(tunnel.IsActive);
        }

        [TestMethod]
        public void PitRoomTest()
        {
            RandomNumberGenerator.SetSeed(1);

            Pit pitRoom = new Pit();
            Hero hero = new Hero();
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
