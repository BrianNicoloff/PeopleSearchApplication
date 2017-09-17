using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearchApplication.Controllers.API.Directory
{
    public interface IDirectoryRepository
    {
        IList<Data.Person> GetPeople(int skip);
    }

    public class DirectoryRepository : IDirectoryRepository
    {
        public IList<Data.Person> GetPeople(int skip)
        {
            throw new NotImplementedException();
        }
    }
}
