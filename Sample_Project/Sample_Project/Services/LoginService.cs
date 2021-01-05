using Newtonsoft.Json;
using Sample_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Sample_Project.Services
{
    public class LoginService : ILoginService
    {
        private readonly string BaseUrl;
        private HttpClient _client;
        public LoginService()
        {
            BaseUrl = "https://localhost:44399/api/Login/GetToken";
            _client = new HttpClient();
        }

        public async Task<string> ValidateUser(LoginModel model)
        {
          
            var response = _client.GetAsync(BaseUrl+"?username=srivatshan&password=srivat").Result;
            var Result = "";
            if (response.IsSuccessStatusCode)
            {
                Result = response.Content.ReadAsStringAsync().Result;
            }
            return  Result;
        }


    }
}