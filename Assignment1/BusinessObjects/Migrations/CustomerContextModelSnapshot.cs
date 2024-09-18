﻿// <auto-generated />
using System;
using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusinessObjects.Migrations
{
    [DbContext(typeof(CustomerContext))]
    partial class CustomerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusinessObjects.Customer", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Username");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Username = "Hoa",
                            Address = "CT",
                            Birthday = new DateTime(2020, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fullname = "Hoa Hoa",
                            Gender = "Female",
                            Password = "1"
                        },
                        new
                        {
                            Username = "Lan",
                            Address = "HCM",
                            Birthday = new DateTime(2004, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fullname = "Lan Lan",
                            Gender = "Female",
                            Password = "2"
                        },
                        new
                        {
                            Username = "Nam",
                            Address = "HN",
                            Birthday = new DateTime(2000, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fullname = "Nam Nam",
                            Gender = "Male",
                            Password = "3"
                        },
                        new
                        {
                            Username = "Tuan",
                            Address = "CT",
                            Birthday = new DateTime(2009, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fullname = "Tuan Tuan",
                            Gender = "Male",
                            Password = "4"
                        },
                        new
                        {
                            Username = "Dung",
                            Address = "HCM",
                            Birthday = new DateTime(2008, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fullname = "Dung Dung",
                            Gender = "Male",
                            Password = "5"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
