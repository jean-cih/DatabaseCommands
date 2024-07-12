namespace SQLWorking
{
    public partial class SecondApplicationContext : DbContext
    {
        public string connectionString;
        public SecondApplicationContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=D:\\Development\\C#\\ConsoleProjects\\SQLWorking\\bin\\Debug\\net8.0\\{connectionString}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
