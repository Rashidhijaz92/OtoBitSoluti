﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace loginsigupMj.Models
{
    public class Register
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public int Active { get; set; }
    }
}