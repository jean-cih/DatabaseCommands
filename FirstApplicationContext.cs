namespace SQLWorking
{
    public class FirstApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public string connectionString;
        public FirstApplicationContext(string connectionString)
        {
            this.connectionString = connectionString;

            Database.EnsureDeleted();
            bool isCreated = Database.EnsureCreated();
            if(isCreated)
                Console.WriteLine("The Database is created:");
            else
                Console.WriteLine("The Database has already existed:");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
