using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PeopleSearchApplication.Controllers.API.Directory
{
    [RoutePrefix("api/directory")]
    public class DirectoryController : ApiController
    {
        private readonly IDirectoryRepository _directoryRepository;

        public DirectoryController(IDirectoryRepository directoryRepository)
        {
            _directoryRepository = directoryRepository;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            var dataPeople = _directoryRepository.GetPeople(0).ToList();
            return dataPeople.ConvertAll<Person>(p => new Person
            {
                Id = p.Id,
                Name = p.Name,
                Age = p.Age,
                Phone = p.Phone,
                Interests = p.Interests,
                ImagePath = p.ImagePath
            });
        }

        [HttpGet]
        [Route("search")]
        public IEnumerable<Person> Search(string text, int skip)
        {
            var dataPeople = _directoryRepository.SearchPeople(text, skip).ToList();
            return dataPeople.ConvertAll<Person>(p => new Person
            {
                Id = p.Id,
                Name = p.Name,
                Age = p.Age,
                Phone = p.Phone,
                Interests = p.Interests,
                ImagePath = p.ImagePath
            });
        }
    }
}
