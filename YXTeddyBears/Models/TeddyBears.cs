using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YXTeddyBears.Models
{
    public class TeddyBears
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        [DataType(DataType.Currency)]
        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string Material { get; set; }

        [Display(Name = "Height in cm")]
        [Required]
        public decimal Height { get; set; }

        [Display(Name = "Weight in grams")]
        [Required]
        public decimal Weight { get; set; }

        [Required]
        public string Manufacturer { get; set; }


        //The correct format for the ImageURL
        [Display(Name = "Image")]
        [RegularExpression(@"^\~\/(\bimg\b)\/+[A-Za-z0-9]+\.(?:jpg|gif|png)$")]
        public string ImageURL { get; set; }
    }
}
