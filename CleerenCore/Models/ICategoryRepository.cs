using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleerenCore.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
    }
}
