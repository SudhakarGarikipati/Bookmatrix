using Administration.Application.DTOs;
using Administration.Application.Service.Interface;
using Administration.Domain.Entities;
using Administration.Domain.Interfaces;
using MapsterMapper;
using BC = BCrypt.Net.BCrypt;

namespace Administration.Application.Service.Implementation
{
    public class AdministrationAppService : IAdministrationAppService
    {

        private readonly IAdministrationRepository _administrationRepository;
        private readonly IMapper _mapper;

        public AdministrationAppService(IAdministrationRepository administrationRepository, IMapper mapper)
        {
            _administrationRepository = administrationRepository;
            _mapper = mapper;
        }

        public async Task RegisterUserAsync(SignInDto signInDto)
        {
            if (signInDto.Email == null || signInDto.FirstName is null || signInDto.LastName is null || signInDto.PhoneNumber is null || signInDto.Password is null)
            {
                throw new Exception("Please provide complete data, profile cannot be saved.");
            }

            // Has the password.
            signInDto.Password = GetHash(signInDto.Password);

            var user = _mapper.Map<User>(signInDto);
            await _administrationRepository.RegisterUserAsync(user);
        }

        private static string GetHash(string password) => BC.HashPassword(password);

        public async Task UpdateUserAsync(UpdateUserDto userDto)
        {
            if (userDto.Email == null || userDto.FirstName is null || userDto.LastName is null || userDto.PhoneNumber is null)
            {
                throw new Exception("Please provide complete data, profile cannot be saved.");
            }
            var user = _mapper.Map<User>(userDto);
            await _administrationRepository.UpdateUserAsync(user);
        }

        public async Task ChangePasswordAsync(ChangePasswordDto userDto)
        {
            // Logic to validate the current password.
            var userData = await _administrationRepository.GetUserByEmailAsync(userDto.Email) ?? throw new Exception("User not found with the login id and password.");
            //check the password
            if (!IsPasswordMatced(userData.Password, userDto.CurrentPassword))
            {
                throw new Exception("Password mismatch, authentication failed.");
            }
            // Logic to encrypt new password...
            var hash = GetHash(userDto.NewPassword);
            await _administrationRepository.ChangePasswordAsync(userDto.Email, hash);
        }

        public async Task DeleteUserAsync(string email)
        {
            var user = _administrationRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            await _administrationRepository.DeleteUserAsync(email);
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _administrationRepository.GetAllUsersAsync();
            var res = _mapper.Map<List<UserDto>>(users);
            return res;
        }

        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            if(loginDto.Username == null || loginDto.Password == null)
            {
                throw new Exception("Invalid login id and password.");
            }
            var userData = await _administrationRepository.GetUserByEmailAsync(loginDto.Username) ?? throw new Exception("User not found with the login id and password.");
            //check the password
            if (!IsPasswordMatced(userData.Password, loginDto.Password))
            {
                throw new Exception("Password mismatch, authentication failed.");
            }
            return _mapper.Map<UserDto>(userData);
        }

        private static bool IsPasswordMatced(string hash, string password) => BC.Verify(hash, password);

        public async Task RegisterRoleAsync(RoleDto roleDto)
        {
            var newRole = _mapper.Map<Role>(roleDto);
            await _administrationRepository.RegisterRoleAsync(newRole);
        }

        public async Task<List<RoleDto>> GetAllRolesAsync()
        {
            var roles = await _administrationRepository.GetAllRolesAsync();
            return _mapper.Map<List<RoleDto>>(roles);
        }

        public async Task DeleteRoleAsync(string roleName)
        {
            if(roleName == null)
            {
                throw new Exception("Provide role name to delete.");
            }
            await _administrationRepository.DeleteRoleAsync(roleName);
        }

        public async Task UpdateRoleAsync(RoleDto roleDto)
        {
            if(roleDto.RoleName==null || roleDto.Description ==null)
            {
                throw new Exception("Provide details to update.");
            }
            var role = _mapper.Map<Role>(roleDto);
            await _administrationRepository.UpdateRoleAsync(role);
        }


        public async Task AssignRoleToUserAsync(UserRoleDto userRoleDto)
        {
            if (userRoleDto.Email == null || userRoleDto.Role == null)
            {
                throw new Exception("Please provide details to assign new role to user.");
            }
           await  _administrationRepository.AssignRoleToUserSysnc(userRoleDto.Email, userRoleDto.Role);
        }

        public async Task RevokeUserRoleAsync(UserRoleDto userRoleDto)
        {
            if (userRoleDto.Email == null || userRoleDto.Role == null)
            {
                throw new Exception("Please provide details to assign new role to user.");
            }
            await _administrationRepository.RevokeUserRoleAsync(userRoleDto.Email, userRoleDto.Role);
        }
    }
}
