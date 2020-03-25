using AM.Core.Domain.Assets;
using AM.Core.Domain.Categories;
using AM.Core.Domain.Manufacturers;
using AM.Core.Domain.Models;
using AM.Core.Domain.Processors;
using AM.Core.Domain.Sizes;
using AM.Core.Domain.Suppliers;
using AM.Core.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace AM.API.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<HardDisk> HardDiskSizes { get; set; }

        public DbSet<Memory> MemorySizes { get; set; }

        public DbSet<VideoCard> VideoCardSizes { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Processor> Processors { get; set; }

        public DbSet<Asset> Assets { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            SetDefaultValues(modelBuilder);

            SetIndexColumns(modelBuilder);

            base.OnModelCreating(modelBuilder);

        }

        private void SetDefaultValues(ModelBuilder modelBuilder)
        {

            #region Asset
            modelBuilder.Entity<Asset>()
                        .Property(p => p.DateCreated)
                        .HasDefaultValueSql("getdate()")
                        .ValueGeneratedOnAdd();
            #endregion

            #region Category
            modelBuilder.Entity<Category>()
                        .Property(p => p.DateCreated)
                        .HasDefaultValueSql("getdate()")
                        .ValueGeneratedOnAdd();
            #endregion

            #region Manufacturer
            modelBuilder.Entity<Manufacturer>()
                        .Property(p => p.DateCreated)
                        .HasDefaultValueSql("getdate()")
                        .ValueGeneratedOnAdd();
            #endregion

            #region Model
            modelBuilder.Entity<Model>()
                        .Property(p => p.DateCreated)
                        .HasDefaultValueSql("getdate()")
                        .ValueGeneratedOnAdd();
            #endregion

            #region Processor
            modelBuilder.Entity<Processor>()
                        .Property(p => p.DateCreated)
                        .HasDefaultValueSql("getdate()")
                        .ValueGeneratedOnAdd();
            #endregion

            #region Size

            #region HardDisk
            modelBuilder.Entity<HardDisk>()
                        .Property(p => p.DateCreated)
                        .HasDefaultValueSql("getdate()")
                        .ValueGeneratedOnAdd();
            #endregion

            #region Memory
            modelBuilder.Entity<Memory>()
                        .Property(p => p.DateCreated)
                        .HasDefaultValueSql("getdate()")
                        .ValueGeneratedOnAdd();
            #endregion

            #region VideoCard
            modelBuilder.Entity<VideoCard>()
                        .Property(p => p.DateCreated)
                        .HasDefaultValueSql("getdate()")
                        .ValueGeneratedOnAdd();
            #endregion

            #endregion

            #region Supplier
            modelBuilder.Entity<Supplier>()
                        .Property(p => p.DateCreated)
                        .HasDefaultValueSql("getdate()")
                        .ValueGeneratedOnAdd();
            #endregion

            #region User
            modelBuilder.Entity<User>()
                        .Property(p => p.DateCreated)
                        .HasDefaultValueSql("getdate()")
                        .ValueGeneratedOnAdd();
            #endregion

        }

        private void SetIndexColumns(ModelBuilder modelBuilder)
        {

            #region Asset
            modelBuilder.Entity<Asset>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.Id,
                                    });
            #endregion

            #region Category
            modelBuilder.Entity<Category>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.Id,
                                    });

            modelBuilder.Entity<Category>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.Name
                                    });

            modelBuilder.Entity<Category>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.Id,
                                        p.Name
                                    });
            #endregion

            #region Manufacturer
            modelBuilder.Entity<Manufacturer>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.Id,
                                    });

            modelBuilder.Entity<Manufacturer>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.Name
                                    });

            modelBuilder.Entity<Manufacturer>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.Id,
                                        p.Name
                                    });
            #endregion

            #region Model
            modelBuilder.Entity<Model>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.Id,
                                    });

            modelBuilder.Entity<Model>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.Name
                                    });

            modelBuilder.Entity<Model>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.Id,
                                        p.Name
                                    });
            #endregion

            #region Processor
            modelBuilder.Entity<Processor>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.Id,
                                    });

            modelBuilder.Entity<Processor>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.Name
                                    });

            modelBuilder.Entity<Processor>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.Id,
                                        p.Name
                                    });
            #endregion

            #region Size

            #region HardDisk
            modelBuilder.Entity<HardDisk>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.Id,
                                    });

            modelBuilder.Entity<HardDisk>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.Size
                                    });

            modelBuilder.Entity<HardDisk>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.Id,
                                        p.Size
                                    });
            #endregion            

            #region Memory
            modelBuilder.Entity<Memory>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.Id,
                                    });

            modelBuilder.Entity<Memory>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.Size
                                    });

            modelBuilder.Entity<Memory>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.Id,
                                        p.Size
                                    });
            #endregion

            #region VideoCard
            modelBuilder.Entity<VideoCard>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.Id,
                                    });

            modelBuilder.Entity<VideoCard>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.Size
                                    });

            modelBuilder.Entity<VideoCard>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.Id,
                                        p.Size
                                    });
            #endregion

            #endregion

            #region Supplier
            modelBuilder.Entity<Supplier>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.Id,
                                    });

            modelBuilder.Entity<Supplier>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.Name
                                    });

            modelBuilder.Entity<Supplier>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.Id,
                                        p.Name
                                    });
            #endregion

            #region User
            modelBuilder.Entity<User>()
                        .HasIndex(p =>
                                    new
                                    {
                                        p.UserName,
                                    });
            #endregion

        }

    }
}
