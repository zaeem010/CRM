using CRM.Data;
using CRM.Data.Repository;
using CRM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var List = _context.User.ToList();
            return View(List);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User User)
        {
            var d = new Repo<string>().GetMaxId("SELECT COUNT(*) AS Expr1 FROM [User] WHERE (UserName = '"+  User.UserName+"')");
            if (d == 0) 
            {
                _context.User.Add(User);
                _context.SaveChanges();
            }
            else
            {
                TempData["Duplicate"] = "User With This Name ("+ User.UserName +") Already Exists.";
            }
            return RedirectToAction("Create");
        }
        public IActionResult Delete(int id)
        {
            var d = _context.User.SingleOrDefault(c => c.id == id);
            _context.Remove(d);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Setting()
        {
            var d = _context.User.FromSqlRaw("SELECT * FROM [User] WHERE (id = '"+ HttpContext.Session.GetString("Userid") +"')").SingleOrDefault();
            return View(d);
        }
        [HttpPost]
        public IActionResult Setting(User User, string NewPass)
        {
            var d = _context.User.FromSqlRaw("SELECT * FROM [User] WHERE (id = '" + HttpContext.Session.GetString("Userid") + "')").SingleOrDefault();
            if (User.Password != d.Password)
            {
                TempData["Invalid"] = "Password Does Not Match...";
                return RedirectToAction("Setting");
            }
            else
            {
                var db = _context.User.FromSqlRaw("SELECT * FROM [User] WHERE (id = '" + HttpContext.Session.GetString("Userid") + "')").SingleOrDefault();
                db.Name = User.Name;
                db.UserName = User.UserName;
                db.Password = NewPass;
                _context.SaveChanges();
                return RedirectToAction("Index","Home");
            }
        }
    }
}
