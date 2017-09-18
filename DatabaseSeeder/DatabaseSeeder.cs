using System;
using System.Collections.Generic;
using System.Configuration;
using PeopleSearchData;

namespace DatabaseSeeder
{
    public class DatabaseSeeder
    {
        private readonly Random _random = new Random(DateTime.Now.Second);
        private string _connectionString = ConfigurationManager.ConnectionStrings["PeopleSearchApplication"].ConnectionString;

        public void Seed()
        {

            using (var db = new PeopleSearchContext(_connectionString))
            {
                db.People.RemoveRange(db.People);

                var people = new List<Person>();

                for (var i = 0; i < 1000; i++)
                {
                    people.Add(new Person
                    {
                        Age = AgeGenerator(),
                        Name = NameGenerator(),
                        ImagePath = ImageGenerator(),
                        Phone = PhoneGenerator(),
                        Interests = InerestsGenerator()
                    });
                }

                db.People.AddRange(people);

                db.SaveChanges();
            }
        }

        private int AgeGenerator()
        {
            return _random.Next(18, 68);
        }

        private string NameGenerator()
        {
            var firstNames = new List<string>
            {
                "Bill",
                "Tom",
                "Suzy",
                "Mary",
                "Zelda",
                "Mario",
                "Lisa",
                "Lucy",
                "Peter",
                "Zach",
                "William",
                "Bobby",
                "Pat",
                "Larry",
                "Doug",
                "Rob",
                "Rhoda",
                "Margaretha",
                "Nichols",
                "Annadiana",
                "Washington",
                "Percy",
                "Morrie",
                "Finlay",
                "Mirna",
                "Richart",
                "Bamby",
                "Mahmoud",
                "Mona",
                "Arron",
                "Erin",
                "Isabelle",
                "Sophi",
                "Shawnee",
                "Nanine",
                "Kaylyn",
                "Agosto",
                "Tadd",
                "Ave",
                "Hamnet",
                "Margaux",
                "Mehetabel",
                "Port",
                "Melanie",
                "Lyndsey",
                "Kelli",
                "Gonzalo",
                "Dodi",
                "Devondra",
                "Clair",
                "Bryna",
                "Starr",
                "Rodge",
                "Ricki",
                "Nicolais",
                "Ritchie",
                "Peri",
                "Nettie",
                "Pauli",
                "Leopold",
                "Isa",
                "Lilah",
                "Kassia",
                "Garland",
                "Evangelin"
            };
            var lastNames = new List<string> { "Smith", "Walter", "Sampson", "Patshu", "Thompson", "Francis", "Royer", "Nuri", "Harkins", "Petri", "Bergman", "Vito", "Greco", "Seats", "Hayes"};
            return firstNames[_random.Next(0, firstNames.Count - 1)] + " " + lastNames[_random.Next(0, lastNames.Count - 1)];
        }

        private string ImageGenerator()
        {
            var gender = _random.Next(0, 2) == 1 ? "men" : "women";
            var imageNumber = _random.Next(1, 99);
            return "https://randomuser.me/api/portraits/" + gender + "/" + imageNumber +".jpg";
        }

        private string PhoneGenerator()
        {
            return "(" + _random.Next(100, 999) + ")" + _random.Next(100, 999) + "-" + _random.Next(1000, 9999);
        }

        private string InerestsGenerator()
        {
            var interests = new List<string>
            {
                "rutrum at lorem integer tincidunt ante vel ipsum praesent blandit lacinia erat vestibulum sed magna",
                "morbi odio odio elementum eu interdum eu tincidunt in leo maecenas pulvinar lobortis",
                "vestibulum aliquet ultrices erat tortor sollicitudin mi sit amet lobortis sapien sapien non mi integer ac neque duis bibendum morbi",
                "eleifend pede libero quis orci nullam molestie nibh in lectus pellentesque at",
                "varius integer ac leo pellentesque ultrices mattis odio donec vitae nisi nam ultrices libero non mattis pulvinar nulla pede ullamcorper",
                "consectetuer eget rutrum at lorem integer tincidunt ante vel ipsum",
                "sit amet sem fusce consequat nulla nisl nunc nisl duis bibendum felis sed interdum",
                "orci luctus et ultrices posuere cubilia curae nulla dapibus dolor vel est donec",
                "viverra pede ac diam cras pellentesque volutpat dui maecenas tristique est et tempus semper est quam pharetra magna ac",
                "maecenas leo odio condimentum id luctus nec molestie sed justo pellentesque viverra",
                "vehicula consequat morbi a ipsum integer a nibh in quis justo maecenas rhoncus aliquam lacus morbi quis",
                "adipiscing molestie hendrerit at vulputate vitae nisl aenean lectus pellentesque eget nunc donec quis orci eget orci vehicula condimentum curabitur",
                "nibh in quis justo maecenas rhoncus aliquam lacus morbi quis tortor id nulla",
                "diam in magna bibendum imperdiet nullam orci pede venenatis non sodales sed tincidunt eu felis fusce posuere felis sed",
                "fusce congue diam id ornare imperdiet sapien urna pretium nisl ut volutpat sapien arcu sed augue aliquam erat volutpat in",
                "condimentum curabitur in libero ut massa volutpat convallis morbi odio odio elementum eu interdum",
                "nascetur ridiculus mus etiam vel augue vestibulum rutrum rutrum neque aenean auctor gravida sem praesent id massa id nisl venenatis",
                "eget tincidunt eget tempus vel pede morbi porttitor lorem id ligula suspendisse",
                "ligula vehicula consequat morbi a ipsum integer a nibh in quis justo maecenas rhoncus aliquam lacus morbi quis tortor",
                "vestibulum rutrum rutrum neque aenean auctor gravida sem praesent id massa id nisl venenatis lacinia",
                "lectus aliquam sit amet diam in magna bibendum imperdiet nullam orci pede venenatis non sodales",
                "vivamus tortor duis mattis egestas metus aenean fermentum donec ut mauris eget massa tempor convallis nulla neque libero convallis eget",
                "tristique fusce congue diam id ornare imperdiet sapien urna pretium nisl ut",
                "lorem id ligula suspendisse ornare consequat lectus in est risus auctor sed tristique in",
                "adipiscing elit proin risus praesent lectus vestibulum quam sapien varius ut blandit non interdum in ante vestibulum ante ipsum",
                "potenti in eleifend quam a odio in hac habitasse platea dictumst maecenas ut massa quis augue luctus tincidunt nulla",
                "rhoncus mauris enim leo rhoncus sed vestibulum sit amet cursus",
                "ac tellus semper interdum mauris ullamcorper purus sit amet nulla quisque",
                "posuere cubilia curae donec pharetra magna vestibulum aliquet ultrices erat tortor",
                "turpis elementum ligula vehicula consequat morbi a ipsum integer a nibh in quis justo maecenas rhoncus aliquam",
                "curae donec pharetra magna vestibulum aliquet ultrices erat tortor sollicitudin",
                "id lobortis convallis tortor risus dapibus augue vel accumsan tellus nisi",
                "quis augue luctus tincidunt nulla mollis molestie lorem quisque ut erat curabitur gravida nisi at nibh in hac habitasse platea",
                "phasellus in felis donec semper sapien a libero nam dui proin leo odio porttitor",
                "faucibus orci luctus et ultrices posuere cubilia curae nulla dapibus dolor",
                "at turpis donec posuere metus vitae ipsum aliquam non mauris morbi non lectus aliquam sit",
                "potenti in eleifend quam a odio in hac habitasse platea dictumst",
                "ornare consequat lectus in est risus auctor sed tristique in tempus sit amet sem fusce",
                "auctor gravida sem praesent id massa id nisl venenatis lacinia aenean",
                "lobortis convallis tortor risus dapibus augue vel accumsan tellus nisi eu orci",
                "morbi non lectus aliquam sit amet diam in magna bibendum imperdiet nullam",
                "id massa id nisl venenatis lacinia aenean sit amet justo morbi ut odio cras mi pede malesuada in imperdiet",
                "pede lobortis ligula sit amet eleifend pede libero quis orci nullam molestie nibh in lectus",
                "nisl nunc nisl duis bibendum felis sed interdum venenatis turpis enim blandit mi",
                "ut erat id mauris vulputate elementum nullam varius nulla facilisi cras non velit nec nisi",
                "mauris sit amet eros suspendisse accumsan tortor quis turpis sed ante",
                "turpis a pede posuere nonummy integer non velit donec diam",
                "semper sapien a libero nam dui proin leo odio porttitor id consequat in consequat ut nulla sed",
                "odio consequat varius integer ac leo pellentesque ultrices mattis odio donec vitae nisi nam ultrices libero non mattis",
                "sed tincidunt eu felis fusce posuere felis sed lacus morbi sem mauris laoreet ut rhoncus aliquet pulvinar"
            };

            return interests[_random.Next(0, interests.Count - 1)];
        }
    }
}
