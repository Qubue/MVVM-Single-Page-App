using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvvmData
{
    public class TrainingProduct
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage ="Product name must be filled in.")]
        [Display(Description ="Product Name")]
        [StringLength(150,MinimumLength =4,ErrorMessage ="Product Name must be greater than {2} characters and less than {1} characters")]
        public string ProductName { get; set; }

        //[Range(typeof(DateTime),"01/01/2000/","31/12/2020",ErrorMessage ="Introduction date must be between {1} and {2}")]
        [Display(Description = "Introduction Date")]
        public DateTime IntroductionDate { get; set; }

        [Required(ErrorMessage ="Url must be filled in")]
        [Display(Description = "URL")]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Url must be greater than {2} characters and less than {1} characters")]
        public string Url { get; set; }

        [Required(ErrorMessage = "Url must be filled in")]
        [Range(1,9999,ErrorMessage ="Price must be between {1} and {2}")]
        public decimal Price { get; set; }
    }
}
