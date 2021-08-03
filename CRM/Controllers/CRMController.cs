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
        public IActionResult Index(CRMDATA CRMDATA, CRMDATAChild CRMDATAChild)
        {
            //CRMDATA.City = "Multan";
            CRMDATA.Country = "Pakistan";
            var Con = new Repo<Contacts>().GetAllData("SELECT Mob as Contact FROM CRMDATA");
            var VM = new CRMVM
            {
                CRMDATA = CRMDATA,
                CRMDATAChild = CRMDATAChild,
                Contacts= Con.ToList(),
            };
            return View(VM);
        }
        
        [HttpPost,ActionName("Index")]
        public IActionResult Save(CRMDATA CRMDATA ,CRMDATAChild CRMDATAChild)
        {
            CRMDATA.Userid = "1";
            CRMDATAChild.Userid = "1";
            CRMDATAChild.DateTime = DateTime.Now;
            CRMDATAChild.Mob = CRMDATA.Mob;
            var Count = new Repo<string>().GetMaxId("SELECT COUNT(*) AS Expr1 FROM CRMDATA WHERE (Mob = '03075378081')");
            if (Count == 0)
            {
                _context.CRMDATA.Add(CRMDATA);
                _context.CRMDATAChild.Add(CRMDATAChild);
            }
            else
            {
                _context.CRMDATAChild.Add(CRMDATAChild);
                var db = _context.CRMDATA.SingleOrDefault(c=>c.Mob == CRMDATA.Mob);
                db.Mob = CRMDATA.Mob;
                db.CusName = CRMDATA.CusName;
                db.City = CRMDATA.City;
                db.Country = CRMDATA.Country;
                db.Address = CRMDATA.Address;
                db.Email = CRMDATA.Email;
                db.WebUrl = CRMDATA.WebUrl;
            }
            
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
            var List = new Repo<CRMVMQ>().GetAllData("SELECT * FROM CRMDATAChild WHERE (Mob = '" + id + "')").ToList();
            return Json(List);
        }
    }
}
