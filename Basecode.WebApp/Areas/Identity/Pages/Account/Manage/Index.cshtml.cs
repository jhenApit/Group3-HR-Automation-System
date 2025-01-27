﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Basecode.Data.Dtos.HrEmployee;
using Basecode.Services.Interfaces;
using Basecode.Data.Models;
using NLog;
using static Basecode.Data.Constants;

namespace Basecode.WebApp.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHrEmployeeService _service;
        private readonly SignInManager<IdentityUser> _signInManager;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IHrEmployeeService service)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _service = service;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string Name { get; set; }
            [Required]
            [Display(Name = "Username")]
            public string UserName { get; set; }
        }

        private async Task LoadAsync(IdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var hr = await _service.GetByUserIdAsync(user.Id);
            var name = hr.Name;
            Email = email;
            UserName = userName;
            Name = name;
            Input = new InputModel
            {
                UserName = userName,
                Name = name
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                //if (user == null)
                //{
                //    return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                //}
                await LoadAsync(user);
                _logger.Info("Successfully loaded user profile");
                return Page();
            }
            catch (System.Exception ex) 
            {
                _logger.Error(ex,"Failed to load user");
                throw;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                Input.Name = Input.FirstName + ' ' + Input.MiddleName + ' ' + Input.LastName;
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                }

                if (!ModelState.IsValid)
                {
                    await LoadAsync(user);
                    return Page();
                }

                var userName = await _userManager.GetUserNameAsync(user);
                if (Input.UserName != userName)
                {
                    var existingUser = await _userManager.FindByNameAsync(Input.UserName);
                    if (existingUser != null)
                    {
                        // Email is already registered
                        StatusMessage = "The username '" + Input.UserName + "' is not available";
                        return RedirectToPage();
                    }
                    var result = await _userManager.SetUserNameAsync(user, Input.UserName);
                    if (!result.Succeeded)
                    {
                        StatusMessage = "Unexpected error when trying to set username";
                        return RedirectToPage();
                    }
                }
                var hr = _service.GetByUserIdAsync(user.Id);
                var hrEmployeeDto = new HREmployeeUpdationDto
                {
                    Name = Input.Name,
                    Email = user.Email,
                    Password = user.PasswordHash,
                    UserName = Input.UserName,
                    UserId = user.Id,
                    Id = hr.Id
                };
                await _service.UpdateAsync(hrEmployeeDto);
                await _signInManager.RefreshSignInAsync(user);
                StatusMessage = "Your profile has been updated";
                _logger.Info("Profile updated successfully");
                return RedirectToPage();
            }
            catch (System.Exception ex) 
            {
                _logger.Error(ex, "Failed to update account");
                throw;
            }
        }
    }
}
