using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Assignment_3.Models;

namespace Assignment_3.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Menu> Menu { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<Item> Item { get; set; }
    public DbSet<Reserv> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .Property(o => o.Status)
            .HasConversion<string>();

        modelBuilder.Entity<Item>()
            .Property(o => o.Note)
            .IsRequired(false);
    }
}

