using Core.Core.Security.Dtos;
using Core.Core.Security.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        User GetById(int id);
        List<User> GetAll();
        User GetByMail(string email);
        List<OperationClaim> GetClaims(User user);
        void Add(User entity);
        void Update(UserForUpdateDto userForUpdateDto);
        void Delete(User entity);

    }
}
