using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Infrastructure.Context;
using CMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Controllers
{
    public class PageController : Controller
    {
        private readonly ProjectContext _context;
        public PageController(ProjectContext context)
        {
            this._context =context;
        }
        // GET: /page Or /slug
        public async Task<ActionResult> Page(string slug)
        {
            if (slug== null)
            {
                return View(await _context.Pages.Where(x => x.Slug == "home").FirstOrDefaultAsync());
            }
            Page page = await _context.Pages.Where(x => x.Slug == slug).FirstOrDefaultAsync();
            if (page == null)
            {
                return NotFound();
            }
            return View(page);
        }



















        //// GET: PageController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: PageController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: PageController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: PageController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: PageController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: PageController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: PageController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
