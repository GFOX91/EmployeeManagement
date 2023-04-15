using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data
{
    /// <summary>
    /// This class is needed to allow Add-Migrations command to be run. 
    /// It is not a good implmentation as it has to have a constant connection sting in it
    /// but it is Ok on a local machine, which is where you want to run the command
    /// see https://docs.microsoft.com/en-us/ef/core/miscellaneous/configuring-dbcontext#using-idesigntimedbcontextfactorytcontext
    /// </summary>
    public class ContextFactoryNeededForMigrations : IDesignTimeDbContextFactory<AppDbContext>
    {

        private const string ConnectionString =
            "server=(localdb)\\MSSQLLocalDB;database=EmployeeDB;Trusted_Connection=true";

        public AppDbContext CreateDbContext(string[] args)
        {

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(ConnectionString,
                b => b.MigrationsAssembly("EmployeeManagement.Data"));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
