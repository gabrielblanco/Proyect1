﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyect1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public int Age { get; set; }
    }
}