using System.ComponentModel.DataAnnotations;

namespace StudentWebMarket.Models.Models
{
    public class School
    {
        [Key]
        public int SchoolId { get; set; }
        public string Name { get; set; }

    }
}
