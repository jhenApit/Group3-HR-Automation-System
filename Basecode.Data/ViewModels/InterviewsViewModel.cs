﻿using Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Data.ViewModels
{
    public class InterviewsViewModel
    {
        public Interviewers? Interviewers { get; set; }
        public List<Interviewers>? InterviewersList { get; set; }
        public List<Interviews>? InterviewsList { get; set; }
    }
}