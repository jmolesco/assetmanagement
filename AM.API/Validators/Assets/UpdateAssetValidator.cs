using AM.API.DTOs.Assets;
using AM.API.Helpers;
using AM.API.Validators.Categories;
using AM.API.Validators.Manufacturers;
using AM.API.Validators.Models;
using AM.API.Validators.Processors;
using AM.API.Validators.Sizes;
using AM.API.Validators.Suppliers;
using FluentValidation;
using System.Linq;

namespace AM.API.Validators.Assets
{
    public class UpdateAssetValidator : AbstractValidator<UpdateAsset>
    {

        private readonly DataContext _context;

        public UpdateAssetValidator(DataContext dataContext)
        {
            _context = dataContext;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p.Id)
                    .Must(IdMustBeValid)
                        .WithMessage(MessageHelper.RecordToBeUpdatedNotValid);

            RuleFor(p => p.AssetTag)
                    .NotEmpty();

            ValidForeignKeys(dataContext);

            RuleFor(p => p.Name)
                    .NotEmpty();

            RuleFor(p => p.Status)
                    .NotEmpty()
                    .IsInEnum();
        }

        /// <summary>
        /// This is used to check if record is valid by Id.
        /// </summary>
        /// <param name="id">Id to be checked</param>
        /// <returns>False if not valid, otherwise true.</returns>
        private bool IdMustBeValid(int id)
        {
            if (_context.Assets.Where(x => x.Id == id).Count() != 1)
            {
                return false;
            }

            return true;
        }

        private void ValidForeignKeys(DataContext dataContext)
        {
            RuleFor(p => p.SupplierId)
                    .Must(new UpdateSupplierValidator(dataContext, false).IdMustBeValid)
                        .When(p => p.SupplierId.HasValue)
                        .WithMessage(MessageHelper.IsNotValid);

            RuleFor(p => p.ModelId)
                    .NotEmpty()
                    .Must(new UpdateModelValidator(dataContext, false).IdMustBeValid)
                        .When(p => p.ModelId.HasValue)
                        .WithMessage(MessageHelper.IsNotValid);

            RuleFor(p => p.ProcessorId)
                    .Must(new UpdateProcessorValidator(dataContext, false).IdMustBeValid)
                        .When(p => p.ProcessorId.HasValue)
                        .WithMessage(MessageHelper.IsNotValid);

            RuleFor(p => p.MemoryId)
                    .Must(new UpdateMemorySizeValidator(dataContext, false).IdMustBeValid)
                        .When(p => p.MemoryId.HasValue)
                        .WithMessage(MessageHelper.IsNotValid);

            RuleFor(p => p.VideoCardId)
                    .Must(new UpdateVideoCardSizeValidator(dataContext, false).IdMustBeValid)
                        .When(p => p.VideoCardId.HasValue)
                        .WithMessage(MessageHelper.IsNotValid);

            RuleFor(p => p.HardDiskId)
                    .Must(new UpdateHardDiskSizeValidator(dataContext, false).IdMustBeValid)
                        .When(p => p.HardDiskId.HasValue)
                        .WithMessage(MessageHelper.IsNotValid);

            RuleFor(p => p.ManufacturerId)
                    .Must(new UpdateManufacturerValidator(dataContext, false).IdMustBeValid)
                        .When(p => p.ManufacturerId.HasValue)
                        .WithMessage(MessageHelper.IsNotValid);

            RuleFor(p => p.CategoryId)
                    .Must(new UpdateCategoryValidator(dataContext, false).IdMustBeValid)
                        .When(p => p.CategoryId.HasValue)
                        .WithMessage(MessageHelper.IsNotValid);
        }

    }
}
