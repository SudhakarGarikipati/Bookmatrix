using Administration.Application.DTOs;
using Administration.Domain.Entities;
using Mapster;

namespace Administration.Application.Mappers
{
    public class MappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<User, UserDto>()
                .Map(dest => dest.Roles, src => src.Roles.Select(r=>r.RoleName).ToList<string>());
            config.NewConfig<User, LoginUserDto>()
               .Map(dest => dest.Roles, src => src.Roles.Select(r => r.RoleName).ToList<string>());
            config.NewConfig<UpdateUserDto, User>().TwoWays();
            config.NewConfig<SignInDto, User>();
            config.NewConfig<LoginDto, User>();
            config.NewConfig<RoleDto, Role>().TwoWays();
            config.NewConfig<UpdateRoleDto, Role>();
        }
    }
}
