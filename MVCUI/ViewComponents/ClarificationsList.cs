using Microsoft.AspNetCore.Mvc;

namespace MVCUI.ViewComponents
{
    public class ClarificationsList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
