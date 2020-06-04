using CMS.Infrastructure.Context;
using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ProjectContext _context;
        public CategoryViewComponent(ProjectContext context)
        {
            this._context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await GetCategoriesAsync();
            return View(categories);
        }

        private async Task<List<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.OrderBy(x => x.Sorting).ToListAsync();
        }
    }
}
