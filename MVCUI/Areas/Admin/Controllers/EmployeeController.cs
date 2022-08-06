using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MVCUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class EmployeeController : Controller
    {
        IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            var employees = _employeeService.GetAll();
            return View(employees);
        }

        public IActionResult GetByCompany(int id)
        {

            var employees = _employeeService.GetFullByCompany(id);
          
            return View(employees);
        }
        //[HttpGet]
        //public IActionResult AddManager()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult AddManager(Entities.Concrete.Manager manager)
        //{
        //    _managerService.Add(manager);
        //    return RedirectToAction("Index");
        //}


        //[HttpGet]
        //public IActionResult UpdateManager(int id)
        //{
        //    var managerToUpdate = _managerService.GetById(id);
        //    return View(managerToUpdate);
        //}
        //[HttpPost]
        //public IActionResult UpdateManager(Entities.Concrete.Manager manager)
        //{
        //    _managerService.Update(manager);
        //    return RedirectToAction("Index");
        //}


        //[HttpGet]
        //public IActionResult DeleteManager(int id)
        //{
        //    var managerToDelete = _managerService.GetById(id);
        //    _managerService.Delete(managerToDelete);
        //    return RedirectToAction("Index");
        //}
    }
}
