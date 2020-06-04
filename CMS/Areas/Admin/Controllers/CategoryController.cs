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
    public class CategoryController : Controller
    {
        private readonly ProjectContext _context;

        public CategoryController(ProjectContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.OrderBy(x=> x.Sorting).ToListAsync());
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                category.Slug = category.Name.ToLower().Replace(" ", "-");
                category.Sorting = 100;

                var slug = await _context.Categories.FirstOrDefaultAsync(x => x.Slug == category.Slug);

                if (slug != null)
                {
                    ModelState.AddModelError("", "The category already exists..!");
                    return View(category);
                }

                _context.Add(category);
                await _context.SaveChangesAsync();

                TempData["Success"] = "The category has been added..!";

                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "The category hasn't been added..!";
                return View(category);
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            Category category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (ModelState.IsValid)
            {
                category.Slug = category.Name.ToLower().Replace(" ", "-");

                var slug = await _context.Categories.Where(x => x.Id != id).FirstOrDefaultAsync(x => x.Slug == category.Slug);

                if (slug != null)
                {
                    ModelState.AddModelError("", "The category already  exsists..!");
                    return View(category);
                }

                _context.Update(category);
                await _context.SaveChangesAsync();

                TempData["Success"] = "The category has been edited..!";

                return RedirectToAction("Edit", new { id });
            }
            else
            {
                TempData["Error"] = "The category hasn't been edited..!";
                return View(category);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            Category category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                TempData["Error"] = "The category does not exsist..!";
            }
            else
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                TempData["Success"] = "The category has been removed..!";
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Reorder(int[] id)
        {
            int count = 1;

            foreach (var categoryId in id)
            {
                Category category = await _context.Categories.FindAsync(categoryId);
                category.Sorting = count;
                await _context.SaveChangesAsync();
                count++;
            }

            return Ok();
        }
    }
}