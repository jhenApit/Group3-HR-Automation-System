﻿using Basecode.Data.Dtos;
using Basecode.Data.Models;

namespace Basecode.WebApp.Models
{
    public class ApplicationFormViewModel
    {
        public ApplicantCreationDto? Applicant { get; set; }
        public AddressCreationDto? Address { get; set; }
        public CharacterReferencesCreationDto? CharacterReferences1 { get; set; }
        public CharacterReferencesCreationDto? CharacterReferences2 { get; set; }
        public JobPostings? JobPosting { get; set; }
    }
}
