using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.Entities.Entities.UserDetails
{
  public  class UserDetails
    {
        [Key]
        public int Id { get; set; }

        [StringLength(11, ErrorMessage = "Name must not be more than 11 char")]
        public string Name { get; set; }
        public string Gender { get; set; }
        [MinLength(5)]
        public string UserName { get; set; }
        [MinLength(5)]
        public string Password { get; set; }

        public string RefreshToken { get; set; }


    }
}
