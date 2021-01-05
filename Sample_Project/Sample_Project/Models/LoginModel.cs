using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sample_Project.Models
{
    public class LoginModel
    {
        [Required]
        [MinLength(5)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}