using System.Drawing;

namespace Awoo.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Username = "Cali",
                    Password = "",
                    Colour = Color.Crimson.ToArgb(),
                    //Schedule = new List<Availibility>()
                },
                new User()
                {
                    Id = 2,
                    Username = "Bali",
                    Password = "",
                    Colour = Color.DeepSkyBlue.ToArgb(),
                    //Schedule = new List<Availibility>()
                },
                new User()
                {
                    Id = 3,
                    Username = "foreverDM",
                    Password = "",
                    Colour = Color.Lavender.ToArgb(),
                    //Schedule = new List<Availibility>()
                }
            };
            var ttrpgs = new List<TTRPG>()
            {
                new TTRPG()
                {
                    Id = 1,
                    Name = "Cyberpunk",
                    Colour = Color.Red.ToArgb()
                },
                new TTRPG()
                {
                    Id = 2,
                    Name = "Pathfinder 2e",
                    Colour = Color.Orange.ToArgb()
                },
                new TTRPG()
                {
                    Id = 3,
                    Name = "Dungeons And Dragons",
                    Colour = Color.Blue.ToArgb()
                }
            };
            var sessions = new List<TabletopSession>()
            {
                new TabletopSession()
                {
                    Id = 1,
                    Name = "Cyberpunk Sunday",
                    //GameMaster = users[2],
                    GameMasterId = users[2].Id,
                    //Game = ttrpgs[0],
                    GameId = ttrpgs[0].Id,
                    //Players = new List<User> { users[0] }
                },
                new TabletopSession()
                {
                    Id = 2,
                    Name = "Pathfinder Saturdays",
                    //GameMaster = users[2],
                    GameMasterId = users[2].Id,
                    //Game = ttrpgs[1],
                    GameId = ttrpgs[1].Id,
                    //Players = new List<User> { users[1] }
                },
                new TabletopSession()
                {
                    Id = 3,
                    Name = "Dungeons And Dragons Fridays",
                    //GameMaster = users[2],
                    GameMasterId = users[2].Id,
                    //Game = ttrpgs[2],
                    GameId = ttrpgs[2].Id,
                    //Players = new List<User> { users[0], users[1] }
                }
            };
            var availibilities = new List<Availibility>()
            {
                new Availibility() { Id = 1, DateTime = DateTime.Now, State = CalanderStates.Maybe, PlayerId = users[0].Id },
                new Availibility() { Id = 2, DateTime = DateTime.MinValue, State = CalanderStates.Yes, PlayerId = users[1].Id },
                new Availibility() { Id = 3, DateTime = DateTime.MaxValue, State = CalanderStates.No, PlayerId = users[2].Id }
            };

        //users[0].Schedule.Add(availibility1);
        //users[1].Schedule.Add(availibility2);
        //users[2].Schedule.Add(availibility3);

        modelBuilder.Entity<User>().HasData(users);
        modelBuilder.Entity<TTRPG>().HasData(ttrpgs);
        modelBuilder.Entity<TabletopSession>().HasData(sessions);
        modelBuilder.Entity<Availibility>().HasData(availibilities);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<TTRPG> TTRPGs { get; set; }
    public DbSet<TabletopSession> TabletopSessions { get; set; }
}
}
