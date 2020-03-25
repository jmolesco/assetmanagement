﻿// <auto-generated />
using AM.API.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AM.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180525035756_CreatedCategoryTable")]
    partial class CreatedCategoryTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AM.Core.Domain.Categories.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<string>("Name")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AM.Core.Domain.Manufacturers.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");
                });
#pragma warning restore 612, 618
        }
    }
}
