using Sample_Project.Entities.Entities.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.Data.Repository.Interface
{
    public interface IUserRepository
    {
        UserDetails GetUseretails(string UserName, string Password);
        void UpdateReferenceToken(string UserName, string Token);

        string GetUserByRefreshToken(string RefreshToken);
    }
}
