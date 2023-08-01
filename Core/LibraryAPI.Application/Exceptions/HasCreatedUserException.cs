using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Exceptions
{
    public class HasCreatedUserException : Exception
    {
        public HasCreatedUserException() : base(message:"Kullanıcı zaten mevcut")
        {
            
        }

        public HasCreatedUserException(string message) : base(message)
        {
            
        }
        public HasCreatedUserException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
