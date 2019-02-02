using Microsoft.EntityFrameworkCore;

namespace CRM
{

    public class CrmContext : DbContext
    {
        public CrmContext(DbContextOptions<CrmContext> options) : base(options)
        {

        }
        public DbSet<Interaction> interactions { get; set; }
        public DbSet<Lead> leads { get; set; }

        public DbSet<Employee> employees { get; set; }
        public DbSet<Priority_Type> priority_types { get; set; }
        public DbSet<Status_Type> status_types { get; set; }

        public DbSet<Detail> details { get; set; }

        public DbSet<Customer> customers { get; set; }


    }

}
