using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DashboardBackend.Database
{
    public class DashboardDBContextFactory : IDesignTimeDbContextFactory<DashboardDBContext>
    {
        public DashboardDBContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var builder = new DbContextOptionsBuilder<DashboardDBContext>();
            var connectionString = configuration.GetConnectionString("DashboardDBConnection");
            builder.UseSqlServer(connectionString);
            return new DashboardDBContext(builder.Options);
        }
    }
}
