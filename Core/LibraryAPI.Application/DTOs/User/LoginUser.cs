using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.DTOs.User
{
    public class LoginUser
    {
        public string EmailOrUsername { get; set;}
        public string Password { get; set; }
    }
}
