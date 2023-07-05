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
/*
            var IntValueConverter = new IntListToStringValueConverter();

            modelBuilder
                .Entity<TabletopSession>()
                .Property(e => e.Players) //Property
                .HasConversion(IntValueConverter);
*/


            var users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Username = "Cali",
                    Password = "",
                    Colour = Color.Crimson.ToArgb()
                },
                new User()
                {
                    Id = 2,
                    Username = "Bali",
                    Password = "",
                    Colour = Color.DeepSkyBlue.ToArgb()
                },
                new User()
                {
                    Id = 3,
                    Username = "foreverDM",
                    Password = "",
                    Colour = Color.Lavender.ToArgb()
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
                    GameMaster = users[2],
                    Game = ttrpgs[0],
                    Players = new List<User> { users[0] }
                },
                new TabletopSession()
                {
                    Id = 2,
                    Name = "Pathfinder Saturdays",
                    GameMaster = users[2],
                    Game = ttrpgs[1],
                    Players = new List<User> { users[1] }
                },
                new TabletopSession()
                {
                    Id = 3,
                    Name = "Dungeons And Dragons Fridays",
                    GameMaster = users[2],
                    Game = ttrpgs[2],
                    Players = new List<User> { users[0], users[1] }
                }
            };

            modelBuilder.Entity<User>().HasData(ttrpgs);

            modelBuilder.Entity<TTRPG>().HasData(users);

            modelBuilder.Entity<TabletopSession>().HasData(sessions);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TTRPG> TTRPGs { get; set; }
        public DbSet<TabletopSession> TabletopSessions { get; set; }
    }
}
