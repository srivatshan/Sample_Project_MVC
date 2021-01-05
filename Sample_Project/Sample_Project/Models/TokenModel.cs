using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample_Project.Models
{
    public class TokenModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Expires { get; set; }
    }
}