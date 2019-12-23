using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DashboardBackend.Database.Models;

namespace DashboardBackend.Database
{
    public class DashboardDBContext : DbContext
    {
        public DashboardDBContext(DbContextOptions options) : base(options)
        {

        }
        
        public DbSet<Project> Project { get; set; }
        public DbSet<Person> Person { get; set; }
    }
}
