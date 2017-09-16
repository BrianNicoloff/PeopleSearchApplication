using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace PeopleSearchApplication.Controllers.API.Directory
{
    public class DirectoryController : ApiController
    {
        public IEnumerable<Person> Get(int skip)
        {
            return new List<Person>
            {
                new Person
                {
                    Name = "Brian",
                    Age = 38,
                    Phone = "(111) 111-1111",
                    ImagePath = "https://randomuser.me/api/portraits/men/1.jpg",
                    Interests = "Programming, Soccer, Music"
                }
            };
//            return new JsonResult();
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Interests { get; set; }
        public string ImagePath { get; set; }
    }
}
