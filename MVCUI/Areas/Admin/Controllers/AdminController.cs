using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AdminController : Controller
    {
        IAdminService _adminService;
        IUserService _userService;

        public AdminController(IAdminService adminService, IUserService userService)
        {
            _adminService = adminService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            var admins = _adminService.GetFull();
            return View(admins);
        }
        [HttpGet]
        public IActionResult AddAdmin()
        {
            List<SelectListItem> users= new List<SelectListItem>( from x in _userService.GetAllActive()
                                                                  select new SelectListItem
                                                                  {
                                                                      Text = x.FirstName + " " + x.LastName,
                                                                      Value = x.Id.ToString()

                                                                  }).ToList();
            ViewBag.Users=users;
            return View();
        }

        [HttpPost]
        public IActionResult AddAdmin(Entities.Concrete.Admin admin)
        {
            _adminService.Add(admin);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult UpdateAdmin(int id)
        {
            var adminToUpdate = _adminService.GetById(id);

            List<SelectListItem> usersUpdate = new List<SelectListItem>(from x in _userService.GetAllActive()
                                                                  select new SelectListItem
                                                                  {
                                                                      Text = x.FirstName + " " + x.LastName,
                                                                      Value = x.Id.ToString()

                                                                  }).ToList();
            ViewBag.UsersUpdate = usersUpdate;
          
            return View(adminToUpdate);
        }
        [HttpPost]
        public IActionResult UpdateAdmin(Entities.Concrete.Admin admin)
        {
            _adminService.Update(admin);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult DeleteAdmin(int id)
        {
            var adminToDelete = _adminService.GetById(id);
            _adminService.Delete(adminToDelete);
            return RedirectToAction("Index");
        }
    }
}
