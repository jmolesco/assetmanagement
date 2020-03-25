using AM.API.DTOs.Sizes.VideoCard;
using AM.API.Helpers;
using FluentValidation;
using System.Linq;

namespace AM.API.Validators.Sizes
{
    public class AddVideoCardValidator : AbstractValidator<AddVideoCard>
    {

        private readonly DataContext _context;

        public AddVideoCardValidator(DataContext dataContext)
        {
            _context = dataContext;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p.Size)
                    .NotEmpty()
                    .Must(NotYetRegistered)
                        .WithMessage(p => (MessageHelper.IsAlreadyRegistered(p.Size)));
        }


        /// <summary>
        /// This is used to validate if VideoCard's Size is already registered.
        /// </summary>
        /// <param name="size">VideoCard's Size to be checked</param>
        /// <returns>False if registered, otherwise True.</returns>
        private bool NotYetRegistered(string size)
        {
            if (_context.VideoCardSizes.Where(x => x.Size.ToLower() == size.ToLower()).Count() != 0)
            {
                return false;
            }

            return true;
        }

    }
}
