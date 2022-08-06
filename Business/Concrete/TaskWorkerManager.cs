using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
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

        

        public List<TaskWorker> GetFull()
        {
            //get tasks with 
            return _taskWorkerDal.GetAll(include: (x => x.Include(x => x.Task).Include(x => x.Worker.User).Include(x => x.Worker)));

        }
        public List<TaskWorker> GetFullByWorkerUserId(int userId)
        {
            //get tasks with 
            return _taskWorkerDal.GetAll(filter: (x =>( x.Worker.UserId == userId)|| (x.Task.Person.UserId==userId)), include: (x => x.Include(x => x.Task).Include(x => x.Worker.User).Include(x => x.Worker)));

        }

        //Urgent && Important
        public List<TaskWorker> GetFullByWorkerUserIdDo(int userId) 
        {
            return _taskWorkerDal.GetAll(filter: (x => ((x.Worker.UserId == userId) || (x.Task.Person.UserId == userId)) &&((x.Task.Urgent)&&x.Task.Important)), include: (x => x.Include(x => x.Task).Include(x => x.Worker.User).Include(x => x.Worker)));

        }

        //Not Urgent && Important
        public List<TaskWorker> GetFullByWorkerUserIdSchedule(int userId)
        {
            return _taskWorkerDal.GetAll(filter: (x => ((x.Worker.UserId == userId) || (x.Task.Person.UserId == userId)) && ((x.Task.Urgent==false) && x.Task.Important)), include: (x => x.Include(x => x.Task).Include(x => x.Worker.User).Include(x => x.Worker)));

        }

        //Urgent && Not Important
        public List<TaskWorker> GetFullByWorkerUserIdLater(int userId)
        {
            return _taskWorkerDal.GetAll(filter: (x => ((x.Worker.UserId == userId) || (x.Task.Person.UserId == userId)) && ((x.Task.Urgent) && x.Task.Important==false)), include: (x => x.Include(x => x.Task).Include(x => x.Worker.User).Include(x => x.Worker)));

        }

        //Not Urgent && Not Important
        public List<TaskWorker> GetFullByWorkerUserIdDelegate(int userId)
        {
            return _taskWorkerDal.GetAll(filter: (x => ((x.Worker.UserId == userId) || (x.Task.Person.UserId == userId)) && ((x.Task.Urgent==false) && x.Task.Important==false)), include: (x => x.Include(x => x.Task).Include(x => x.Worker.User).Include(x => x.Worker)));

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
