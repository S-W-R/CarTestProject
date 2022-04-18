using CarApi.Domain.Models;
using CarApi.Infrastructure.Models;
using Microsoft.Data.Sqlite;

namespace CarApi.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;

public class CarContext : DbContext
{
    public DbSet<CarDbEntity> Cars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=cars.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarDbEntity>(x =>
        {
            x.HasKey(car => car.Number);
        });
        modelBuilder.Entity<CarDbEntity>().ToTable("Cars");
    }
}