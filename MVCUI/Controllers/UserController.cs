using Business.Abstract;
using Core.Core.Security.Dtos;
using Core.Core.Security.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MVCUI.Controllers
{
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
          
            return View();
        }

        [HttpGet]
        public IActionResult UpdateUser(int id)
        {
           var userToUpdate = _useryService.GetById(id);
          
            return View(userToUpdate);
        }
        [HttpPost]
        public PartialViewResult UpdateUser(UserForUpdateDto userForUpdateDto)
        {
             _useryService.Update(userForUpdateDto);
            return PartialView();
        }
     

    }
}
