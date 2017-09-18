using System.Data.Entity;

namespace PeopleSearchApplication.Data
{
    public class PeopleSearchContext : DbContext
    {
        public PeopleSearchContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<PeopleSearchContext>(null);
        }

        public DbSet<Person> People { get; set; }
    }
}
