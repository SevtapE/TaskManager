using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MVCUI.Controllers
{
    public class ManagerController : Controller
    {
        IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }
        public IActionResult GetList()
        {
            var managers = _managerService.GetAll();
            return View(managers);
        }
        [HttpGet]
        public IActionResult AddManager()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddManager(Manager manager)
        {
            _managerService.Add(manager);
            return RedirectToAction("GetList");
        }


        [HttpGet]
        public IActionResult UpdateManager(int id)
        {
            var managerToUpdate = _managerService.GetById(id);
            return View(managerToUpdate);
        }
        [HttpPost]
        public IActionResult UpdateManager(Manager manager)
        {
            _managerService.Update(manager);
            return RedirectToAction("GetList");
        }


        [HttpGet]
        public IActionResult DeleteManager(int id)
        {
            var managerToDelete = _managerService.GetById(id);
            _managerService.Delete(managerToDelete);
            return RedirectToAction("GetList");
        }
    }
}
