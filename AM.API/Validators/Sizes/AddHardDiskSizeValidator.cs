using AM.API.DTOs.Sizes.HardDisk;
using AM.API.Helpers;
using FluentValidation;
using System.Linq;

namespace AM.API.Validators.Sizes
{
    public class AddHardDiskValidator : AbstractValidator<AddHardDisk>
    {

        private readonly DataContext _context;

        public AddHardDiskValidator(DataContext dataContext)
        {
            _context = dataContext;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p.Size)
                    .NotEmpty()
                    .Must(NotYetRegistered)
                        .WithMessage(p => (MessageHelper.IsAlreadyRegistered(p.Size)));
        }


        /// <summary>
        /// This is used to validate if HardDisk's Size is already registered.
        /// </summary>
        /// <param name="size">HardDisk's Size to be checked</param>
        /// <returns>False if registered, otherwise True.</returns>
        private bool NotYetRegistered(string size)
        {
            if (_context.HardDiskSizes.Where(x => x.Size.ToLower() == size.ToLower()).Count() != 0)
            {
                return false;
            }

            return true;
        }

    }
}
