using System.ComponentModel.DataAnnotations;

namespace PeopleSearchData
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(75)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(500)]
        public string Interests { get; set; }

        [Required]
        [MaxLength(200)]
        public string ImagePath { get; set; }
    }
}
