using CRM.Data;
using CRM.Data.Repository;
using CRM.Models;
using CRM.Models.Raw;
using CRM.Models.VM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Controllers
{
    public class CRMController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CRMController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(CRMDATA CRMDATA)
        {
            //CRMDATA.City = "Multan";
            CRMDATA.Country = "Pakistan";
            var Con = new Repo<Contacts>().GetAllData("SELECT Mob as Contact FROM CRMDATA");
            var VM = new CRMVM
            {
                CRMDATA = CRMDATA,
                CRMDATAList = _context.CRMDATA.ToList(),
                Contacts= Con.ToList(),
            };
            return View(VM);
        }
        
        [HttpPost,ActionName("Index")]
        public IActionResult Save(CRMDATA CRMDATA)
        {
            CRMDATA.Userid = "1";
            CRMDATA.DateTime = DateTime.Now;
            _context.CRMDATA.Add(CRMDATA);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Action(string id)
        {
            var Mobs = _context.CRMDATA.FromSqlRaw("SELECT * FROM CRMDATA WHERE (Mob = '" + id + "')").ToList();
            return Json(Mobs);
        }
        public IActionResult GetCRMList(string id)
        {
            var List = new Repo<CRMVMQ>().GetAllData("SELECT Userid, Remarks, DateTime FROM CRMDATA WHERE (Mob = '" + id + "')").ToList();
            return Json(List);
        }
    }
}
