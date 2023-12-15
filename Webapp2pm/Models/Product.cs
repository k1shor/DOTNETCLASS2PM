using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webapp2pm.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Product name is required.")]
        [MinLength(3,ErrorMessage ="Product name must be at least 3 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Product Description is required.")]
        [MinLength(20,ErrorMessage ="Description must be at least 20 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Product price is required")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$",ErrorMessage ="Invalid value for price")]
        public double Price { get; set; }
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        [ValidateNever]
        public Category Category { get; set; }
        [Required(ErrorMessage ="Count in stock is required")]
        public int Stock { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
