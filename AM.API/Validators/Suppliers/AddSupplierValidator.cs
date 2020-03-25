using AM.API.DTOs.Suppliers;
using AM.API.Helpers;
using FluentValidation;
using System.Linq;

namespace AM.API.Validators.Suppliers
{
    public class AddSupplierValidator : AbstractValidator<AddSupplier>
    {

        private readonly DataContext _context;

        public AddSupplierValidator(DataContext dataContext)
        {
            _context = dataContext;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p.Name)
                    .NotEmpty()
                    .Must(NotYetRegistered)
                        .WithMessage(p => (MessageHelper.IsAlreadyRegistered(p.Name)));
        }


        /// <summary>
        /// This is used to validate if Supplier's Name is already registered.
        /// </summary>
        /// <param name="name">Supplier's Name to be checked</param>
        /// <returns>False if registered, otherwise True.</returns>
        private bool NotYetRegistered(string name)
        {
            if (_context.Suppliers.Where(x => x.Name.ToLower() == name.ToLower()).Count() != 0)
            {
                return false;
            }

            return true;
        }

    }
}
