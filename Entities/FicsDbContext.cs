using Microsoft.EntityFrameworkCore;

namespace simulado.Entities;

public class FicsDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Fanfic> Fanfics => Set<Fanfic>();
    public DbSet<ReadList> ReadLists => Set<ReadList>();
    public DbSet<User> Users => Set<User>();


    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Fanfic>()
        .HasMany(l => l.Lists)
        .WithMany(f => f.Fanfics);

        model.Entity<Fanfic>()
        .HasOne(f => f.Owner)
        .WithMany(fa => fa.Fanfics)
        .HasForeignKey(f => f.OwnerID)
        .OnDelete(DeleteBehavior.NoAction);


        model.Entity<ReadList>()
        .HasOne(re => re.Owner)
        .WithMany(r => r.Lists)
        .HasForeignKey(re => re.OwnerID)
        .OnDelete(DeleteBehavior.NoAction);


        model.Entity<User>();

    }
}