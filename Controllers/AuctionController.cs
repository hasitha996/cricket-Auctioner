using Microsoft.AspNetCore.Mvc;

namespace CrickAuctioner.Controllers
{
    public class AuctionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
