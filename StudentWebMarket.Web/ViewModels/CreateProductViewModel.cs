using StudentWebMarket.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace StudentWebMarket.Web.ViewModels
{
    public class CreateProductViewModel
    {

        public Category Category { get; set; }
        public Condition Condition { get; set; }

        [Required]
        [Range(0, 9999)]
        [Display(Name = "Original Price")]
        public decimal? OriginaPrice { get; set; }

        [Required]
        [Range(0, 9999)]
        [Display(Name = "Sale Price")]
        public decimal? SalePrice { get; set; }

        public int CategoryId { get; set; }
        public int ConditionId { get; set; }

        public string Name { get; set; }

        [Range(2000, 2018)]
        public int? Year { get; set; }

        [Display(Name = "Upload Photo")]
        public HttpPostedFileBase UploadPhoto { get; set; }

        [StringLength(250)]
        public string Description { get; set; }


    }
}