using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ManagerController : Controller
    {
        IManagerService _managerService;
        IUserService _userService;
        ICompanyService _companyService;

        public ManagerController(IManagerService workerService, IUserService userService, ICompanyService companyService)
        {
            _managerService = workerService;
            _userService = userService;
            _companyService = companyService;
        }
        public IActionResult Index()
        {
            var managers = _managerService.GetFull();
            return View(managers);
        }
        [HttpGet]
        public IActionResult AddManager()
        {
            List<SelectListItem> users = new List<SelectListItem>(from x in _userService.GetAllActive()
                                                                  select new SelectListItem
                                                                  {
                                                                      Text = x.FirstName + " " + x.LastName,
                                                                      Value = x.Id.ToString()

                                                                  }).ToList();
            ViewBag.Users = users;
            List<SelectListItem> companies = new List<SelectListItem>(from x in _companyService.GetAll()
                                                                  select new SelectListItem
                                                                  {
                                                                      Text = x.CompanyName,
                                                                      Value = x.CompanyId.ToString()

                                                                  }).ToList();
            ViewBag.Companies = companies;
            return View();
        }

        [HttpPost]
        public IActionResult AddManager(Entities.Concrete.Manager manager)
        {
            _managerService.Add(manager);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult UpdateManager(int id)
        {
            var managerToUpdate = _managerService.GetById(id);

            List<SelectListItem> usersUpdate = new List<SelectListItem>(from x in _userService.GetAllActive()
                                                                        select new SelectListItem
                                                                        {
                                                                            Text = x.FirstName + " " + x.LastName,
                                                                            Value = x.Id.ToString()

                                                                        }).ToList();
            ViewBag.UsersUpdate = usersUpdate;
            List<SelectListItem> companiesUpdate = new List<SelectListItem>(from x in _companyService.GetAll()
                                                                      select new SelectListItem
                                                                      {
                                                                          Text = x.CompanyName,
                                                                          Value = x.CompanyId.ToString()

                                                                      }).ToList();
            ViewBag.CompaniesUpdate = companiesUpdate;
            return View(managerToUpdate);
        }
        [HttpPost]
        public IActionResult UpdateManager(Entities.Concrete.Manager manager)
        {
            _managerService.Update(manager);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult DeleteManager(int id)
        {
            var managerToDelete = _managerService.GetById(id);
            _managerService.Delete(managerToDelete);
            return RedirectToAction("Index");
        }
    }
}
