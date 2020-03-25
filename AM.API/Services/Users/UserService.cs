using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AM.API.DTOs.Users;
using AM.API.Helpers;
using AM.Core.Domain.Users;
using AM.Core.Helper.Extensions;
using AM.Core.Helper.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AM.API.Services.Users
{
    public class UserService : IUserService
    {

        private readonly DataContext _context;

        public UserService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public User Authenticate(AuthenticateUser user)
        {
            if(user.UserName.HasValue() == false || user.Password.HasValue() == false)
            {
                return null;
            }

            var authenticatedUser = _context.Users
                                            .SingleOrDefault(x => x.UserName.ToLower() == user.UserName.ToLower());

            if (authenticatedUser == null)
            {
                return null;
            }

            // Check if password hash is verified or valid
            if (IsPasswordHashVerified(user.Password, authenticatedUser.PasswordHash, authenticatedUser.PasswordSalt) == false)
            {
                return null;
            }

            // Authentication successful
            return authenticatedUser;
        }

        private static bool IsPasswordHashVerified(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            if (password.HasValue() == false)
            {
                throw new ArgumentException(MessageHelper.PasswordIsInvalid, "password");
            }

            if (storedHash.Length != 64)
            {
                throw new ArgumentException(MessageHelper.InvalidPasswordHashLength, "passwordHash");
            }

            if (storedSalt.Length != 128)
            {
                throw new ArgumentException(MessageHelper.InvalidPasswordSaltLength, "passwordSalt");
            }

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public object GenerateToken(User authenticatedUser, AppSettings appSettings)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, authenticatedUser.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, authenticatedUser.Id.ToString()),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(appSettings.TokenExpiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new
            {
                authenticatedUser.Id,
                authenticatedUser.FullName,
                authenticatedUser.UserName,
                Token = tokenString
            };
        }

        public object Add(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            _context.SaveChanges();

            return new SuccessResponse();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            if (password.HasValue() == false)
            {
                throw new ArgumentException(MessageHelper.PasswordIsInvalid, "password");
            }

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public object GetAll(GetAll criteria, AppSettings appSettings)
        {
            var records = _context.Users.AsNoTracking()
                                  .Select(p => new
                                  {
                                      p.Id,
                                      p.FullName,
                                      p.UserName
                                  });

            GetAllResponse response = null;

            //  Check if user don't want to show all records
            if (criteria.ShowAll == false)
            {
                response = new GetAllResponse(records.Count(), criteria.CurrentPage, appSettings.RecordDisplayPerPage);

                //  Check if CurrentPage is greater than TotalPage
                if (criteria.CurrentPage > response.TotalPage)
                {
                    var error = new ErrorResponse();
                    error.ErrorMessages.Add(MessageHelper.NoRecordFound);

                    //  Return no record found error
                    return error;
                }

                records = records.Skip((criteria.CurrentPage - 1) * appSettings.RecordDisplayPerPage)
                                    .Take(appSettings.RecordDisplayPerPage);
            }
            else
            {
                response = new GetAllResponse(records.Count());
            }

            response.List.AddRange(records);

            return response;
        }

        public object GetById(int id)
        {
            var record = _context.Users.AsNoTracking()
                                 .Where(p => p.Id == id)
                                 .Select(p => new
                                 {
                                     p.Id,
                                     p.FullName,
                                     p.UserName
                                 })
                                 .FirstOrDefault();

            if (record != null)
            {
                return record;
            }

            var error = new ErrorResponse();
            error.ErrorMessages.Add(MessageHelper.RecordNotFound);

            return error;
        }

        public object Update(int id, UpdateUser updateUser, string password, IMapper mapper)
        {
            var user = _context.Users.AsNoTracking()
                               .Where(p => p.Id == id)
                               .FirstOrDefault();

            if (user == null)
            {
                var error = new ErrorResponse();
                error.ErrorMessages.Add(MessageHelper.RecordToBeUpdatedNotFound);

                return error;
            }
            else
            {
                var mappedUser = mapper.Map(updateUser, user);

                if(updateUser.Password.HasValue() == true)
                {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash(password, out passwordHash, out passwordSalt);

                    mappedUser.PasswordHash = passwordHash;
                    mappedUser.PasswordSalt = passwordSalt;
                }

                mappedUser.DateUpdated = DateTime.Now;

                _context.Update(mappedUser);
                _context.SaveChanges();

                return new SuccessResponse();
            }
        }

    }
}
