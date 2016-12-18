using Microsoft.EntityFrameworkCore;

public class DinerDbContext : DbContext
{
    public DbSet<Meal> Meals {get;set;}
    public DbSet<Ingredient> Ingredient {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=./Diner.db");
    }    
}
