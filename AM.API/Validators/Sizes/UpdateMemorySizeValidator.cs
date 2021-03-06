﻿using AM.API.DTOs.Sizes.Memory;
using AM.API.Helpers;
using AM.Core.Helper.Extensions;
using FluentValidation;
using System.Linq;

namespace AM.API.Validators.Sizes
{
    public class UpdateMemorySizeValidator : AbstractValidator<UpdateMemory>
    {

        private readonly DataContext _context;

        public UpdateMemorySizeValidator(DataContext dataContext, bool runDefaultValidations = true)
        {
            _context = dataContext;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            if (runDefaultValidations)
            {
                RuleFor(p => p.Id)
                    .Must(IdMustBeValid)
                        .WithMessage(MessageHelper.RecordToBeUpdatedNotValid);

                RuleFor(p => p)
                        .NotEmpty()
                        .Must(SizeNotYetRegistered)
                            .When(p => p.Size.HasValue() == true)
                            .WithMessage(p => (MessageHelper.IsAlreadyRegistered(p.Size)));
            }
        }

        /// <summary>
        /// This is used to check if record is valid by Id.
        /// </summary>
        /// <param name="id">Id to be checked</param>
        /// <returns>False if not valid, otherwise true.</returns>
        private bool IdMustBeValid(int id)
        {
            if (_context.MemorySizes.Where(x => x.Id == id).Count() != 1)
            {
                return false;
            }

            return true;
        }

        public bool IdMustBeValid(int? id)
        {
            if (id.HasValue)
            {
                return this.IdMustBeValid((int)id);
            }

            return false;
        }

        private bool SizeNotYetRegistered(UpdateMemory model)
        {
            if (_context.MemorySizes
                        .Where(
                                    x =>
                                        x.Size.ToLower() == model.Size.ToLower() &&
                                        x.Id != model.Id
                              ).Count() != 0)
            {
                return false;
            }

            return true;
        }

    }
}
