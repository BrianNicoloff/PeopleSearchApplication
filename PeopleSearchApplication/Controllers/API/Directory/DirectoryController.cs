using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PeopleSearchApplication.Controllers.API.Directory
{
    public class DirectoryController : ApiController
    {
        private readonly IDirectoryRepository _directoryRepository;

        public DirectoryController(IDirectoryRepository directoryRepository)
        {
            _directoryRepository = directoryRepository;
        }

        public IEnumerable<Person> Get(int skip)
        {
            var dataPeople = _directoryRepository.GetPeople(skip).ToList();
            return dataPeople.ConvertAll<Person>(p => new Person
            {
                Name = p.Name,
                Age = p.Age,
                Phone = p.Phone,
                Interests = p.Interests,
                ImagePath = p.ImagePath
            });
        }
    }
}
