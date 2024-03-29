﻿// <auto-generated />
using Foodmandu.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Foodmandu.Migrations
{
    [DbContext(typeof(FoodmanduDbContext))]
    [Migration("20240227110518_YourMigrationName")]
    partial class YourMigrationName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Foodmandu.Model.LayoutItems", b =>
                {
                    b.Property<int>("LayoutItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LayoutItemId"), 1L, 1);

                    b.Property<int>("ParentLayoutItemId")
                        .HasColumnType("int");

                    b.Property<int>("displayOrder")
                        .HasColumnType("int");

                    b.Property<string>("extraInfo1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("extraInfo2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("featured")
                        .HasColumnType("bit");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("layoutId")
                        .HasColumnType("int");

                    b.Property<string>("logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("subtitle1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("subtitle2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("subtitle3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LayoutItemId");

                    b.ToTable("LayoutItems");
                });

            modelBuilder.Entity("Foodmandu.Model.Layouts", b =>
                {
                    b.Property<int>("layoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("layoutId"), 1L, 1);

                    b.Property<string>("SeeMoreJSON")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SliderLinkJSON")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("allowwebdisplay")
                        .HasColumnType("bit");

                    b.Property<int>("displayOrder")
                        .HasColumnType("int");

                    b.Property<string>("layout")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ratio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("seeMore")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tagline")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("webdisplayorder")
                        .HasColumnType("int");

                    b.HasKey("layoutId");

                    b.ToTable("Layouts");
                });
#pragma warning restore 612, 618
        }
    }
}
