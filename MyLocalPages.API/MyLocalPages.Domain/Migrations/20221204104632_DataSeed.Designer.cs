// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyLocalPages.Domain;

#nullable disable

namespace MyLocalPages.Domain.Migrations
{
    [DbContext(typeof(MyLocalPagesContext))]
    [Migration("20221204104632_DataSeed")]
    partial class DataSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.11");

            modelBuilder.Entity("MyLocalPages.Domain.Entities.BusinessDirectory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BusinessDirectories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("17e4e315-cdf5-436e-8851-f219f0f54081"),
                            Name = "Accommodation, Travel & Tours"
                        },
                        new
                        {
                            Id = new Guid("583c52b3-3238-4452-ab53-b1ab8edf0188"),
                            Name = "Animals & Pets"
                        },
                        new
                        {
                            Id = new Guid("6e1c009f-8cea-4c0b-9db6-b109f1da2a58"),
                            Name = "Arts, Crafts & Collectables"
                        });
                });

            modelBuilder.Entity("MyLocalPages.Domain.Entities.DirectoryCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BusinessDirectoryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BusinessDirectoryId");

                    b.ToTable("DirectoryCategories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b80fed0e-db42-419d-9ef6-a7cfd0a07140"),
                            BusinessDirectoryId = new Guid("17e4e315-cdf5-436e-8851-f219f0f54081"),
                            Name = "Accommodation Booking & Inquiry Services"
                        },
                        new
                        {
                            Id = new Guid("caa52878-f8e7-451f-8d22-ebc8480906d3"),
                            BusinessDirectoryId = new Guid("17e4e315-cdf5-436e-8851-f219f0f54081"),
                            Name = "Adventure Tours & Holidays Packages"
                        },
                        new
                        {
                            Id = new Guid("1ea72204-db2f-4f1d-addb-61337618d2b1"),
                            BusinessDirectoryId = new Guid("583c52b3-3238-4452-ab53-b1ab8edf0188"),
                            Name = "Animal Welfare"
                        },
                        new
                        {
                            Id = new Guid("0ab4c79b-27f6-46f6-b07d-50491abaaa18"),
                            BusinessDirectoryId = new Guid("583c52b3-3238-4452-ab53-b1ab8edf0188"),
                            Name = "Aquaponics"
                        },
                        new
                        {
                            Id = new Guid("28c751b1-87a7-4392-9bc9-a6d1e3935317"),
                            BusinessDirectoryId = new Guid("6e1c009f-8cea-4c0b-9db6-b109f1da2a58"),
                            Name = "Aboriginal Art & Crafts"
                        },
                        new
                        {
                            Id = new Guid("50ae7fcb-4aaa-4ed7-a74a-15ea9f0e8749"),
                            BusinessDirectoryId = new Guid("6e1c009f-8cea-4c0b-9db6-b109f1da2a58"),
                            Name = "Antiques Auctions & Dealers"
                        });
                });

            modelBuilder.Entity("MyLocalPages.Domain.Entities.DirectoryCategory", b =>
                {
                    b.HasOne("MyLocalPages.Domain.Entities.BusinessDirectory", "BusinessDirectory")
                        .WithMany("Categories")
                        .HasForeignKey("BusinessDirectoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusinessDirectory");
                });

            modelBuilder.Entity("MyLocalPages.Domain.Entities.BusinessDirectory", b =>
                {
                    b.Navigation("Categories");
                });
#pragma warning restore 612, 618
        }
    }
}
