using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class WorkerController : Controller
    {
        IWorkerService _workerService;
        IUserService _userService;
        ICompanyService _companyService;
        IManagerService _managerService;

        public WorkerController(IWorkerService workerService, IUserService userService, ICompanyService companyService, IManagerService managerService)
        {
            _workerService = workerService;
            _userService = userService;
            _companyService = companyService;
            _managerService = managerService;
        }
        public IActionResult Index()
        {
            var workers = _workerService.GetFull();
            return View(workers);
        }
        [HttpGet]
        public IActionResult AddWorker()
        {
            List<SelectListItem> users = new List<SelectListItem>(from x in _userService.GetAllActive()
                                                                  select new SelectListItem
                                                                  {
                                                                      Text = x.FirstName + " " + x.LastName,
                                                                      Value = x.Id.ToString()

                                                                  }).ToList();
            ViewBag.Users = users;
            List<SelectListItem> managers = new List<SelectListItem>(from x in _managerService.GetFull()
                                                                           select new SelectListItem
                                                                           {
                                                                               Text = x.User.FirstName + " " + x.User.LastName,
                                                                               Value = x.Id.ToString()

                                                                           }).ToList();
            ViewBag.Managers = managers;
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
        public IActionResult AddWorker(Entities.Concrete.Worker worker)
        {
            _workerService.Add(worker);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult UpdateWorker(int id)
        {
            var workerToUpdate = _workerService.GetById(id);

            List<SelectListItem> usersUpdate = new List<SelectListItem>(from x in _userService.GetAllActive()
                                                                        select new SelectListItem
                                                                        {
                                                                            Text = x.FirstName + " " + x.LastName,
                                                                            Value = x.Id.ToString()

                                                                        }).ToList();
            ViewBag.UsersUpdate = usersUpdate;
            List<SelectListItem> managersUpdate = new List<SelectListItem>(from x in _managerService.GetFull()
                                                                        select new SelectListItem
                                                                        {
                                                                            Text = x.User.FirstName + " " + x.User.LastName,
                                                                            Value = x.Id.ToString()

                                                                        }).ToList();
            ViewBag.ManagersUpdate = managersUpdate;
            List<SelectListItem> companiesUpdate = new List<SelectListItem>(from x in _companyService.GetAll()
                                                                            select new SelectListItem
                                                                            {
                                                                                Text = x.CompanyName,
                                                                                Value = x.CompanyId.ToString()

                                                                            }).ToList();
            ViewBag.CompaniesUpdate = companiesUpdate;
            return View(workerToUpdate);
        }
        [HttpPost]
        public IActionResult UpdateWorker(Entities.Concrete.Worker worker)
        {
            _workerService.Update(worker);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult DeleteWorker(int id)
        {
            var workerToDelete = _workerService.GetById(id);
            _workerService.Delete(workerToDelete);
            return RedirectToAction("Index");
        }
    }
}
