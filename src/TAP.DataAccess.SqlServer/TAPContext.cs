using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TAP.Core.Entities;

namespace TAP.DataAccess.SqlServer
{
    public class TAPContext : DbContext
    {
        private string connectionString;
        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }


        public TAPContext()
        {
        }

       public TAPContext(string connectionString)
       {
            this.connectionString = connectionString;
       }
       //public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = this.connectionString ?? System.Configuration.ConfigurationManager.ConnectionStrings["Tap"].ConnectionString;
            //var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TAP"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);

            //optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=TAPDb123;Integrated Security=True;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
