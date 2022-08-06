using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        Company GetById(int id);
        List<Company> GetAll();
        List<Company> GetAllWithEmployees();
        List<Company> GetWithEmployees(int companyId);
        void Add(Company entity);
        void Update(Company entity);
        void Delete(Company entity);

    }
}
