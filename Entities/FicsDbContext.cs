using Microsoft.EntityFrameworkCore;

namespace simulado.Entities;

public class FicsDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Fanfic> Fanfics => Set<Fanfic>();
    public DbSet<ReadList> ReadLists => Set<ReadList>();
    public DbSet<User> Users => Set<User>();

    public DbSet<Fanfics_list> FanficsList => Set<Fanfics_list>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Fanfic>();

        model.Entity<ReadList>();

        model.Entity<User>();

        // model.Entity<Fanfics_list>()
        // .HasOne(l => l.Fics)
        // .WithMany(f => f.)
        // .HasForeignKey();

    }
}