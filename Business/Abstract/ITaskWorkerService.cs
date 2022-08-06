using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITaskWorkerService
    {
        TaskWorker GetById(int id);
        List<TaskWorker> GetAll();
        List<TaskWorker> GetFull();
        List<TaskWorker> GetFullByWorkerUserId(int userId);

        List<TaskWorker> GetFullByWorkerUserIdDo(int userId); //Urgent && Important
        List<TaskWorker> GetFullByWorkerUserIdSchedule(int userId);
        List<TaskWorker> GetFullByWorkerUserIdLater(int userId);
        List<TaskWorker> GetFullByWorkerUserIdDelegate(int userId);




        void Add(TaskWorker entity);
        void Update(TaskWorker entity);
        void Delete(TaskWorker entity);
    }
}
