using AM.API.Helpers;
using AM.Core.Helper.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AM.API.Services.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly DataContext _context;

        public DashboardService(DataContext dataContext)
        {
            _context = dataContext;
        }
        public object TotalNumbers()
        {
            int totalCategory = _context.Categories.Count();
            int totalManufacturer = _context.Manufacturers.Count();
            int totalSupplier = _context.Suppliers.Count();
            int totalModel = _context.Models.Count();
            int totalProcessor = _context.Processors.Count();
            int totalHardDisk = _context.HardDiskSizes.Count();
            int totalMemory = _context.MemorySizes.Count();
            int totalVideoCard = _context.VideoCardSizes.Count();
            int totalAsset = _context.Assets.Count();
            int totalUser = _context.Users.Count();
            return new
            {
                category = totalCategory,
                manufacturer = totalManufacturer,
                supplier = totalSupplier,
                model = totalModel,
                processor = totalProcessor,
                harddisk = totalHardDisk,
                memory = totalMemory,
                videocard = totalVideoCard,
                asset = totalAsset,
                user = totalUser
            };
        }

        public object Activity()
        {


            var result = 
                (
                    (
                        // DateTime.Now.Date.CompareTo(x.DateCreated) &&
                        //x.DateCreated < DateTime.Now.AddDays(1)
                        _context.Categories.Where(x => 
                        (   DateTime.Now.Date == x.DateCreated.Value.Date
                                && 
                            x.DateCreated.Value.Date < DateTime.Now.AddDays(1).Date)
                        ||
                        (
                            DateTime.Now.Date== x.DateUpdated.Value.Date
                                &&
                            x.DateUpdated.Value.Date < DateTime.Now.AddDays(1).Date
                        )
                        
                        )
                                
                        .Select(p =>
                            new
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Menu = "Category",
                                ActionType = (p.DateUpdated == null) ? 1 : (p.DateUpdated > p.DateCreated) ? 2 : 1,
                                Date = (p.DateUpdated == null) ? p.DateCreated : (p.DateUpdated > p.DateCreated) ? p.DateUpdated : p.DateCreated,
                            })
                    ).Union
                    (
                        _context.Manufacturers.Where(x =>
                        (DateTime.Now.Date == x.DateCreated.Value.Date
                                &&
                            x.DateCreated.Value.Date < DateTime.Now.AddDays(1).Date)
                        ||
                        (
                            DateTime.Now.Date == x.DateUpdated.Value.Date
                                &&
                            x.DateUpdated.Value.Date < DateTime.Now.AddDays(1).Date
                        )

                        ).Select(p =>
                            new
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Menu = "Manufacturer",
                                ActionType = (p.DateUpdated == null) ? 1 : (p.DateUpdated > p.DateCreated) ? 2 : 1,
                                Date = (p.DateUpdated == null) ? p.DateCreated : (p.DateUpdated > p.DateCreated) ? p.DateUpdated : p.DateCreated,
                            })
                    ).Union
                    (
                        _context.Models.Where(x =>
                        (DateTime.Now.Date == x.DateCreated.Value.Date
                                &&
                            x.DateCreated.Value.Date < DateTime.Now.AddDays(1).Date)
                        ||
                        (
                            DateTime.Now.Date == x.DateUpdated.Value.Date
                                &&
                            x.DateUpdated.Value.Date < DateTime.Now.AddDays(1).Date
                        )

                        ).Select(p =>
                            new
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Menu = "Model",
                                ActionType = (p.DateUpdated == null) ? 1 : (p.DateUpdated > p.DateCreated) ? 2 : 1,
                                Date = (p.DateUpdated == null) ? p.DateCreated : (p.DateUpdated > p.DateCreated) ? p.DateUpdated : p.DateCreated,
                            })
                    ).Union
                    (
                        _context.Suppliers.Where(x =>
                        (DateTime.Now.Date == x.DateCreated.Value.Date
                                &&
                            x.DateCreated.Value.Date < DateTime.Now.AddDays(1).Date)
                        ||
                        (
                            DateTime.Now.Date == x.DateUpdated.Value.Date
                                &&
                            x.DateUpdated.Value.Date < DateTime.Now.AddDays(1).Date
                        )

                        ).Select(p =>
                            new
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Menu = "Supplier",
                                ActionType = (p.DateUpdated == null) ? 1 : (p.DateUpdated > p.DateCreated) ? 2 : 1,
                                Date = (p.DateUpdated == null) ? p.DateCreated : (p.DateUpdated > p.DateCreated) ? p.DateUpdated : p.DateCreated,
                            })
                    ).Union
                    (
                        _context.Processors.Where(x =>
                        (DateTime.Now.Date == x.DateCreated.Value.Date
                                &&
                            x.DateCreated.Value.Date < DateTime.Now.AddDays(1).Date)
                        ||
                        (
                            DateTime.Now.Date == x.DateUpdated.Value.Date
                                &&
                            x.DateUpdated.Value.Date < DateTime.Now.AddDays(1).Date
                        )

                        ).Select(p =>
                            new
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Menu = "Processor",
                                ActionType = (p.DateUpdated == null) ? 1 : (p.DateUpdated > p.DateCreated) ? 2 : 1,
                                Date = (p.DateUpdated == null) ? p.DateCreated : (p.DateUpdated > p.DateCreated) ? p.DateUpdated : p.DateCreated,
                            })
                    ).Union
                    (
                        _context.HardDiskSizes.Where(x =>
                        (DateTime.Now.Date == x.DateCreated.Value.Date
                                &&
                            x.DateCreated.Value.Date < DateTime.Now.AddDays(1).Date)
                        ||
                        (
                            DateTime.Now.Date == x.DateUpdated.Value.Date
                                &&
                            x.DateUpdated.Value.Date < DateTime.Now.AddDays(1).Date
                        )

                        ).Select(p =>
                            new
                            {
                                Id = p.Id,
                                Name = p.Size,
                                Menu = "Harddisk",
                                ActionType = (p.DateUpdated == null) ? 1 : (p.DateUpdated > p.DateCreated) ? 2 : 1,
                                Date = (p.DateUpdated == null) ? p.DateCreated : (p.DateUpdated > p.DateCreated) ? p.DateUpdated : p.DateCreated,
                            })
                    ).Union
                    (
                        _context.MemorySizes.Where(x =>
                        (DateTime.Now.Date == x.DateCreated.Value.Date
                                &&
                            x.DateCreated.Value.Date < DateTime.Now.AddDays(1).Date)
                        ||
                        (
                            DateTime.Now.Date == x.DateUpdated.Value.Date
                                &&
                            x.DateUpdated.Value.Date < DateTime.Now.AddDays(1).Date
                        )

                        ).Select(p =>
                            new
                            {
                                Id = p.Id,
                                Name = p.Size,
                                Menu = "Memory",
                                ActionType = (p.DateUpdated == null) ? 1 : (p.DateUpdated > p.DateCreated) ? 2 : 1,
                                Date = (p.DateUpdated == null) ? p.DateCreated : (p.DateUpdated > p.DateCreated) ? p.DateUpdated : p.DateCreated,
                            })
                    ).Union
                    (
                        _context.VideoCardSizes.Where(x =>
                        (DateTime.Now.Date == x.DateCreated.Value.Date
                                &&
                            x.DateCreated.Value.Date < DateTime.Now.AddDays(1).Date)
                        ||
                        (
                            DateTime.Now.Date == x.DateUpdated.Value.Date
                                &&
                            x.DateUpdated.Value.Date < DateTime.Now.AddDays(1).Date
                        )

                        ).Select(p =>
                            new
                            {
                                Id = p.Id,
                                Name = p.Size,
                                Menu = "Videocard",
                                ActionType = (p.DateUpdated == null) ? 1 : (p.DateUpdated > p.DateCreated) ? 2 : 1,
                                Date = (p.DateUpdated == null) ? p.DateCreated : (p.DateUpdated > p.DateCreated) ? p.DateUpdated : p.DateCreated,
                            })
                    ).Union
                    (
                        _context.Assets.Where(x =>
                        (DateTime.Now.Date == x.DateCreated.Value.Date
                                &&
                            x.DateCreated.Value.Date < DateTime.Now.AddDays(1).Date)
                        ||
                        (
                            DateTime.Now.Date == x.DateUpdated.Value.Date
                                &&
                            x.DateUpdated.Value.Date < DateTime.Now.AddDays(1).Date
                        )

                        ).Select(p =>
                            new
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Menu = "Asset",
                                ActionType = (p.DateUpdated == null) ? 1 : (p.DateUpdated > p.DateCreated) ? 2 : 1,
                                Date = (p.DateUpdated == null) ? p.DateCreated : (p.DateUpdated > p.DateCreated) ? p.DateUpdated : p.DateCreated,
                            })
                    ).Union
                    (
                        _context.Users.Where(x =>
                        (DateTime.Now.Date == x.DateCreated.Value.Date
                                &&
                            x.DateCreated.Value.Date < DateTime.Now.AddDays(1).Date)
                        ||
                        (
                            DateTime.Now.Date == x.DateUpdated.Value.Date
                                &&
                            x.DateUpdated.Value.Date < DateTime.Now.AddDays(1).Date
                        )

                        ).Select(p =>
                            new
                            {
                                Id = p.Id,
                                Name = p.FullName,
                                Menu = "User",
                                ActionType = (p.DateUpdated == null) ? 1 : (p.DateUpdated > p.DateCreated) ? 2 : 1,
                                Date = (p.DateUpdated == null) ? p.DateCreated : (p.DateUpdated > p.DateCreated) ? p.DateUpdated : p.DateCreated,
                            })
                    )
                 ).OrderByDescending(x=>x.Date);

            GetAllResponse response = null;

            response = new GetAllResponse(result.Count());

            response.List.AddRange(result);

            return response;
        }


        public object TotalChartNumbers()
        {
            int totalCategory = _context.Categories.Count();
            int totalManufacturer = _context.Manufacturers.Count();
            int totalSupplier = _context.Suppliers.Count();
            int totalModel = _context.Models.Count();
            int totalProcessor = _context.Processors.Count();
            int totalHardDisk = _context.HardDiskSizes.Count();
            int totalMemory = _context.MemorySizes.Count();
            int totalVideoCard = _context.VideoCardSizes.Count();
            int totalAsset = _context.Assets.Count();
            int totalUser = _context.Users.Count();

            List<Dictionary<string, int>> list = new List<Dictionary<string, int>>();
            Dictionary<string, int> items = new Dictionary<string, int>();
            Dictionary<string, int> items1 = new Dictionary<string, int>();
            Dictionary<string, int> items2 = new Dictionary<string, int>();
            Dictionary<string, int> items3 = new Dictionary<string, int>();
            Dictionary<string, int> items4 = new Dictionary<string, int>();
            Dictionary<string, int> items5 = new Dictionary<string, int>();
            Dictionary<string, int> items6 = new Dictionary<string, int>();
            Dictionary<string, int> items7 = new Dictionary<string, int>();
            Dictionary<string, int> items8 = new Dictionary<string, int>();
            Dictionary<string, int> items9 = new Dictionary<string, int>();


            items.Add("Category", totalCategory);
            list.Add(items);

            items1.Add("Manufacturer", totalManufacturer);
            list.Add(items1);

            items2.Add("Supplier", totalSupplier);
            list.Add(items2);

            items3.Add("Model", totalModel);
            list.Add(items3);

            items4.Add("Processor", totalProcessor);
            list.Add(items4);

            items5.Add("Harddisk", totalHardDisk);
            list.Add(items5);

            items6.Add("Memory", totalMemory);
            list.Add(items6);

            items7.Add("Videocard", totalVideoCard);
            list.Add(items7);

            items8.Add("Asset", totalAsset);
            list.Add(items8);

            items9.Add("User", totalUser);
            list.Add(items9);

            return list;
        }
    }
}
