using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleerenCore.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private AppDbContext _context;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
