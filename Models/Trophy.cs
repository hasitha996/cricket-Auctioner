using System.ComponentModel.DataAnnotations;

namespace CrickAuctioner.Models
{
    public class Trophy
    {
        public int TrophyId { get; set; }

        [Required(ErrorMessage ="This field is Required")]
        [Display(Name = "Trophy Name")]
        public string? TrophyName { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [Display(Name = "Trophy Year")]
        public int TrophyYear { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
       
    }
}
