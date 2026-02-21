using Administration.Domain.Entities;

namespace Administration.Domain.Interfaces
{
    public interface IAdministrationRepository
    {
        Task RegisterUserAsync(User user);

        Task UpdateUserAsync(User user);

        Task ChangePasswordAsync(string email, string password);

        Task AssignRoleToUserSysnc(string email, string role);

        Task RevokeUserRoleAsync(string email, string role);

        Task DeleteUserAsync(string email);

        Task<User> GetUserByEmailAsync(string email);

        Task<List<User>> GetAllUsersAsync();

        Task RegisterRoleAsync(Role role);

        Task<List<Role>> GetAllRolesAsync();

        Task DeleteRoleAsync(string roleName);

        Task UpdateRoleAsync(Role role);

        Task<Role> GetRoleByNameAsync(string roleName);
    }
}
