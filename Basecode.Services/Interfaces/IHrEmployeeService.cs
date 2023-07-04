﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basecode.Data.Models;

namespace Basecode.Services.Interfaces
{
    public interface IHrEmployeeService
    {
        List<HrEmployee> RetrieveAll();
        HrEmployee GetByEmail(string email);
        void Add(HREmployeeCreationDto hrEmployee);
        HrEmployee GetById(int id);
        void Update(HrEmployee hrEmployee);
    }
}
