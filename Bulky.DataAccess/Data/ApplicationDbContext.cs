using Microsoft.EntityFrameworkCore;
using Bulky.Models;

namespace Bulky.DataAccess.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {

    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{

	}

	public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
		modelBuilder.Entity<Category>().HasData(
			new Category { Id=1, Name= "Action", DisplayOrder=1},
                new Category { Id = 2, Name = "Sci-Fi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3  }
                );
        }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql("Server=localhost;port=3030;Database=Bulkys;user=root;password=ooin;",
                new MySqlServerVersion(new Version(7, 0, 0)),
                mySqlOptions => mySqlOptions.EnableRetryOnFailure()); 
        }
    }
}

