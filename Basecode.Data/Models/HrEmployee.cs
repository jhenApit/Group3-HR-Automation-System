﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basecode.Data.Models
{
	public class HrEmployee
	{
		public int Id { get; set; }
		public string? UserId { get; set; }
        [ForeignKey("UserId"), DeleteBehavior(DeleteBehavior.Cascade)]
        public IdentityUser? User { get; set; }
        public string? Name { get; set; }
		public string? Email { get; set; }
		public string? Password { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}