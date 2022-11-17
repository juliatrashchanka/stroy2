using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stroy2.Data;
using stroy2.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace stroy2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ApplicationDbContext db;

      private UserManager <IdentityUser> _user;
      //  private ApplicationDbContext _context;
       
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager <IdentityUser> user)
        {
            db = context;
            _logger = logger;
            _user = user;
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

        public IActionResult PartialFeed(string client, string workname, string period, string comment, string contacts, bool confirm = false)
        {
            Feedbacks feed = new Feedbacks
            {
                Client = client,
                WorkName = workname,
                Period = period,
                Comment = comment,
                Contacts = contacts,


            };

            db.Feedbacks.Add(feed);
            db.SaveChanges();
            string test = "success";
            //return Json(test);
            return Json(test);
        }
        public async Task<IActionResult> Feedback()
        {
            return View(await db.Feedbacks.ToListAsync());
        }
       
        //public IActionResult Feedback()
        //{
        //    return View();
        //}
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
        [Authorize]
        public IActionResult Catalog()
        {
            return View();
        }

        public IActionResult PartialFeed()
        {
            return PartialView();
        }

        

        [Authorize]
        public async Task<IActionResult> Orders()
        {
            //var listofOrders = db.Order.ToList();
            //return View(listofOrders); //(for admin)
           

            ClaimsPrincipal currentUser = this.User;
            string currentUserName=currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
     

            var listofOrders = db.Order.ToList();
          
            bool exists = listofOrders.Exists(p =>p.UserName==currentUserName);

           List <Order> listCurrentUser = listofOrders.FindAll(p => p.UserName == currentUserName);

            return View(listCurrentUser);
        }
     
        public async Task<IActionResult> PartialDetails(Guid? id)
        {
            if (id != null)
            {
                Order ord = await db.Order.FirstOrDefaultAsync(p => p.Id == id);
                if (ord != null)
                    return PartialView(ord);
            }
            return NotFound();
        }



        //[HttpPost]
        //public object Create(Guid id, /*string name,*/string work, string locality , string volume , string material )
        //{

        //    Order ord = new Order() { 

        //        Id=id,
        //        //Name=name,
        //        Work=work,
        //        Locality=locality,  
        //        Volume=volume,
        //        Material=material,

        //    };

        //    db.Order.Add(ord);
        //    db.SaveChanges();

        //    return RedirectToAction("Orders");
        //}
        [HttpGet]
        public IActionResult Create()
        {
     

            return PartialView("OrderModelPartial");
        }
        [HttpPost]
        public JsonResult Create(Guid id, /*string name,*/string work, string locality, string volume, string material)
        {
            ClaimsPrincipal currentUser = this.User;
            string currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            Order ord = new Order
            {

                Id = id,
                UserName = currentUserName,
                Work = work,
                Locality = locality,
                Volume = volume,
                Material = material,

            };
            db.Order.Add(ord);
             db.SaveChanges();
            string test = "success";
          
            return Json(test);
        }

        [HttpGet]
        public JsonResult GetOrder()
        {



            ClaimsPrincipal currentUser = this.User;
            string currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;


            var listofOrders = db.Order.ToList();

            bool exists = listofOrders.Exists(p => p.UserName == currentUserName);

            List<Order> listCurrentUser = listofOrders.FindAll(p => p.UserName == currentUserName);

            //   return View(listCurrentUser);
            // var json = JSON.stringify(listCurrentUser);
            var json= JsonSerializer.Serialize(listCurrentUser);

            //return Json(test);
            return Json(json);
        }

        public async Task<IActionResult> EditOrderPartial(Guid? id)
        {
            if (id != null)
            {
                Order ord = await db.Order.FirstOrDefaultAsync(p => p.Id == id);
                if (ord != null)
                    return PartialView(ord);
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> EditOrderPartial(Order ord)
        {
            ClaimsPrincipal currentUser = this.User;
            ord.UserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            db.Order.Update(ord);
            await db.SaveChangesAsync();
            return RedirectToAction("Orders");
        }

        [HttpGet]
        [ActionName("DeleteOrder")]
        public async Task<IActionResult> ConfirmDelete(Guid? id)
        {
            if (id != null)
            {
               Order ord = await db.Order.FirstOrDefaultAsync(p => p.Id == id);
                if (ord != null)
                    return PartialView(ord);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrder(Guid? id)
        {
            if (id != null)
            {
                Order ord = await db.Order.FirstOrDefaultAsync(p => p.Id == id);
                if (ord != null)
                {
                    db.Order.Remove(ord);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Orders");
                }
            }
            return NotFound();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}