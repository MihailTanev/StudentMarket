using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebMarket.Models.Models
{
    public class StudentProgram
    {
        [Key]
        public int StudentProgramId { get; set; }       
        public string Name { get; set; }

    }
}
