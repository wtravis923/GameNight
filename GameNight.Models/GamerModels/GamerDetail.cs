﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNight.Models.GamerModels
{
    public class GamerDetail
    {
        public int GamerId { get; set; }
        [Display(Name = "Tag")]
        public string GamerTag { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }
        public string Location { get; set; }
        public string Bio { get; set; }
    }
}
