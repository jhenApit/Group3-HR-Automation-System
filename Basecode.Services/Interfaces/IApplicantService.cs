﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basecode.Data.Dtos.Applicants;
using Basecode.Data.Models;
using Basecode.Services.Utils;
using Microsoft.AspNetCore.Http;
using static Basecode.Data.Enums.Enums;

namespace Basecode.Services.Interfaces
{
    public interface IApplicantService
    {
        Task <Applicants?> GetByIdAsync(int id);
        Task<List<Applicants>> RetrieveAllAsync();
        Task<Applicants?> GetByNameAsync(string fname, string mname, string lname);
        Task<bool> AddApplicantAsync(ApplicationFormViewModel model, IFormFile resumeFile, IFormFile photo);
        Task<int> AddAsync(ApplicantCreationDto applicant);
        Task<bool> UpdateAsync(int id, string status);
        Task<Applicants> GetByApplicantIdAsync(string trackerId);
        Task<List<Applicants>> GetByEmailAsync(string email);
    }
}
