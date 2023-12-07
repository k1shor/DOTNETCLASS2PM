using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Webapp2pm.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }

        
    }
}
