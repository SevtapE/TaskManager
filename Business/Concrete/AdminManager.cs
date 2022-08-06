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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void Add(Admin entity)
        {
           _adminDal.Add(entity);   
        }

        public void Delete(Admin entity)
        {
            _adminDal.Delete(entity);
        }

        public List<Admin> GetAll()
        {
           return _adminDal.GetAll();
        }
        public List<Admin> GetFull()
        {

            return _adminDal.GetAll(include: (x => x.Include(x => x.User)));

        }

        public List<Admin> GetFullById(int id)
        {

            return _adminDal.GetAll(filter: (x => (x.Id== id)),include: (x => x.Include(x => x.User)));

        }

        public Admin GetById(int id)
        {
            return _adminDal.Get(x=>x.Id == id);
        }

        public void Update(Admin entity)
        {
            _adminDal.Update(entity);
        }
    }
}
