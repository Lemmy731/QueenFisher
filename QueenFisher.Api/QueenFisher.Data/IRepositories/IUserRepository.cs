

using QueenFisher.Data.DTO;


namespace QueenFisher.Data
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUserDto>> GetUserAsynce(string? Role);
        Task<bool> DeleteUserAsync(string currentUserId, string userIdToDelete);
        Task<AppUserDtoForUpdate> UpdateUserDetails(string currentUserId, string userId, AppUserDtoForUpdate model);
    }
}
