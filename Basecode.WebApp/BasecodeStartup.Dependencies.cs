﻿using Basecode.WebApp.Authentication;
using Basecode.Data;
using Basecode.Data.Interfaces;
using Basecode.Data.Repositories;
using Basecode.Services.Interfaces;
using Basecode.Services.Services;
using Basecode.Services.Utils;
using Basecode.Data.Models;

namespace Basecode.WebApp
{
    public partial class BasecodeStartup
    {
        private void ConfigureDependencies(IServiceCollection services)
        {            
            // Common
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ClaimsProvider, ClaimsProvider>();

            //Utils
            services.AddScoped<IErrorHandling, ErrorHandling>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ISendEmailService, SendEmailService>();
            services.AddTransient<IFileService,  FileService>();
            services.AddTransient<IMeetingLinkService,  MeetingLinkService>();

            // Services 
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IHrEmployeeService, HrEmployeeService>();
            services.AddScoped<IJobPostingsService, JobPostingsService>();
            services.AddScoped<IApplicantService, ApplicantService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ICharacterReferencesService, CharacterReferencesService>();
            services.AddScoped<IReferenceFormsService, ReferenceFormsService>();
            services.AddScoped<ICurrentHiresService, CurrentHiresService>();
            services.AddScoped<IInterviewsService, InterviewsService>();
            services.AddScoped<IInterviewersService, InterviewersService>();

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IHrEmployeeRepository, HrEmployeeRepository>();
            services.AddScoped<IJobPostingsRepository, JobPostingsRepository>();
            services.AddScoped<IApplicantRepository, ApplicantRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICharacterReferencesRepository, CharacterReferencesRepository>();
            services.AddScoped<IReferenceFormsRepository, ReferenceFormsRepository>();
            services.AddScoped<ICurrentHiresRepository, CurrentHiresRepository>();
            services.AddScoped<IInterviewsRepository, InterviewsRepository>();
            services.AddScoped<IInterviewersRepository, InterviewersRepository>();
        }
    }
}