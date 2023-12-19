using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        public String? Street { get; set; }
        public String? City { get; set; }
        public String? State { get; set; }
        public String? PostalCode { get; set; }
        public String? Country { get; set; }
        public String? Phone { get; set; }
        public DateOnly DateOfBirth{ get; set; }
        public String Gender { get; set; }
    }
}
