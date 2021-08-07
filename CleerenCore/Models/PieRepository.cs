using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleerenCore.Models
{
    public class PieRepository : IPieRepository
    {
        private AppDbContext _context;

        public PieRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }


        public IEnumerable<Pie> GetAllPies()
        {
            return _context.Pies.ToList();
        }

        public Pie GetPieById(int pieId)
        {
            return _context.Pies.FirstOrDefault(p => p.PieId == pieId);
        }

        public IEnumerable<Pie> GetPiesOftheWeek()
        {
            return _context.Pies
                   .Include(p => p.Category)
                   .Where(p => p.IsPieOfTheWeek);
        }
    }
}
