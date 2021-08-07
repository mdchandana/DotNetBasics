using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JqueryAjaxJson.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using JqueryAjaxJson.Models.Interfaces;
using JqueryAjaxJson.Models;

namespace JqueryAjaxJson.Controllers
{
    public class JqueryEmpLeaveController : Controller
    {
        private IEmployeePositionRepository _employeePositionRepository;
        private IEmployeeRepository _employeeRepository;
        private IEmployeeLeaveRepository _employeeLeaveRepository;

        public JqueryEmpLeaveController(IEmployeeRepository employeeRepository,
                                        IEmployeePositionRepository employeePositionRepository,
                                        IEmployeeLeaveRepository employeeLeaveRepository )
        {
            _employeePositionRepository = employeePositionRepository;
            _employeeRepository = employeeRepository;
            _employeeLeaveRepository = employeeLeaveRepository;
            
            
        }


        [HttpGet]
        public IActionResult Index()
        {


            var allEmployeesIdName1 = from emp in _employeeRepository.GetEmployees().ToList()
                                      orderby emp.Id
                                      select emp;



            var allEmployeesIdName2 = _employeeRepository.GetEmployees()
                                    .Select(emp => new Employee()
                                    {
                                        Id=emp.Id,
                                        Name=emp.Name
                                    }).ToList();





            var allEmployeesIdName3 = (from emp in _employeeRepository.GetEmployees().ToList()
                                       select new Employee()
                                       {
                                           Id = emp.Id,
                                           Name = emp.Name                                           
                                       }).ToList();


            var allEmployeesIdName4 = (from emp in _employeeRepository.GetEmployees().ToList()
                                       select new SelectListItem()
                                       {
                                            Value = emp.Id.ToString(),
                                            Text = emp.Name,
                                            Selected = (emp.Name == "") ? true : false
                                            
                                       }).ToList();



            var EmpLeaveVM = new EmpLeaveVM()
            {
                //SelectListEmpPositions = new SelectList(_employeePositionRepository.GetAllPositions(), "PositionCode", "Position",
                //                                        _employeePositionRepository.GetAllPositions()
                //                                        .Where(p => p.PositionCode == "EA").First()),

                //SelectListEmployees = new SelectList(new List<Employee>(), "Id", "Name")  //passing a empty employee SelectList

                //SelectListEmployees = new SelectList(_employeeRepository.GetEmployees(), "Id", "Name"),

                SelectListEmpPositions = GetEmployePositionsSelectListItems(),
                SelectListEmployees = new SelectList(allEmployeesIdName2, "Id", "Name"),
            };

            //EmpLeaveVM.SelectListEmpPositions.Where(x=>x.Value == "er")



            return View(EmpLeaveVM);
        }


        //IEnumerable<SelectListItem> GetEmployePositionsSelectListItems()
        SelectList GetEmployePositionsSelectListItems()
        {

            //with SelectList
            var positionSelectList = new SelectList(_employeePositionRepository.GetAllPositions(), "Id", "Position");
            foreach(SelectListItem item in positionSelectList.Items)
            {
                if(item.Value == "2")
                {
                    item.Selected = true;
                    break;
                }
            }



            //var positionSelectListItems = _employeePositionRepository.GetAllPositions()
            //    .Select(p => new SelectListItem()
            //    {
            //        Value = p.Id.ToString(),
            //        Text = p.Position,
            //        Selected = (p.Id.ToString() == "2") ? true : false
            //    });


            //return new SelectList(new List<EmployeePosition>());
            return positionSelectList;
            //return positionSelectListItems;
        }



        [HttpGet]
        public JsonResult GetEmployeesByPositioonId(int positionId)
        {

            var employees=_employeeRepository.GetEmployeesByPositionId(positionId)
                           .Select(emp => new Employee()
                           {
                                Id=emp.Id,
                                Name=emp.Name
                           }).ToList();


            return Json(employees);
        }




        [HttpPost]
        public IActionResult AddToList(EmpLeaveVM empLeaveVM)
        {
            return View();
        }

    }
}
