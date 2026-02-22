using Administration.Domain.Entities;

namespace Administration.Domain.Interfaces
{
    public  interface ITokenService
    {
        /// <summary>
        /// Generates a JWT access token for the given user.
        /// </summary>
        string GenerateAccessToken(User user);

    }
}
