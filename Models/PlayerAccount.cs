using System.ComponentModel.DataAnnotations;

namespace CrickAuctioner.Models
{
    public class PlayerAccount
    {
        [Key]
        public int PlayerId { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name ="Player Name ")]
        public string? PlayerName { get; set; }

        [Required(ErrorMessage ="This Field is Required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Display(Name = "Player Email ")]
        public string? PlayerEmail { get; set; }

        [Display(Name = "Player Date of Birth ")]
        public DateTime PlayerDOB { get; set; }

        [Required(ErrorMessage ="Password is Required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Compare("Password",ErrorMessage ="Please confirm your password")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage ="This Field is Required")]
        [Display(Name = "Player Country ")]
        public string? PlayerCountry { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;



    }
}
