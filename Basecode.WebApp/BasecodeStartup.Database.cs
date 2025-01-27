﻿using Basecode.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Basecode.WebApp
{
    public partial class BasecodeStartup
    {
        private void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<BasecodeContext>(
            options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found."),
                    optionsAction => { }
                )
            );
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<BasecodeContext>()
                    .AddSignInManager<SignInManager<IdentityUser>>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();      
        }
    }
}