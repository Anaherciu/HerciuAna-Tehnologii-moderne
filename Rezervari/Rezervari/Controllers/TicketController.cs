using Microsoft.AspNetCore.Mvc;
using Rezervari.Data;
using Rezervari.Models;

namespace Rezervari.Controllers
{
    public class TicketController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


    }
    
}
