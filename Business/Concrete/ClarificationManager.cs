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
    public class ClarificationManager : IClarificationService
    {
        IClarificationDal _clarificationDal;

        public ClarificationManager(IClarificationDal adminDal)
        {
            _clarificationDal = adminDal;
        }

        public void Add(Clarification entity)
        {
            _clarificationDal.Add(entity);   
        }

        public void Delete(Clarification entity)
        {
            _clarificationDal.Delete(entity);
        }

        public List<Clarification> GetAll()
        {
           return _clarificationDal.GetAll();
        }
        public List<Clarification> GetFull()
        {
            return _clarificationDal.GetAll(include: (x => x.Include(x => x.Person.User).Include(x => x.Task)));

        }

        public List<Clarification> GetFullByTaskId(int taskId)
        {
            return _clarificationDal.GetAll(filter: (x => x.TaskId == taskId), include: (x => x.Include(x => x.Task).Include(x => x.Person.User)));

        }

        public Clarification GetById(int id)
        {
            return _clarificationDal.Get(x=>x.Id == id);
        }

        public void Update(Clarification entity)
        {
            _clarificationDal.Update(entity);
        }
    }
}
