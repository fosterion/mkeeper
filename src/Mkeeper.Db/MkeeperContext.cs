using Microsoft.EntityFrameworkCore;
using Mkeeper.Db.Entities;

namespace Mkeeper.Db;

public class MkeeperContext : DbContext
{
    public DbSet<Category> Categories { get; set; } = default!;
    public DbSet<Transaction> Transactions { get; set; } = default!;
    public DbSet<Wallet> Wallets { get; set; } = default!;

    public MkeeperContext(DbContextOptions<MkeeperContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>()
            .HasOne(u => u.Category)
            .WithMany(c => c.Transactions);
    }
}
