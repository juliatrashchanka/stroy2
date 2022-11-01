﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stroy2.Data;
using stroy2.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;


namespace stroy2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ApplicationDbContext db;

        private UserManager <ApplicationDbContext> _user;
        //private ApplicationDbContext _context;
       
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context/*, UserManager <ApplicationDbContext> user*/)
        {
            db = context;
            _logger = logger;
            //_user = user;
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
            //var UserId = _userManager.GetUserId(User);

          //  var id =  User.Identity.Name;
            //var userName = user.id;
          
            //var listofOrders = db.Order.ToList();
            return View(await db.Order.ToListAsync());
        }
        //public async Task<IActionResult> Details(string work)
        //{
       
           
        //        Order ord = await db.Order.FirstOrDefaultAsync(p => p.Work == work);
        //        if (ord != null)
        //            return View(ord);
         
        //    return NotFound();
        //}



        [HttpGet]
        public IActionResult Create()
        {
            Order ord = new Order();
            return PartialView("OrderModelPartial", ord);
        }

        [HttpPost]
        public object Create(Guid id, /*string name,*/string work, string locality , string volume , string material )
        {
           
            Order ord = new Order() { 

                Id=id,
                //Name=name,
                Work=work,
                Locality=locality,  
                Volume=volume,
                Material=material,

            };

            db.Order.Add(ord);
            db.SaveChanges();

            return RedirectToAction("Orders");
        }

        //public IActionResult Edit(Guid id)
        //{
        //    var order=db.Order.FirstOrDefault(p => p.Id==id);
        //    return PartialView("EditOrderPartial", order);
        //}
        //[HttpPost]
        //public IActionResult Edit(Order ord)
        //{
        //    db.Order.Update(ord);
        //    db.SaveChanges();
        //    return PartialView("EditOrderPartial", ord);
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}