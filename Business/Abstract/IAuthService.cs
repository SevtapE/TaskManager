using Core.Core.Security.Dtos;
using Core.Core.Security.Entities;
using Core.Core.Security.Jwt;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        AccessToken CreateAccessToken(User user);
        public User Login(UserForLoginDto userForLoginDto);
        public User Register(UserForRegisterDto userForRegisterDto);
        public bool UserExists(string email);
    }
}
