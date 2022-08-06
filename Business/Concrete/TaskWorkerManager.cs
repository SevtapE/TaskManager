using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TaskWorkerManager : ITaskWorkerService
    {
        ITaskWorkerDal _taskWorkerDal;

        public TaskWorkerManager(ITaskWorkerDal taskWorkerDal)
        {
            _taskWorkerDal = taskWorkerDal;
        }

        public void Add(TaskWorker entity)
        {
            _taskWorkerDal.Add(entity);   
        }

        public void Delete(TaskWorker entity)
        {
            _taskWorkerDal.Delete(entity);
        }

        public List<TaskWorker> GetAll()
        {
           return _taskWorkerDal.GetAll();
        }

        public TaskWorker GetById(int id)
        {
            return _taskWorkerDal.Get(x=>x.Id == id);
        }

        public void Update(TaskWorker entity)
        {
            _taskWorkerDal.Update(entity);
        }
    }
}
