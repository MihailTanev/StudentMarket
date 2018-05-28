using System.ComponentModel.DataAnnotations;

namespace StudentWebMarket.Models.Models
{
    public class StudentProgram
    {
        [Key]
        public int StudentProgramId { get; set; }       
        public string Name { get; set; }

    }
}
