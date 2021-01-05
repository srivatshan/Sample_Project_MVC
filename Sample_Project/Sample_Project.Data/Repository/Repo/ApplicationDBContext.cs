using Sample_Project.Entities.Entities.UserDetails;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.Data.Repository.Repo
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {
            Database.SetInitializer<ApplicationDBContext>(new UserDBContextSeeder<ApplicationDBContext>());
            Database.Initialize(true);
            Database.CreateIfNotExists();
        }

        public DbSet<UserDetails> UserData { get; set; }

        public class UserDBContextSeeder<T> : CreateDatabaseIfNotExists<ApplicationDBContext>
        {
            protected override void Seed(ApplicationDBContext context)
            {
                UserDetails userDetails = new UserDetails()
                {

                    Gender = "Male",
                    Name = "Srivatshan",
                    Password = "srivat",
                    UserName = "srivatshan"
                };
                context.UserData.Add(userDetails);
                base.Seed(context);
            }
        }
    }
}
