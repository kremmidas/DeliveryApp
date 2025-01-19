using Microsoft.EntityFrameworkCore.Design;

namespace DeliveryApp.Infrastructure.Data
{
  public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
  {
    public AppDbContext CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
      
      optionsBuilder.UseSqlite();
      
      return new AppDbContext(optionsBuilder.Options, null);
    }
  }
}
