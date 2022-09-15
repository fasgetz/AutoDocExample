using AutoDoc.DataBase.ContextDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AutoDoc.Api.ContextFactory
{
    public class SampleContextFactory : IDesignTimeDbContextFactory<AutoDocContext>
    {
        public AutoDocContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AutoDocContext>();
            var connectionString = configuration.GetConnectionString("AutoDocConnectionString");
            builder.UseSqlServer(connectionString, b =>
            {
                b.MigrationsAssembly("AutoDoc.DataBase");
            });

            return new AutoDocContext(builder.Options);

        }
    }
}