using CRM.Data;
using CRM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
                return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User User)
        {
            string dir = "";
            if (ModelState.IsValid)
            {
                var obj = _context.User.FromSqlRaw("SELECT * FROM [User] WHERE UserName ='" + User.UserName + "' AND Password ='" + User.Password + "' ").FirstOrDefault();
                if (obj != null)
                {
                    HttpContext.Session.SetString("Userid", obj.id.ToString());
                    HttpContext.Session.SetString("UserName", obj.Name.ToString());
                    dir = "Index";
                }
                else
                {
                    TempData["Invalid"] = "Invalid Login Details";
                    dir = "Login";
                }
            }
            return RedirectToAction(dir);
        }
        public ActionResult LogOut()
        {
            string id = "";
            HttpContext.Session.SetString("Userid", id);
            return RedirectToAction("Login");
        }
        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
