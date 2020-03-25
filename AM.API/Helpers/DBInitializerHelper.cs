using AM.API.Services.Assets;
using AM.API.Services.Categories;
using AM.API.Services.Manufacturers;
using AM.API.Services.Models;
using AM.API.Services.Processors;
using AM.API.Services.Sizes;
using AM.API.Services.Suppliers;
using AM.API.Services.Users;
using AM.Core.Domain.Assets;
using AM.Core.Domain.Categories;
using AM.Core.Domain.Manufacturers;
using AM.Core.Domain.Models;
using AM.Core.Domain.Processors;
using AM.Core.Domain.Sizes;
using AM.Core.Domain.Suppliers;
using AM.Core.Domain.Users;
using System.Linq;

namespace AM.API.Helpers
{
    public static class DBInitializerHelper
    {

        public static void CreateDefaultData(DataContext context)
        {
            context.Database.EnsureCreated();

            AddDefaultUsers(context);

            AddDataForTesting(context);
        }

        private static void AddDefaultUsers(DataContext context)
        {
            // Look for any users
            if (context.Users.Any())
            {
                // DB has been seeded
                return;
            }

            var service = new UserService(context);

            var adminUser = new User
            {
                FullName = "AM Administrator",
                UserName = "admin",
            };
            service.Add(adminUser, "blotocol");

        }

        private static void AddDataForTesting(DataContext context)
        {

            #region Model
            var modelMinRequiredRecord = 1000;
            var modelId = 0;
            var modelService = new ModelService(context);

            if (context.Models.LongCount() <= modelMinRequiredRecord)
            {
                for (var i = 0; i <= modelMinRequiredRecord; i++)
                {
                    var obj = new Model
                    {
                        Name = string.Format("Model {0}", (i+1))
                    };

                    modelService.Add(obj);

                    if (modelId == 0)
                    {
                        modelId = obj.Id;
                    }

                }
            }
            #endregion

            #region Category
            var categoryMinRequiredRecord = 1000;
            if (context.Categories.LongCount() <= categoryMinRequiredRecord)
            {
                var categoryService = new CategoryService(context);

                for (var i = 0; i <= categoryMinRequiredRecord; i++)
                {
                    var obj = new Category
                    {
                        Name = string.Format("Category {0}", (i + 1))
                    };

                    categoryService.Add(obj);
                }
            }
            #endregion

            #region Manufacturer
            var manufacturerMinRequiredRecord = 1000;
            if (context.Manufacturers.LongCount() <= manufacturerMinRequiredRecord)
            {
                var manufacturerService = new ManufacturerService(context);

                for (var i = 0; i <= manufacturerMinRequiredRecord; i++)
                {
                    var obj = new Manufacturer
                    {
                        Name = string.Format("Manufacturer {0}", (i + 1))
                    };

                    manufacturerService.Add(obj);
                }
            }
            #endregion

            #region Processor
            var processorMinRequiredRecord = 1000;
            if (context.Processors.LongCount() <= processorMinRequiredRecord)
            {
                var processorService = new ProcessorService(context);

                for (var i = 0; i <= processorMinRequiredRecord; i++)
                {
                    var obj = new Processor
                    {
                        Name = string.Format("Processor {0}", (i + 1))
                    };

                    processorService.Add(obj);
                }
            }
            #endregion

            #region Size

            var hardDiskMinRequiredRecord = 1000;
            if (context.HardDiskSizes.LongCount() <= hardDiskMinRequiredRecord)
            {
                var hdService = new HardDiskSizeService(context);

                for (var i = 0; i <= hardDiskMinRequiredRecord; i++)
                {
                    var obj = new HardDisk
                    {
                        Size = string.Format("{0}", (i + 1))
                    };

                    hdService.Add(obj);
                }
            }

            var memoryMinRequiredRecord = 1000;
            if (context.MemorySizes.LongCount() <= memoryMinRequiredRecord)
            {
                var ramService = new MemorySizeService(context);

                for (var i = 0; i <= memoryMinRequiredRecord; i++)
                {
                    var obj = new Memory
                    {
                        Size = string.Format("{0}", (i + 1))
                    };

                    ramService.Add(obj);
                }
            }

            var videoCardMinRequiredRecord = 1000;
            if (context.VideoCardSizes.LongCount() <= videoCardMinRequiredRecord)
            {
                var vcService = new VideoCardSizeService(context);

                for (var i = 0; i <= videoCardMinRequiredRecord; i++)
                {
                    var obj = new VideoCard
                    {
                        Size = string.Format("{0}", (i + 1))
                    };

                    vcService.Add(obj);
                }
            }

            #endregion

            #region Supplier
            var supplierMinRequiredRecord = 1000;
            if (context.Suppliers.LongCount() <= supplierMinRequiredRecord)
            {
                var supplierService = new SupplierService(context);

                for (int i = 0; i <= supplierMinRequiredRecord; i++)
                {
                    var obj = new Supplier
                    {
                        Name = "Supplier " + i
                    };

                    supplierService.Add(obj);
                }
            }
            #endregion

            #region User
            var userMinRequiredRecord = 1000;
            if (context.Users.LongCount() <= userMinRequiredRecord)
            {
                var userService = new UserService(context);

                for (var i = 0; i <= userMinRequiredRecord; i++)
                {
                    var obj = new User
                    {
                        FullName = "User " + (i + 1),
                        UserName = "user000" + (i + 1),
                    };

                    userService.Add(obj, "blotocol");
                }
            }
            #endregion

            #region Asset
            var assetMinRequiredRecord = 5000;
            if (context.Assets.LongCount() <= assetMinRequiredRecord)
            {
                var service = new AssetService(context);
                for (int i = 0; i <= assetMinRequiredRecord; i++)
                {
                    var obj = new Asset
                    {
                        AssetTag = "Asset Tag" + i,
                        Name = "Asset Name" + i,
                        Status = StatusType.Available,
                        ModelId = modelId
                    };

                    service.Add(obj);
                }
            }
            #endregion

        }

    }
}
