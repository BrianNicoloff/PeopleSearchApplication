using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
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
            if (ConfigurationManager.AppSettings["SimulateSlowNetwork"] == "true")
            {
               Thread.Sleep(5000);
            }
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
            if (ConfigurationManager.AppSettings["SimulateSlowNetwork"] == "true")
            {
                Thread.Sleep(3000);
            }
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
