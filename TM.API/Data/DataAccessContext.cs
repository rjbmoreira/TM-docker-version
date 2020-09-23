using Microsoft.EntityFrameworkCore;
using TM.API.Models;

namespace TM.API.Data
{
    public class DataAccessContext : DbContext{

        public DataAccessContext(DbContextOptions<DataAccessContext> options) : base(options) {

        }

        public DbSet<Customer> Customers {get;set;}
        public DbSet<Project> Projects {get;set;}
        public DbSet<TimeInput> TimeInputs {get;set;}
        
    }
}