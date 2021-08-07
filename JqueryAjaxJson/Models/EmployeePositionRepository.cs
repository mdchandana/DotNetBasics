using JqueryAjaxJson.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JqueryAjaxJson.Models
{
    public class EmployeePositionRepository : IEmployeePositionRepository
    {
        private AppDbContext _context;

        public EmployeePositionRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }


        public List<EmployeePosition> GetAllPositions()
        {
           return _context.EmployeePositions.ToList();
        }
    }
}
