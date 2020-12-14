using Test.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Test.ViewModels;

namespace Test.Controllers
{
    public class FormsController : Controller
    {
        private ApplicationContext db;
        public FormsController(ApplicationContext context)
        {
            db = context;
        }
        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Search(ViewSearcher Searcher)
        {
            //db.ViewSearcher.Add(Searcher);
            await db.SaveChangesAsync();
            return Redirect("~/List");
        }
        public async Task<IActionResult> List()
        {
            return View(await db.Forms.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Form form)
        {
            db.Forms.Add(form);
            await db.SaveChangesAsync();
            return RedirectToAction("CreateConfirm"); ;
        }
        public IActionResult CreateConfirm()
        {
            return View();
        }
    }
}
