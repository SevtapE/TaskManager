using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MVCUI.ViewComponents.TaskWorker
{
  
    public class TasksLaterList : ViewComponent
    {
        ITaskWorkerService _taskWorkerService;


        public TasksLaterList(IWorkerService _taskWorkerService)
        {
            _taskWorkerService = _taskWorkerService;
        }
        public IViewComponentResult Invoke(int id)
        {
            var tasks = _taskWorkerService.GetFullByWorkerUserIdLater(id);
            return View(tasks);
        }
    }
}
