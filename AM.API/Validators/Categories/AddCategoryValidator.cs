using AM.API.DTOs.Categories;
using AM.API.Helpers;
using FluentValidation;
using System.Linq;

namespace AM.API.Validators.Categories
{
    public class AddCategoryValidator : AbstractValidator<AddCategory>
    {

        private readonly DataContext _context;

        public AddCategoryValidator(DataContext dataContext)
        {
            _context = dataContext;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p.Name)
                    .NotEmpty()
                    .Must(NotYetRegistered)
                        .WithMessage(p => (MessageHelper.IsAlreadyRegistered(p.Name)));
        }


        /// <summary>
        /// This is used to validate if Category's Name is already registered.
        /// </summary>
        /// <param name="name">Category's Name to be checked</param>
        /// <returns>False if registered, otherwise True.</returns>
        private bool NotYetRegistered(string name)
        {
            if (_context.Categories.Where(x => x.Name.ToLower() == name.ToLower()).Count() != 0)
            {
                return false;
            }

            return true;
        }

    }
}
