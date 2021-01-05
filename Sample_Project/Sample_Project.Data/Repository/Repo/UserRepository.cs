using Sample_Project.Data.Repository.Interface;
using Sample_Project.Entities.Entities.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.Data.Repository.Repo
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _db;
        public UserRepository(ApplicationDBContext applicationDBContext)
        {
            _db = applicationDBContext;
        }

        public UserDetails GetUseretails(string UserName, string Password)
        {
            return _db.UserData.Where(x => x.UserName == UserName && x.Password == Password).FirstOrDefault();
        }

        public string GetUserByRefreshToken(string RefreshToken)
        {
            return _db.UserData.Where(x => x.RefreshToken == RefreshToken).Select(x => x.UserName).FirstOrDefault();
        }

        public void UpdateReferenceToken(string UserName, string Token)
        {
            var Details = _db.UserData.SingleOrDefault(x => x.UserName == UserName);
            if (Details != null)
            {
                Details.RefreshToken = Token;
                _db.SaveChanges();
            }
        }
    }

}
