using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Features.Books.Commands;

public interface IBookCommandResponse
{
}

public interface IBookCommandResponseFactory
{

}

public class CreatedBookResponseFactory : IBookCommandResponseFactory
{

}

public class DeletedBookResponseFactory : IBookCommandResponseFactory
{

}