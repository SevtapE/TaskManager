using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MVCUI.ViewComponents.TaskWorker
{
  
    public class TasksDelegateList : ViewComponent
    {
        ITaskWorkerService _taskWorkerService;


        public TasksDelegateList(IWorkerService _taskWorkerService)
        {
            _taskWorkerService = _taskWorkerService;
        }
        public IViewComponentResult Invoke(int id)
        {
            var tasks = _taskWorkerService.GetFullByWorkerUserIdDelegate(id);
            return View(tasks);
        }
    }
}
