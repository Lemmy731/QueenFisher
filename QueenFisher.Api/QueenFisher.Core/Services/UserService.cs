using AutoMapper;
using QueenFisher.Core.Interfaces;
using QueenFisher.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenFisher.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<string>> DeleteUser(string userId)
        {
            var response = await _unitOfWork.UserRepository.DeleteUser(userId);
            if(response != null) return Response<string>.Success("successful", userId);
            return Response<string>.Fail("Failed");
        }

        public async Task<Response<IEnumerable<AppUserDto>>> GetAllUser()
        {
            var response = await _unitOfWork.UserRepository.GetUserAsynce();
            if(response != null) return Response<IEnumerable<AppUserDto>>.Success("user loaded successfully", response);
            return Response<IEnumerable<AppUserDto>>.Fail("Error Loading User");
        }
    }
}
