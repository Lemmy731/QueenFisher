using AspNetCoreHero.Results;
using AutoMapper;

using QueenFisher.Data;
using QueenFisher.Data.DTO;
using System;


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
        public async Task<Result<string>> DeleteUser(string currentUserId, string userIdToDelete)
        {
            var response = await _unitOfWork.UserRepository.DeleteUserAsync(currentUserId,userIdToDelete);
            if(response) return Result<string>.Success("successful", "Done");
            return Result<string>.Fail("Failed");
        }

        public async Task<Result<IEnumerable<AppUserDto>>> GetAllUser(string? Role)
        {
            var response = await _unitOfWork.UserRepository.GetUserAsynce(Role);
            if(response != null) return  Result<IEnumerable<AppUserDto>>.Success(response,"user loaded successfully");
            return Result<IEnumerable<AppUserDto>>.Fail("Error Loading User");
        }

        public async Task<Result<AppUserDtoForUpdate>> UpdateUserDetails( string currentUser, string userId, AppUserDtoForUpdate userDto)
        {
            var response = await _unitOfWork.UserRepository.UpdateUserDetails(currentUser, userId, userDto);
            if(response != null) return Result<AppUserDtoForUpdate>.Success(response,userId);
            return Result<AppUserDtoForUpdate>.Fail("Failed");
        }
    }
}
