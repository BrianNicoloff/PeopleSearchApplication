using System.Collections.Generic;
using System.Linq;
using PeopleSearchApplication.Data;

namespace PeopleSearchApplication.Controllers.API.Directory
{
    public interface IDirectoryRepository
    {
        IList<Data.Person> GetPeople(int skip);
    }

    public class DirectoryRepository : IDirectoryRepository
    {
        private readonly PeopleSearchContext _context;

        public DirectoryRepository(PeopleSearchContext context)
        {
            _context = context;
        }

        public IList<Data.Person> GetPeople(int skip)
        {
            return _context.People
                    .OrderBy(p => p.Name)
                    .ToList();
        }
    }
}
