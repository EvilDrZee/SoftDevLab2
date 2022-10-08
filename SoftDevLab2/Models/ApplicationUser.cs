using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SoftDevLab2.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; } = "John";

        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; } = "Doe";

        public DateTime? BirthDate { get; set; }
    }
}
