using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrickAuctioner.Models
{
    public class Auction
    {
        [Key]
        public int AuctionId { get; set; }
        [Required(ErrorMessage ="This Field is Required")] 
        public decimal BasePrice { get; set; }
        public decimal SoldPrice { get; set; }

      




    }
}
