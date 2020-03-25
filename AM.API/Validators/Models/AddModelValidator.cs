using AM.API.DTOs.Models;
using AM.API.Helpers;
using FluentValidation;
using System.Linq;

namespace AM.API.Validators.Models
{
    public class AddModelValidator : AbstractValidator<AddModel>
    {

        private readonly DataContext _context;

        public AddModelValidator(DataContext dataContext)
        {
            _context = dataContext;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p.Name)
                    .NotEmpty()
                    .Must(NotYetRegistered)
                        .WithMessage(p => (MessageHelper.IsAlreadyRegistered(p.Name)));
        }


        /// <summary>
        /// This is used to validate if Model's Name is already registered.
        /// </summary>
        /// <param name="name">Model's Name to be checked</param>
        /// <returns>False if registered, otherwise True.</returns>
        private bool NotYetRegistered(string name)
        {
            if (_context.Models.Where(x => x.Name.ToLower() == name.ToLower()).Count() != 0)
            {
                return false;
            }

            return true;
        }

    }
}
