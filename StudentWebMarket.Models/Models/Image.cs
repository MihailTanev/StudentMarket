using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebMarket.Models.Models
{
    public class Image
    {
        [Key]

        public int ImageId { get; set; }

        [Column(TypeName = "image")]
        public byte[] Content { get; set; }

        public string FileExtension { get; set; }
    }
}
