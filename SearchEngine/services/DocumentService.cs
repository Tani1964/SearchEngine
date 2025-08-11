public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Document> Documents { get; set; }
    public DbSet<Word> Words { get; set; }
    public DbSet<DocumentWord> DocumentWords { get; set; }
}
