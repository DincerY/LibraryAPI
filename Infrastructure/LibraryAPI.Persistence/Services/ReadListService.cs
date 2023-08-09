using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryAPI.Application.Abstractions.Services;
using LibraryAPI.Application.DTOs.ReadList;
using LibraryAPI.Application.Models;
using LibraryAPI.Application.Repositories.ReadList;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Persistence.Services
{
    public class ReadListService : IReadListService
    {
        private readonly IReadListReadRepository _readListReadRepository;
        private readonly IMapper _mapper;
        public ReadListService(IReadListReadRepository readListReadRepository, IMapper mapper)
        {
            _readListReadRepository = readListReadRepository;
            _mapper = mapper;
        }

        public ReadListListModel Get()
        {
            List<ReadList> readLists = _readListReadRepository.GetAll().ToList();

            List<ReadListDto> readListDto = new List<ReadListDto>();
           
            //Repositoryden dönen veriyi Dto şekline çevirmeliyim.

            ReadListListModel readListListModel = new()
            {
                
            };
            return readListListModel;
        }

        public Task<ReadList> GetUsersReadList(string id)
        {
            throw new NotImplementedException();
        }
    }
}
