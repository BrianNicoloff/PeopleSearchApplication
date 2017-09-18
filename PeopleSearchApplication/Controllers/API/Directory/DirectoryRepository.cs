using System.Collections.Generic;
using System.Linq;
using PeopleSearchApplication.Data;

namespace PeopleSearchApplication.Controllers.API.Directory
{
    public interface IDirectoryRepository
    {
        IList<Data.Person> GetPeople(int skip);
        IList<Data.Person> SearchPeople(string searchText, int skip);
    }

    public class DirectoryRepository : IDirectoryRepository
    {
        private readonly PeopleSearchContext _context;
        private const int Take = 25;

        public DirectoryRepository(PeopleSearchContext context)
        {
            _context = context;
        }

        public IList<Data.Person> GetPeople(int skip)
        {
            return _context.People
                    .OrderBy(p => p.Name)
                    .Skip(skip)
                    .Take(Take)
                    .ToList();
        }

        public IList<Data.Person> SearchPeople(string searchText, int skip)
        {
            if (searchText == null)
                return GetPeople(skip);

            return _context.People
                .Where(p => p.Name.Contains(searchText))
                .OrderBy(p => p.Name)
                .Skip(skip)
                .Take(Take)
                .ToList();
        }
    }
}
