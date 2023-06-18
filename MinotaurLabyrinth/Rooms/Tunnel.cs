namespace MinotaurLabyrinth
{
    /// <summary>
    /// Represents a pit room, which contains a dangerous pit that the hero can fall into.
    /// </summary>
    public class Tunnel : Room
    {
        static Tunnel()
        {
            RoomFactory.Instance.Register(RoomType.Tunnel, () => new Tunnel());
        }

        /// <inheritdoc/>
        public override RoomType Type { get; } = RoomType.Tunnel;

        /// <inheritdoc/>
        public override bool IsActive { get; protected set; } = true;
        public void ActivateTunnel()
        {
            IsActive = true;
        }

        public void DeactivateTunnel()
        {
            IsActive = false;
        }

        // public Location TunnelEndLoc(Location tunnelendlocation)
        // {
        //     return tunnelendlocation;
        // }

        /// <summary>
        /// Activates the pit, causing the hero to potentially fall in and face consequences.
        /// </summary>
        public override void Activate(Hero hero, Map map)
        {
            if (IsActive)
            {
                ConsoleHelper.WriteLine("You walk into the room and the floor drops you in a tunnel that no one knows where it is headed to!", ConsoleColor.Red);
                // Could update these probabilities to be based off the hero attributes
                Location tunnelNewLocation = ProceduralGenerator.GetRandomLocation();
                Location tunnelEndLocation = ProceduralGenerator.GetRandomLocation();
                //this.TunnelEndLoc(tunnelEndLocation);
                Console.WriteLine($"The tunnel opens at ({0}, {1})", tunnelEndLocation.Row, tunnelEndLocation.Column);
                if (map.IsOnMap(tunnelEndLocation))
                {
                    hero.Location = tunnelEndLocation;
                }
                Console.WriteLine($"{0}, {1}, hero.Location.Row, hero.Location.Column");
                this.ActivateTunnel();
            }
        }

        /// <inheritdoc/>                                
        public override DisplayDetails Display()
        {
            return IsActive ? new DisplayDetails($"[{Type.ToString()[0]}]", ConsoleColor.Red)
                            : base.Display();
        }

        /// <summary>
        /// Displays sensory information about the pit, based on the hero's distance from it.
        /// </summary>
        /// <param name="hero">The hero sensing the pit.</param>
        /// <param name="heroDistance">The distance between the hero and the pit room.</param>
        /// <returns>Returns true if a message was displayed; otherwise, false.</returns>
        public override bool DisplaySense(Hero hero, int heroDistance)
        {
            if (!IsActive)
            {
                if (base.DisplaySense(hero, heroDistance))
                {
                    return true;
                }
                if (heroDistance == 0)
                {
                    ConsoleHelper.WriteLine("You dropped into tunnel", ConsoleColor.DarkGray);
                    Console.WriteLine($"tunnel state:{0}", this.IsActive);
                    return true;
                }
            }
            else if (heroDistance == 1 || heroDistance == 2)
            {
                ConsoleHelper.WriteLine(heroDistance == 1 ? "You can feel the howling noise of air it looks like some kind of unknown passage(Tunnels are always unexpected Be Careful)!" : "Your intuition tells you that something dangerous is nearby", ConsoleColor.DarkGray);
                return true;
            }
            return false;
        }
    }
}
