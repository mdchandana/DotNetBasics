using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleerenCore.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        private List<Category> _categoryList;

        public MockCategoryRepository()
        {
            _categoryList = new List<Category>()
            {
                new Category { CategoryId=1, CategoryName="Fruit pies", Description="All-fruity pies"},
                new Category {CategoryId=2, CategoryName="Cheese cakes", Description="Cheesy all the way"},
                new Category {CategoryId=3, CategoryName="Seasonal pies", Description="Get in the mood for a seasonal pie"}
            };
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryList;
        }
    }
}
