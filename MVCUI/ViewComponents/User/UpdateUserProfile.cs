using Microsoft.AspNetCore.Mvc;

namespace MVCUI.ViewComponents.User
{
    public class UpdateUserProfile: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
