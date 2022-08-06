using Business.Abstract;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MVCUI.Controllers
{
    public class TaskController : Controller
    {
        ITaskService _taskService;


        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        public IActionResult Index()
        {
            var tasks= _taskService.GetFull();
            return View(tasks);
        }
        public IActionResult TaskDetails(int id)
        {

            return View();
        }
    }
}
