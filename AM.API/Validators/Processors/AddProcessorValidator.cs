using AM.API.DTOs.Processors;
using AM.API.Helpers;
using FluentValidation;
using System.Linq;

namespace AM.API.Validators.Processors
{
    public class AddProcessorValidator : AbstractValidator<AddProcessor>
    {

        private readonly DataContext _context;

        public AddProcessorValidator(DataContext dataContext)
        {
            _context = dataContext;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p.Name)
                    .NotEmpty()
                    .Must(NotYetRegistered)
                        .WithMessage(p => (MessageHelper.IsAlreadyRegistered(p.Name)));
        }


        /// <summary>
        /// This is used to validate if Processor's Name is already registered.
        /// </summary>
        /// <param name="name">Processor's Name to be checked</param>
        /// <returns>False if registered, otherwise True.</returns>
        private bool NotYetRegistered(string name)
        {
            if (_context.Processors.Where(x => x.Name.ToLower() == name.ToLower()).Count() != 0)
            {
                return false;
            }

            return true;
        }

    }
}
