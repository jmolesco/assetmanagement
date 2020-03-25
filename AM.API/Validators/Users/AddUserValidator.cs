using AM.API.DTOs.Users;
using AM.API.Helpers;
using FluentValidation;
using System.Linq;

namespace AM.API.Validators.Users
{
    public class AddUserValidator : AbstractValidator<AddUser>
    {

        private readonly DataContext _context;

        public AddUserValidator(DataContext dataContext)
        {
            _context = dataContext;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p.UserName)
                .Must(NotYetRegistered)
                    .WithMessage(p => (MessageHelper.IsAlreadyRegistered(p.UserName)));
        }

        /// <summary>
        /// This is used to validate if User's UserName is already registered.
        /// </summary>
        /// <param name="userName">User's UserName to be checked</param>
        /// <returns>False if registered, otherwise True.</returns>
        private bool NotYetRegistered(string userName)
        {
            if (_context.Users.Where(x => x.UserName.ToLower() == userName.ToLower()).Count() != 0)
            {
                return false;
            }

            return true;
        }

    }
}
