using Sample_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Sample_Project.Services
{
    public interface ILoginService
    {
        Task<string> ValidateUser(LoginModel model);
    }
}