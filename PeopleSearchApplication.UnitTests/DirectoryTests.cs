using System.Collections.Generic;
using System.Linq;
using Autofac;
using Moq;
using NUnit.Framework;
using PeopleSearchApplication.Controllers.API.Directory;
using PeopleSearchApplication.Data;

namespace PeopleSearchApplication.UnitTests
{

    [TestFixture]
    public class DirectoryTests
    {
        private IContainer _container;
        private DirectoryController _testObject;
        private Mock<IDirectoryRepository> _directoryRepository;

        [SetUp]
        public void Setup()
        {
            _directoryRepository = new Mock<IDirectoryRepository>();

            var builder = new ContainerBuilder();
            Dependencies.Resolve(builder);
            builder.RegisterInstance(_directoryRepository.Object);
            _container = builder.Build();

            _testObject = _container.Resolve<DirectoryController>();
        }

        [TearDown]
        public void Teardown()
        {
            _container.Dispose();
        }

        [Test]
        public void Get_ShouldGetListOfPeopleFromTheDatabase()
        {
            var people = new List<Data.Person>
            {
                new Data.Person
                {
                    Id = 111,
                    Name = "Marmaduke Nukum",
                    Age = 22,
                    Phone = "123-123-0123",
                    Interests = "Long walks through the park",
                    ImagePath = "urltoimage.jpg"
                }
            };
            _directoryRepository.Setup(r => r.GetPeople(0)).Returns(people);

            var results = _testObject.Get();
            var firstPerson = results.First();

            Assert.That(results.Count(), Is.EqualTo(1));
            Assert.That(firstPerson.Id, Is.EqualTo(111));
            Assert.That(firstPerson.Name, Is.EqualTo("Marmaduke Nukum"));
            Assert.That(firstPerson.Age, Is.EqualTo(22));
            Assert.That(firstPerson.Phone, Is.EqualTo("123-123-0123"));
            Assert.That(firstPerson.Interests, Is.EqualTo("Long walks through the park"));
            Assert.That(firstPerson.ImagePath, Is.EqualTo("urltoimage.jpg"));
        }

        [Test]
        public void Search_RetrievesTheSearchResultsFromTheRepository()
        {
            var people = new List<Data.Person>
            {
                new Data.Person
                {
                    Id = 111,
                    Name = "Marmaduke Nukum",
                    Age = 22,
                    Phone = "123-123-0123",
                    Interests = "Long walks through the park",
                    ImagePath = "urltoimage.jpg"
                }
            };
            var searchText = "mar";
            _directoryRepository.Setup(r => r.SearchPeople(searchText, 0)).Returns(people);

            var results = _testObject.Search(searchText, 0);

            var firstPerson = results.First();

            Assert.That(results.Count(), Is.EqualTo(1));
            Assert.That(firstPerson.Id, Is.EqualTo(111));
            Assert.That(firstPerson.Name, Is.EqualTo("Marmaduke Nukum"));
            Assert.That(firstPerson.Age, Is.EqualTo(22));
            Assert.That(firstPerson.Phone, Is.EqualTo("123-123-0123"));
            Assert.That(firstPerson.Interests, Is.EqualTo("Long walks through the park"));
            Assert.That(firstPerson.ImagePath, Is.EqualTo("urltoimage.jpg"));
        }
    }

}
