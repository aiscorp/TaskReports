using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskReportLib.Entityes;

namespace TaskReportLib.Data
{
    public class DataContext : DbContext
    {
        // Разрешение миграций и обновление
        // enable-migrations // add-migration Name  // update-database

        // Автоматические миграции
        // Enable-Migrations -StartUpProjectName TaskReportLib -MigrationsDirectory Data\Migrations -Verbose
        static DataContext() =>
    Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Migrations.Configuration>());

        // -----
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Project> Projects { get; set; }
        // -----
        public DataContext() : base("DbConnection") { }
        public DataContext(string connection) : base(connection) { }
    }
}
