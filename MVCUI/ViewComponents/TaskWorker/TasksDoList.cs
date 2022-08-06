using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MVCUI.ViewComponents.TaskWorker
{
  
    public class TasksDoList : ViewComponent
    {
        ITaskWorkerService _taskWorkerService;


        public TasksDoList(IWorkerService _taskWorkerService)
        {
            _taskWorkerService = _taskWorkerService;
        }
        public IViewComponentResult Invoke(int id)
        {
            var tasks = _taskWorkerService.GetFullByWorkerUserIdDo(id);
            return View(tasks);
        }
    }
}
