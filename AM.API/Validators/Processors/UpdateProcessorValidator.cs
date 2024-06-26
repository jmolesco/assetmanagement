﻿using AM.API.DTOs.Processors;
using AM.API.Helpers;
using AM.Core.Helper.Extensions;
using FluentValidation;
using System.Linq;

namespace AM.API.Validators.Processors
{
    public class UpdateProcessorValidator : AbstractValidator<UpdateProcessor>
    {

        private readonly DataContext _context;

        public UpdateProcessorValidator(DataContext dataContext, bool runDefaultValidations = true)
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
                        .Must(NameNotYetRegistered)
                            .When(p => p.Name.HasValue() == true)
                            .WithMessage(p => (MessageHelper.IsAlreadyRegistered(p.Name)));
            }
        }

        /// <summary>
        /// This is used to check if record is valid by Id.
        /// </summary>
        /// <param name="id">Id to be checked</param>
        /// <returns>False if not valid, otherwise true.</returns>
        private bool IdMustBeValid(int id)
        {
            if (_context.Processors.Where(x => x.Id == id).Count() != 1)
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


        private bool NameNotYetRegistered(UpdateProcessor model)
        {
            if (_context.Processors
                        .Where(
                                    x =>
                                        x.Name.ToLower() == model.Name.ToLower() &&
                                        x.Id != model.Id
                              ).Count() != 0)
            {
                return false;
            }

            return true;
        }

    }
}
