using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebsite.Models
{
    [Table("temps")]
    public class Temp
    {
        [Key]
        public string City { get; set; }
        public string Country { get; set; }
        public int Id { get; set; }

        public Temp(string city, string country, int id = 0)
        {
            City = city;
            Country = country;
            Id = id;
        }

        public Temp() { }
    }
}
