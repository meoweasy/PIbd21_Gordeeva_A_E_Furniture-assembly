﻿// <auto-generated />
using System;
using FurnitureAssemblyDatabaseImplement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FurnitureAssemblyFileImplement.Migrations
{
    [DbContext(typeof(FurnitureAssemblyDatabase))]
    [Migration("20220328170513_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FurnitureAssemblyDatabaseImplement.Models.Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DetailName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("FurnitureAssemblyDatabaseImplement.Models.Furniture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FurnitureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Furnitures");
                });

            modelBuilder.Entity("FurnitureAssemblyDatabaseImplement.Models.FurnitureDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("DetailId")
                        .HasColumnType("int");

                    b.Property<int?>("DetailtId")
                        .HasColumnType("int");

                    b.Property<int>("FurnitureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DetailtId");

                    b.HasIndex("FurnitureId");

                    b.ToTable("FurnitureDetails");
                });

            modelBuilder.Entity("FurnitureAssemblyDatabaseImplement.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateImplement")
                        .HasColumnType("datetime2");

                    b.Property<int>("FurnitureId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("FurnitureId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FurnitureAssemblyDatabaseImplement.Models.FurnitureDetail", b =>
                {
                    b.HasOne("FurnitureAssemblyDatabaseImplement.Models.Detail", "Detail")
                        .WithMany("FurnitureDetails")
                        .HasForeignKey("DetailtId");

                    b.HasOne("FurnitureAssemblyDatabaseImplement.Models.Furniture", "Furniture")
                        .WithMany("FurnitureDetails")
                        .HasForeignKey("FurnitureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Detail");

                    b.Navigation("Furniture");
                });

            modelBuilder.Entity("FurnitureAssemblyDatabaseImplement.Models.Order", b =>
                {
                    b.HasOne("FurnitureAssemblyDatabaseImplement.Models.Furniture", null)
                        .WithMany("Orders")
                        .HasForeignKey("FurnitureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FurnitureAssemblyDatabaseImplement.Models.Detail", b =>
                {
                    b.Navigation("FurnitureDetails");
                });

            modelBuilder.Entity("FurnitureAssemblyDatabaseImplement.Models.Furniture", b =>
                {
                    b.Navigation("FurnitureDetails");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
