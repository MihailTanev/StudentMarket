using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebMarket.Models.Models
{
    public class School
    {
        [Key]
        public int SchoolId { get; set; }
        public string Name { get; set; }

    }
}
