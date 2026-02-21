using Administration.Application.DTOs;

namespace Administration.Application.Service.Interface
{
    public interface IAdministrationAppService
    {
        Task RegisterUserAsync(SignInDto user);

        Task UpdateUserAsync(UpdateUserDto user);

        Task ChangePasswordAsync(ChangePasswordDto user);

        Task DeleteUserAsync(string email);

        Task<List<UserDto>> GetAllUsersAsync();

        Task<UserDto> LoginAsync(LoginDto loginDto);

        Task RegisterRoleAsync(RoleDto role);

        Task<List<RoleDto>> GetAllRolesAsync();

        Task DeleteRoleAsync(string roleName);

        Task UpdateRoleAsync(RoleDto role);

        Task AssignRoleToUserAsync(UserRoleDto userRoleDto);

        Task RevokeUserRoleAsync(UserRoleDto userRoleDto);
    }
}
