﻿using Core.Core.Entities.Abstract;
using Core.Core.Security.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Admin : Person
    {
        public Admin()
        {

        }

        public Admin( int id, int userId, string adminDescription) : this()
        {
            Id = Id;
            UserId = userId;
            AdminDescription = adminDescription;
        }
        public string AdminDescription { get; set; }



    }
}
