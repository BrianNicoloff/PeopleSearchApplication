using System.Data.Entity;
using System.Runtime.InteropServices;

namespace PeopleSearchData
{
    public class PeopleSearchContext : DbContext
    {
        public PeopleSearchContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<PeopleSearchContext>(new CreateDatabaseIfNotExists<PeopleSearchContext>());
        }

        public DbSet<Person> People { get; set; }
    }
}