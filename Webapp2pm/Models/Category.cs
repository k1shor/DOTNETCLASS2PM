using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Webapp2pm.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required(ErrorMessage ="Category Name is required")]
        [MinLength(3,ErrorMessage ="Category name must be at least 3 characters")]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        
    }
}
