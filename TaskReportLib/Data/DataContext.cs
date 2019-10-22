using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskReportLib.Entityes;

namespace TaskReportLib.Data
{
    class DataContext : DbContext
    {
        protected DataContext() : base("DbConnectionString")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Project> Projects { get; set; }
        

    }
}
