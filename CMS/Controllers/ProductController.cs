using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Infrastructure.Context;
using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProjectContext _context;
        public ProductController(ProjectContext context)
        {
            this._context=context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.OrderBy(x=> x.CreateDate).ToListAsync());
        }

        public async Task<IActionResult> ProductsByCategory(string categorySlug)
        {
            Category category = await _context.Categories.Where(x => x.Slug == categorySlug).FirstOrDefaultAsync();
            if (category == null) return RedirectToAction("Index");
            ViewBag.CategoryName = category.Name;
            ViewBag.CategorySlug = categorySlug;
            return View(await _context.Products.Where(x => x.CategoryId == category.Id).ToListAsync());

        }
    }
}
