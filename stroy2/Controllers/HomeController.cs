using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using stroy2.Data;
using stroy2.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace stroy2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ApplicationDbContext db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            db = context;
            _logger = logger;
        }

        [HttpPost]
        public JsonResult GetData(string name, string lastname, string email, string number, string city, string letter)
        {
            Consult cons = new Consult
            {

                Name = name,
                LastName = lastname,
                Email = email,
                Number = number,
                City = city,
                Letter = letter

            };

            db.Consult.Add(cons);
            db.SaveChanges();
            string test = "success";
            //return Json(test);
            return Json(test);
        }
        public IActionResult Index(/*Consult test*/)
        {
            //db.Consult.Add(test);
            //db.SaveChanges();
            return View();
        }
    
        public IActionResult Feedback()
        {
            return View();
        }
        public IActionResult Projects()
        {
            return View();
        }
        public IActionResult Documents()
        {
            return View();
        }
        public IActionResult Contacts()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}