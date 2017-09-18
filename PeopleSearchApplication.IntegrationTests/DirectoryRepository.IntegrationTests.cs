using System;
using System.Configuration;
using System.Linq;
using Autofac;
using NUnit.Framework;
using PeopleSearchApplication.Controllers.API.Directory;
using PeopleSearchData;
using Data = PeopleSearchData;

namespace PeopleSearchApplication.IntegrationTests
{
    [TestFixture]
    public class DirectoryRepositoryIntegrationTests
    {
        private IContainer _container;
        private IDirectoryRepository _testObject;
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["PeopleSearchApplication"].ConnectionString;

        [SetUp]
        public void Setup()
        {
            var builder = new ContainerBuilder();
            Dependencies.Resolve(builder);
            _container = builder.Build();

            CleanupDatabase();

            _testObject = _container.Resolve<IDirectoryRepository>();
        }

        [TearDown]
        public void Teardown()
        {
            _container.Dispose();
        }

        [Test]
        public void GetPeople_GetsPeopleInAlphabeticalOrder()
        {
            AddPerson("Canderson", 22, "222-222-2222", "image2", "interests3");
            AddPerson("Zanderson", 33, "333-333-3333", "image3", "interests2");
            AddPerson("Anderson", 11, "111-111-1111", "image1", "interests1");

            var results = _testObject.GetPeople(0);

            Assert.That(results.Count(), Is.EqualTo(3));
            Assert.That(results[0].Name, Is.EqualTo("Anderson"));
            Assert.That(results[1].Name, Is.EqualTo("Canderson"));
            Assert.That(results[2].Name, Is.EqualTo("Zanderson"));
        }

        [Test]
        public void GetPeople_ReturnsOnlyTheTop25User()
        {
            for (var i = 1; i <= 25; i++)
            {
                AddPerson("Person" + i, i, i.ToString(), "image" + i, "interests " + i);
            }

            AddPerson("Anderson", 11, "111-111-1111", "image1", "interests1");

            var results = _testObject.GetPeople(0);

            Assert.That(results.Count(), Is.EqualTo(25));
        }

        [Test]
        public void SearchPeople_ReturnsPeopleWithNameContainingSearchText()
        {
            AddPerson("Canderson", 22, "222-222-2222", "image2", "interests3");
            AddPerson("Zanderson", 33, "333-333-3333", "image3", "interests2");
            AddPerson("Anderson", 11, "111-111-1111", "image1", "interests1");
            AddPerson("Canzander", 44, "444-333-3333", "image4", "interests4");

            var results = _testObject.SearchPeople("zan", 0);

            Assert.That(results.Count(), Is.EqualTo(2));

            Assert.That(results[0].Name, Is.EqualTo("Canzander"));
            Assert.That(results[1].Name, Is.EqualTo("Zanderson"));
        }

        [Test]
        public void SearchPeople_ReturnsTop25AllUsersWhenSearchTextIsNull()
        {
            AddPerson("Canderson", 22, "222-222-2222", "image2", "interests3");
            AddPerson("Zanderson", 33, "333-333-3333", "image3", "interests2");
            AddPerson("Anderson", 11, "111-111-1111", "image1", "interests1");
            AddPerson("Canzander", 44, "444-333-3333", "image4", "interests4");

            var results = _testObject.SearchPeople(null, 0);

            Assert.That(results.Count(), Is.EqualTo(4));
            Assert.That(results[0].Name, Is.EqualTo("Anderson"));
            Assert.That(results[1].Name, Is.EqualTo("Canderson"));
            Assert.That(results[2].Name, Is.EqualTo("Canzander"));
            Assert.That(results[3].Name, Is.EqualTo("Zanderson"));
        }

        [Test]
        public void SearchPeople_ReturnsTheNext25UsersWhenSearchTextIsNull()
        {
            for (var i = 1; i <= 50; i++)
            {
                AddPerson("Person" + i, i, i.ToString(), "image" + i, "interests " + i);
            }
            var results = _testObject.SearchPeople(null, 25);

            Assert.That(results.Count(), Is.EqualTo(25));
            Assert.That(results.First().Name, Is.EqualTo("Person32"));
            Assert.That(results.Last().Name, Is.EqualTo("Person9"));
        }

        [Test]
        public void SearchPeople_SkipsUsersAndTakes25()
        {
            for (var i = 1; i <= 50; i++)
            {
                AddPerson("Person" + i, i, i.ToString(), "image" + i, "interests " + i);
            }

            var results = _testObject.SearchPeople("person", 25);

            foreach (var result in results)
            {
                Console.WriteLine(result.Name);
            }

            Assert.That(results.Count, Is.EqualTo(25));
            Assert.That(results.First().Name, Is.EqualTo("Person32"));
            Assert.That(results.Last().Name, Is.EqualTo("Person9"));
        }

        private void AddPerson(string name, int age, string phone, string imagePath, string interests)
        {
            using (var db = new PeopleSearchContext(_connectionString))
            {
                db.People.Add(new Data.Person
                {
                    Name = name,
                    Age = age,
                    Phone = phone,
                    Interests = interests,
                    ImagePath = imagePath

                });
                db.SaveChanges();
            }
        }

        private void CleanupDatabase()
        {
            using (var db = new PeopleSearchContext(_connectionString))
            {
                db.People.RemoveRange(db.People);
                db.SaveChanges();
            }
        }
    }
}
