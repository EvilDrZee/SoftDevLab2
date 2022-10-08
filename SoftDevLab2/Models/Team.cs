using System.ComponentModel.DataAnnotations;

namespace SoftDevLab2.Models
{
    public class Team
    {
        [Required]
        public int Id { get; set; }

        [Required, Display(Name = "Team Name")]
        public string TeamName { get; set; }

        [Required, Display(Name = "Email Address")]
        public string Email { get; set; }

        public DateTime? EstablishedDate { get; set; }
    }
}
