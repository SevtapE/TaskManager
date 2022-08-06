using Business.Abstract;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MVCUI.Areas.Worker.Controllers
{
    [Area("Worker")]
    public class TaskWorkerController : Controller
    {
        ITaskWorkerService _taskWorkerService;


        public TaskWorkerController(IWorkerService _taskWorkerService)
        {
            _taskWorkerService = _taskWorkerService;
        }
        //my tasks
        public IActionResult Index()
        {
            //yukarı id eklicem sessiondan gelen 
            //id userId'yi taşıyor
            int id = 1;
            ViewBag.Id = id;
            var tasks = _taskWorkerService.GetFullByWorkerUserId(id);
            return View(tasks);
        }
        public IActionResult TaskDetails(int id)
        {

            return View();
        }
    }
}
