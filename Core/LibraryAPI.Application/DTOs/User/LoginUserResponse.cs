using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.DTOs.User
{
    public class LoginUserResponse
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public Token.Token Token { get; set; }
    }
}
