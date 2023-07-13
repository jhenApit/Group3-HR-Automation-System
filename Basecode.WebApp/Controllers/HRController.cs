﻿using Basecode.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Basecode.Data.Dtos.JobPostings;
using Basecode.Services.Interfaces;

namespace Basecode.WebApp.Controllers
{
    public class HRController : Controller
    {
        /// <summary>
        /// Displays the list of job posts.
        /// </summary>
        /// <returns>The view containing the job post list.</returns>
        private readonly UserManager<HrEmployee> _userManager;
        private readonly IJobPostingsService _jobpostingService;

        public HRController(UserManager<HrEmployee> userManager, IJobPostingsService jobposting)
        {
            _userManager = userManager;
            _jobpostingService = jobposting;
        }
        public IActionResult JobPostList()
        {
            return View();
        }

        /// <summary>
        /// Displays the form to create a new job post.
        /// </summary>
        /// <returns>The view containing the job post creation form.</returns>
        public IActionResult CreateJobPost()
        {
            return View();
        }

        /// <summary>
        /// Displays the form to edit an existing job post.
        /// </summary>
        /// <returns>The view containing the job post edit form.</returns>
        public IActionResult EditJobPost()
        {
            return View();
        }

        /// <summary>
        /// Displays the details of a specific job post.
        /// </summary>
        /// <returns>The view containing the job post details.</returns>
        public IActionResult ViewJobPost()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateJobPosting(JobPostingsUpdationDto model)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the currently logged-in user
                var loggedInUser = await _userManager.GetUserAsync(User);

                if (loggedInUser != null)
                {
                    model.UpdatedById = loggedInUser.Id;
                    _jobpostingService.Update(model);
                    return RedirectToAction("JobPostList");
                }
            }

            // If the model is not valid or the user is not logged in, return the EditJobPosting view with the appropriate error
            return View("EditJobPosting", model);
        }
    }
}