using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Infrastructure.Context;
using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PageController : Controller
    {
        private readonly ProjectContext _context;

        public PageController(ProjectContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            //IQueryable<Page> pages = _context.Pages.OrderBy(x=> x.Sorting);
            IQueryable<Page> pages = from p in _context.Pages orderby p.Sorting select p;

            List<Page> pageList = await pages.ToListAsync();

            return View(pageList);

            //return View(await _context.Pages.OrderBy(x=> x.Sorting).ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            Page page = await _context.Pages.FirstOrDefaultAsync(x => x.Id == id);

            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Slug = page.Title.ToLower().Replace(" ", "-");
                page.Sorting = 100;

                var slug = await _context.Pages.FirstOrDefaultAsync(x => x.Slug == page.Slug);

                if (slug != null)
                {
                    ModelState.AddModelError("", "The page already exists..!");
                    return View(page);
                }

                _context.Add(page);
                await _context.SaveChangesAsync();

                TempData["Success"] = "The page has been added..!";

                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "The page hasn't been added..!";
                return View(page);
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            Page page = await _context.Pages.FindAsync(id);
            if (page == null)
            {
                NotFound();
            }

            return View(page);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Slug = page.Id == 1 ? "home" : page.Title.ToLower().Replace(" ", "-");

                var slug = await _context.Pages.Where(x => x.Id != page.Id).FirstOrDefaultAsync(x => x.Slug == page.Slug);

                if (slug != null)
                {
                    ModelState.AddModelError("", "The home page can't edit..!");
                    return View(page);
                }

                _context.Update(page);
                await _context.SaveChangesAsync();

                TempData["Success"] = "The page has been edit..!";

                return RedirectToAction("Edit", new { id = page.Id });
            }
            else
            {
                TempData["Error"] = "The page hasn't been edit..!";
                return View(page);
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            Page page = await _context.Pages.FindAsync(id);

            if (page == null)
            {
                TempData["Error"] = "The page does not exist..!";
            }
            else
            {
                //I.Yol
                //page.Status = Status.Passive;
                //page.DeleteDate = DateTime.Now;

                //II.Yol
                _context.Pages.Remove(page);

                //Her yolun uğraması gereken yer
                await _context.SaveChangesAsync();
                TempData["Success"] = "The page has been deleted..!";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ReOrder(int[] id)
        {
            int count = 1;

            foreach (var pageId in id)
            {
                Page page = await _context.Pages.FindAsync(pageId);
                page.Sorting = count;
                _context.Update(page);
                await _context.SaveChangesAsync();
                count++;
            }

            return Ok();
        }
    }
}