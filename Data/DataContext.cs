using Microsoft.EntityFrameworkCore;

namespace NetEntity.Data;

public class DataContext : DbContext // Entity Framework Core
{
  public DataContext(DbContextOptions<DataContext> options) : base(options)
  {
  }

  public DbSet<Models.Todo> Todos { get; set; }
}