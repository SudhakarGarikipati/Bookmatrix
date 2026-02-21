using Administration.Domain.Entities;
using Administration.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Administration.Infrastructure.Persistance.Repository
{
    public class AdministrationRepository : IAdministrationRepository
    {
        private readonly bookmatrixdbContext _context;

        public AdministrationRepository(bookmatrixdbContext context)
        {
            _context = context;
        }

        public async Task AssignRoleToUserSysnc(string email, string role)
        {
            var user  = _context.Users.Where(u => u.Email == email).FirstOrDefault();
            var roleEntity = _context.Roles.Where(r => r.RoleName == role).FirstOrDefault();
            if (user == null || roleEntity == null)
            {
                throw new Exception("User or Role not found with the provided details.");
            }
            user.Roles.Add(roleEntity);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task RegisterUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task RevokeUserRoleAsync(string email, string roleName)
        {
            var user = _context.Users.Where(u => u.Email == email).FirstOrDefault();
            var userRole = _context.Roles.Where(r => r.RoleName == roleName).FirstOrDefault();
            if (user == null || userRole == null)
            {
                throw new Exception("Email or Role name provided are invalid.");
            }
            user.Roles.Remove(userRole);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(string email)
        {
            var user = await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task ChangePasswordAsync(string email, string password)
        {
            var user = _context.Users.Where(_context => _context.Email == email).FirstOrDefault() ?? throw new Exception("User not found");
            user.Password = password;
            _context.Users.Entry(user).Property(p => p.Password).IsModified = true;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            return user;
        }

        public async Task<List<User>> GetAllUsersAsync() => await _context.Users.ToListAsync();

        public async Task RegisterRoleAsync(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(string roleName)
        {
            var role = await _context.Roles.Where(r => r.RoleName == roleName).FirstOrDefaultAsync();
            if (role == null)
            {
                throw new Exception($"Role {roleName} deletion failed.");
            }
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Role>> GetAllRolesAsync() => await _context.Roles.ToListAsync();

        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            var role = await _context.Roles.Where(r => r.RoleName == roleName).FirstOrDefaultAsync();
            if(role == null)
            {
                throw new Exception("Role not found.");
            }
            return role;
        }

        public async Task UpdateRoleAsync(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }
    }
}
