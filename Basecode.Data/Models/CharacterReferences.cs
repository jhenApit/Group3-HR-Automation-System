﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Data.Models
{
    public class CharacterReferences
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        [ForeignKey("ApplicantId")]
        public Applicants Applicant { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Relationship { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
    }
}
