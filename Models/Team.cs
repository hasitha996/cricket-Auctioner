using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace CrickAuctioner.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required(ErrorMessage ="This Field is Required")]
        [Display(Name = "Team Name")]
        public string? TeamName { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "Team Owner Name")]
        public string? TeamOwner { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [Column(TypeName ="decimal(18,4)")]
        [Display(Name = "Budget")]
        public decimal TeamBudget { get; set; }

        public int CreatedBy { get; set; } 
        public DateTime CreatedOn { get; set; }=DateTime.Now;

    }
}
