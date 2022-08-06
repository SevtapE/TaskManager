using Business.Abstract;
using Core.Core.Security.Dtos;
using Core.Core.Security.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        IUserService _useryService;
        IAuthService _authService;

        public UserController(IUserService useryService, IAuthService authService)
        {
            _useryService = useryService;
            _authService = authService;
        }
        public IActionResult Index()
        {
            var users = _useryService.GetAll();
            return View(users);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(UserForRegisterDto userForRegisterDto)
        {
            _authService.Register(userForRegisterDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateUser(int id)
        {
           var userToEdit = _useryService.GetById(id);
          
            return View(userToEdit);
        }
        [HttpPost]
        public PartialViewResult UpdateUser(UserForUpdateDto userForUpdateDto)
        {
             _useryService.Update(userForUpdateDto);
            return PartialView();
        }
        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            var userToDelete = _useryService.GetById(id);
            _useryService.Delete(userToDelete);
            return RedirectToAction("Index");
        }

    }
}
