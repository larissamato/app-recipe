using Microsoft.EntityFrameworkCore;
using Recipe.Domain.Entities;

namespace Recipe.Infrastructure.DataAccess;

public class RecipeDbContext : DbContext
{
    public RecipeDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecipeDbContext).Assembly);
    }
}
