using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Microsoft.AspNetCore.Mvc;

namespace MVCUI.Controllers
{
    public class PersonController : Controller
    {
        IPersonService _personService;
        IEmployeeService _employeeService;

        public PersonController(IPersonService personService, IEmployeeService employeeService)
        {
            _personService = personService;
            _employeeService = employeeService;
        }
        public IActionResult GetEmployees()
        {
          var employees=  _employeeService.GetAll();
            return View();
        }
    }
}
