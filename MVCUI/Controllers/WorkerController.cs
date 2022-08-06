using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCUI.Controllers
{
    public class WorkerController : Controller
    {
        IWorkerService _workerService;
        ICompanyService _companyService;
        IManagerService _managerService;



        public WorkerController(IWorkerService managerService)
        {
            _workerService = managerService;
        }
        public IActionResult GetList()
        {
            var workers = _workerService.GetAllWithFullDetails();
            return View(workers);
        }
        [HttpGet]
        public IActionResult AddWorker()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddWorker(Worker worker)
        {
            //ViewBag.companies = CompanyList();
            //ViewBag.managers =ManagerListByCompany(1);
            _workerService.Add(worker);
            return RedirectToAction("GetList");
        }


        [HttpGet]
        public IActionResult UpdateWorker(int id)
        {
            var workerToUpdate = _workerService.GetById(id);
            return View(workerToUpdate);
        }
        [HttpPost]
        public IActionResult UpdateWorker(Worker worker)
        {
            _workerService.Update(worker);
            return RedirectToAction("GetList");
        }


        [HttpGet]
        public IActionResult DeleteWorker(int id)
        {
            var workerToDelete = _workerService.GetById(id);
            _workerService.Delete(workerToDelete);
            return RedirectToAction("GetList");
        }

        //public List<SelectListItem> CompanyList() 
        //{
        //    var result = (from x in _companyService.GetAll()
        //                  select new SelectListItem
        //                  {
        //                      Text = x.CompanyName,
        //                      Value = x.CompanyId.ToString()
        //                  }).ToList();
        //        return result;
        //}
        //public List<SelectListItem> ManagerListByCompany(int id)
        //{
        //    var result = (from x in _managerService.GetAllByCompany(id)
        //                  select new SelectListItem
        //                  {
        //                      Text = x.Name+ " " + x.Surname,
        //                      Value = x.PersonId.ToString()
        //                  }).ToList();
        //    return result;
        //}
    }
}
