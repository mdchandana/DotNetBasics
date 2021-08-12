using CleerenCore.Models;
using CleerenCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleerenCore.Controllers
{
    public class PieController : Controller
    {
        private ICategoryRepository _categoryRepository;
        private IPieRepository _pieRepository;
        

        public PieController(ICategoryRepository categoryRepository,IPieRepository pieRepository)
        {
            _categoryRepository = categoryRepository;
            _pieRepository = pieRepository;          

        }

        [HttpGet]
        public IActionResult Index()
        {          

            PieListVM pieListVM = new PieListVM()
            { 
                Pies=_pieRepository.GetAllPies().ToList(),
                CurrentCategory="Cheese Cakes"
            };

            return View(pieListVM);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var pie = _pieRepository.GetPieById(id.Value);

            return View(pie);
        }

    }
}
