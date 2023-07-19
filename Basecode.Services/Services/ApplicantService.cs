﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Basecode.Data.Dtos;
using Basecode.Data.Interfaces;
using Basecode.Data.Models;
using Basecode.Services.Interfaces;

namespace Basecode.Services.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _repository;
        private readonly IMapper _mapper;
        public ApplicantService(IApplicantRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves an applicant by their ID.
        /// </summary>
        /// <param name="id">The ID of the applicant.</param>
        /// <returns>The applicant with the specified ID.</returns>
        public void Add(ApplicantCreationDto applicant)
        {
            var applicantModel = _mapper.Map<Applicant>(applicant);
            applicantModel.ApplicantId = GenerateRandomApplicantId();
            applicantModel.ApplicationDate = DateTime.Now;
            _repository.Add(applicantModel);
        }
        private static string? GenerateRandomApplicantId()
        {
            const string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var result = new string(Enumerable.Repeat(allowedChars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return result;
        }

        public Applicant GetByApplicantId(string applicantId)
        {
            return _repository.GetByApplicantId(applicantId);
        }

        public Applicant GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Applicant GetByName(string name)
        {
            return _repository.GetByName(name);
        }

        public List<Applicant> RetrieveAll()
        {
            return _repository.RetrieveAll().ToList();
        }
    }
}
