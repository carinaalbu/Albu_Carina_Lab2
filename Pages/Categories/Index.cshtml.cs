using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Albu_Carina_Lab2.Data;
using Albu_Carina_Lab2.Models;
using Albu_Carina_Lab2.Models.ViewModels;

namespace Albu_Carina_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Albu_Carina_Lab2.Data.Albu_Carina_Lab2Context _context;

        public IndexModel(Albu_Carina_Lab2.Data.Albu_Carina_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Categories { get;set; } = default!;
        public CategoriesIndexData CategoriesIndexData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }

        public async Task OnGetAsync(int? id, int? bookID)
        {
            if(_context.Category != null)
            {
                Categories = await _context.Category.ToListAsync();
            }

            CategoriesIndexData = new CategoriesIndexData();
            CategoriesIndexData.Categories = await _context.Category
            .Include(i => i.BookCategories)
            .ThenInclude(bc => bc.Book)
            .ThenInclude(b => b.Authors)
            .OrderBy(i => i.CategoryName)
            .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoriesIndexData.Categories.Where(i => i.ID == id.Value).Single();
                CategoriesIndexData.Books = category.BookCategories.Select(bc => bc.Book);
            }
        }
    }
}
