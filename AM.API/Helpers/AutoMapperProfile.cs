using AM.API.DTOs.Assets;
using AM.API.DTOs.Categories;
using AM.API.DTOs.Manufacturers;
using AM.API.DTOs.Models;
using AM.API.DTOs.Processors;
using AM.API.DTOs.Sizes.HardDisk;
using AM.API.DTOs.Sizes.Memory;
using AM.API.DTOs.Sizes.VideoCard;
using AM.API.DTOs.Suppliers;
using AM.API.DTOs.Users;
using AM.Core.Domain.Assets;
using AM.Core.Domain.Categories;
using AM.Core.Domain.Manufacturers;
using AM.Core.Domain.Models;
using AM.Core.Domain.Processors;
using AM.Core.Domain.Sizes;
using AM.Core.Domain.Suppliers;
using AM.Core.Domain.Users;
using AutoMapper;

namespace AM.API.Helpers
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {

            #region Manufacturer

            CreateMap<AddManufacturer, Manufacturer>();

            CreateMap<UpdateManufacturer, Manufacturer>()

                    //  Disregard DateCreated on update
                    .ForMember(p => p.DateCreated, opt =>
                    {
                        opt.UseDestinationValue();
                        opt.Ignore();
                    });

            #endregion

            #region Category

            CreateMap<AddCategory, Category>();

            CreateMap<UpdateCategory, Category>()

                    //  Disregard DateCreated on update
                    .ForMember(p => p.DateCreated, opt =>
                    {
                        opt.UseDestinationValue();
                        opt.Ignore();
                    });

            #endregion

            #region Size

            CreateMap<AddHardDisk, HardDisk>();

            CreateMap<UpdateHardDisk, HardDisk>()

                    //  Disregard DateCreated on update
                    .ForMember(p => p.DateCreated, opt =>
                    {
                        opt.UseDestinationValue();
                        opt.Ignore();
                    });

            CreateMap<AddMemory, Memory>();

            CreateMap<UpdateMemory, Memory>()

                    //  Disregard DateCreated on update
                    .ForMember(p => p.DateCreated, opt =>
                    {
                        opt.UseDestinationValue();
                        opt.Ignore();
                    });

            CreateMap<AddVideoCard, VideoCard>();

            CreateMap<UpdateVideoCard, VideoCard>()

                    //  Disregard DateCreated on update
                    .ForMember(p => p.DateCreated, opt =>
                    {
                        opt.UseDestinationValue();
                        opt.Ignore();
                    });

            #endregion

            #region Supplier

            CreateMap<AddSupplier, Supplier>();

            CreateMap<UpdateSupplier, Supplier>()

                    //  Disregard DateCreated on update
                    .ForMember(p => p.DateCreated, opt =>
                    {
                        opt.UseDestinationValue();
                        opt.Ignore();
                    });

            #endregion

            #region Model

            CreateMap<AddModel, Model>();

            CreateMap<UpdateModel, Model>()

                    //  Disregard DateCreated on update
                    .ForMember(p => p.DateCreated, opt =>
                    {
                        opt.UseDestinationValue();
                        opt.Ignore();
                    });

            #endregion

            #region Processor

            CreateMap<AddProcessor, Processor>();

            CreateMap<UpdateProcessor, Processor>()

                    //  Disregard DateCreated on update
                    .ForMember(p => p.DateCreated, opt =>
                    {
                        opt.UseDestinationValue();
                        opt.Ignore();
                    });

            #endregion

            #region Asset

            CreateMap<AddAsset, Asset>();

            CreateMap<UpdateAsset, Asset>()

                    //  Disregard DateCreated on update
                    .ForMember(p => p.DateCreated, opt =>
                    {
                        opt.UseDestinationValue();
                        opt.Ignore();
                    });

            #endregion

            #region User

            CreateMap<AddUser, User>();

            CreateMap<UpdateUser, User>()

                    //  Disregard DateCreated on update
                    .ForMember(p => p.DateCreated, opt =>
                    {
                        opt.UseDestinationValue();
                        opt.Ignore();
                    });

            #endregion

        }

    }
}
