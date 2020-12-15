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
        public async Task<IActionResult> Search(ViewSearcher SearchData)
        {
            SearchData.Players = new List<Form>();
            foreach (Form Anketa in db.Forms.ToList()) {
                if (Anketa.System == SearchData.SearchingSystem)
                {
                    SearchData.Players.Add(Anketa);
                };
            };
            return View("List", SearchData);
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
            return RedirectToAction("CreateConfirm");
        }
        public IActionResult CreateConfirm()
        {
            return View();
        }
    }
}
