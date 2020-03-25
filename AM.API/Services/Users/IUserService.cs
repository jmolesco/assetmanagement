using AM.API.DTOs.Users;
using AM.API.Helpers;
using AM.Core.Domain.Users;
using AutoMapper;

namespace AM.API.Services.Users
{
    public interface IUserService
    {

        /// <summary>
        /// Authenticate User
        /// </summary>
        /// <param name="user">User</param>
        /// <returns></returns>
        User Authenticate(AuthenticateUser user);

        /// <summary>
        /// Generate Token
        /// </summary>
        /// <param name="authenticatedUser"></param>
        /// <param name="appSettings"></param>
        /// <returns></returns>
        object GenerateToken(User authenticatedUser, AppSettings appSettings);

        /// <summary>
        /// Add new User
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="password">User's password</param>
        /// <returns></returns>
        object Add(User user, string password);

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <param name="criteria">Search criterias</param>
        /// <param name="appSettings">AppSettings</param>
        /// <returns></returns>
        object GetAll(GetAll criteria, AppSettings appSettings);

        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        object GetById(int id);

        /// <summary>
        /// Update User record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateUser">User</param>
        /// /// <param name="password">User's new password</param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        object Update(int id, UpdateUser updateUser, string password, IMapper mapper);
        
    }
}
