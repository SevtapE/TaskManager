using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = Entities.Concrete.Task;

namespace Business.Concrete
{
    public class TaskManager : ITaskService
    {
        ITaskDal _taskDal;

        public TaskManager(ITaskDal adminDal)
        {
            _taskDal = adminDal;
        }

        public void Add(Task entity)
        {
            _taskDal.Add(entity);   
        }

        public void Delete(Task entity)
        {
            _taskDal.Delete(entity);
        }

        public List<Task> GetAll()
        {
           return _taskDal.GetAll();
        }
        public List<Task> GetFull()
        {
            return _taskDal.GetAll(include: (x => x.Include(x => x.Company).Include(x => x.Person.User)));

        }


        public Task GetById(int id)
        {
            return _taskDal.Get(x=>x.Id == id);
        }

        public void Update(Task entity)
        {
            _taskDal.Update(entity);
        }
    }
}
