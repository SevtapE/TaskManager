using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MVCUI.Controllers
{
   
    public class AdminController : Controller
    {
        IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult GetList()
        {
            var admins = _adminService.GetAll();
            return View(admins);
        }
        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAdmin(Admin admin)
        {
            _adminService.Add(admin);
            return RedirectToAction("GetList");
        }


        [HttpGet]
        public IActionResult UpdateAdmin(int id)
        {
            var adminToUpdate = _adminService.GetById(id);
            return View(adminToUpdate);
        }
        [HttpPost]
        public IActionResult UpdateAdmin(Admin admin)
        {
            _adminService.Update(admin);
            return RedirectToAction("GetList");
        }


        [HttpGet]
        public IActionResult DeleteAdmin(int id)
        {
            var adminToDelete = _adminService.GetById(id);
            _adminService.Delete(adminToDelete);
            return RedirectToAction("GetList");
        }
    }
}
