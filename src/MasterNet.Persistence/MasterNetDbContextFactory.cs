using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MasterNet.Persistence;

public class MasterNetDbContextFactory : IDesignTimeDbContextFactory<MasterNetDbContext>
{
    public MasterNetDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MasterNetDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=localhost\\SQLEXPRESS;Database=CollectionsDb;Trusted_Connection=True;TrustServerCertificate=True"
        );

        return new MasterNetDbContext(optionsBuilder.Options);
    }
}
