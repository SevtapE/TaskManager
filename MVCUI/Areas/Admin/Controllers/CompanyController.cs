using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVCUI.Areas.Admin.Controllers
{
   
    [Area("Admin")]
    public class CompanyController : Controller
    {
        ICompanyService _companyService;

       
        public CompanyController(ICompanyService companyService) 
        {
            _companyService = companyService;
        }
    
        public IActionResult Index()
        {
          var companies= _companyService.GetAll();
            return View(companies);
        }
        [HttpGet]
        public IActionResult AddCompany()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCompany(Company company)
        {
            _companyService.Add(company);
            return RedirectToAction("Index","Company");
        }
        [HttpGet]
        public IActionResult UpdateCompany(int id)
        {
            var companyToEdit = _companyService.GetById(id);
            return View(companyToEdit);
        }
        [HttpPost]
        public IActionResult UpdateCompany(Company company)
        {
            _companyService.Update(company);
            return RedirectToAction("Index", "Company");

        }
        [HttpGet]
        public IActionResult DeleteCompany(int id)
        {
            var companyToDelete = _companyService.GetById(id);
            _companyService.Delete(companyToDelete);
            return RedirectToAction("Index", "Company");

        }

        [HttpGet]
        public IActionResult GetCompanyEmployees(int id)
        {
            var companyEmployees = _companyService.GetWithEmployees(id);
            return PartialView(companyEmployees);
        }


    }
}
