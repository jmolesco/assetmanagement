using AM.API.DTOs.Users;
using AM.API.Helpers;
using AM.Core.Helper.Extensions;
using AM.Core.Helper.Lengths;
using FluentValidation;
using System.Linq;

namespace AM.API.Validators.Users
{
    public class UpdateUserValidator : AbstractValidator<UpdateUser>
    {

        private readonly DataContext _context;

        public UpdateUserValidator(DataContext dataContext)
        {
            _context = dataContext;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p.Id)
                    .Must(IdMustBeValid)
                        .WithMessage(MessageHelper.RecordToBeUpdatedNotValid);


            RuleFor(x => x)
                .Must(UserNameStillAvailable)
                    .WithMessage(p => (MessageHelper.IsAlreadyRegistered(p.UserName)));

            RuleFor(p => p.Password)
                .MinimumLength(MinLengthHelper.UserPasswordMinLength)
                    .When(p => p.Password.HasValue() == true);

        }

        /// <summary>
        /// This is used to check if record is valid by Id.
        /// </summary>
        /// <param name="id">Id to be checked</param>
        /// <returns>False if not valid, otherwise true.</returns>
        private bool IdMustBeValid(int id)
        {
            if (_context.Users.Where(x => x.Id == id).Count() != 1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// This is used to check if username is not yet registered.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>False if not valid, otherwise true.</returns>
        private bool UserNameStillAvailable(UpdateUser model)
        {
            if (_context.Users.Where(x => x.UserName.ToLower() == model.UserName.ToLower() && x.Id != model.Id).Count() != 0)
            {
                return false;
            }

            return true;
        }

    }
}
