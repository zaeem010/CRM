using CRM.Data;
using CRM.Models;
using CRM.Models.VM;
using Microsoft.AspNetCore.Mvc;
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
            CRMDATA.City = "Multan";
            CRMDATA.Country = "Pakistan";
            var VM = new CRMVM
            {
                CRMDATA = CRMDATA,
                CRMDATAList = _context.CRMDATA.ToList(),
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
        //public async Task<ActionResult> SuggestAsync(bool highlights, bool fuzzy, string term)
        //{
        //    InitSearch();

        //    // Setup the suggest parameters.
        //    var options = new SuggestOptions()
        //    {
        //        UseFuzzyMatching = fuzzy,
        //        Size = 8,
        //    };

        //    if (highlights)
        //    {
        //        options.HighlightPreTag = "<b>";
        //        options.HighlightPostTag = "</b>";
        //    }

        //    // Only one suggester can be specified per index. It is defined in the index schema.
        //    // The name of the suggester is set when the suggester is specified by other API calls.
        //    // The suggester for the hotel database is called "sg", and simply searches the hotel name.
        //    var suggestResult = await _searchClient.SuggestAsync<Hotel>(term, "sg", options).ConfigureAwait(false);

        //    // Convert the suggested query results to a list that can be displayed in the client.
        //    List<string> suggestions = suggestResult.Value.Results.Select(x => x.Text).ToList();

        //    // Return the list of suggestions.
        //    return new JsonResult(suggestions);
        //}
    }
}
