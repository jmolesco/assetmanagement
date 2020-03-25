using System.Linq;
using AM.API.DTOs.Manufacturers;
using AM.API.Helpers;
using FluentValidation;

namespace AM.API.Validators.Manufacturers
{
    public class AddManufacturerValidator : AbstractValidator<AddManufacturer>
    {

        private readonly DataContext _context;

        public AddManufacturerValidator(DataContext dataContext)
        {
           _context = dataContext;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p.Name)
                    .NotEmpty()
                    .Must(NotYetRegistered)
                        .WithMessage(p => (MessageHelper.IsAlreadyRegistered(p.Name)));
        }


        /// <summary>
        /// This is used to validate if Manufacturer's Name is already registered.
        /// </summary>
        /// <param name="name">Manufacturer's Name to be checked</param>
        /// <returns>False if registered, otherwise True.</returns>
        private bool NotYetRegistered(string name)
        {
            if (_context.Manufacturers.Where(x => x.Name.ToLower() == name.ToLower()).Count() != 0)
            {
                return false;
            }

            return true;
        }

    }
}
