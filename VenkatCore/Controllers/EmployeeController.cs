using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VenkatCore.Models;
using VenkatCore.ViewModels;

namespace VenkatCore.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var empList = _employeeRepository.GetEmployees();


            return View(empList);
        }


        [HttpGet]
        public ViewResult Details(int? id)
        {
            var employee = _employeeRepository.GetEmployee(id.Value);

            //have to pass empCreateVM
            var empCreateVM = new EmpCreateVM()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Gender = employee.Gender
            };

            return View(empCreateVM);
        }


        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(EmpCreateVM empCreateVM)
        {
            if(ModelState.IsValid)
            {
                var employee = new Employee()
                {
                    Name = empCreateVM.Name,
                    Email = empCreateVM.Email,
                    Gender = empCreateVM.Gender
                };

                _employeeRepository.AddEmployee(employee);

                return RedirectToAction("Index");
            }
            

            return View(empCreateVM);
        }



        [HttpGet]
        public ViewResult Edit(int? id)
        {
            var employee = _employeeRepository.GetEmployee(id.Value);

            //have to pass empCreateVM
            var empCreateVM = new EmpCreateVM()
            {
                Id= employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Gender = employee.Gender
            };


            return View(empCreateVM);
        }



        [HttpPost]
        public IActionResult Edit(EmpCreateVM empCreateVM)
        {
            if(ModelState.IsValid)
            {
                var foundEmployee = _employeeRepository.GetEmployee(empCreateVM.Id);
                if (foundEmployee == null)
                    return NotFound();

                foundEmployee.Name = empCreateVM.Name;
                foundEmployee.Email = empCreateVM.Email;
                foundEmployee.Gender = empCreateVM.Gender;

                _employeeRepository.EditEmployee(foundEmployee);

                return RedirectToAction("Index");
            }

            return View(empCreateVM);
        }





        [HttpGet]
        public ViewResult Delete(int? id)
        {
            var employee = _employeeRepository.GetEmployee(id.Value);

            //have to pass empCreateVM
            var empCreateVM = new EmpCreateVM()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Gender = employee.Gender
            };
            return View(empCreateVM);
        }




        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete_Post(int? id)
        {
            _employeeRepository.DeleteEmployee(id.Value);

            return RedirectToAction("Index");
        }

    }
}
