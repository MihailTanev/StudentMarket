using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
