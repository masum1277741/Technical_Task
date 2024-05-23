﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TECHNICALTASK.Models;

#nullable disable

namespace TECHNICALTASK.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240522165825_Initial Create")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TECHNICALTASK.Models.DetailsTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MasterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MasterId");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("TECHNICALTASK.Models.MasterTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NumberofItem")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Masters");
                });

            modelBuilder.Entity("TECHNICALTASK.Models.DetailsTable", b =>
                {
                    b.HasOne("TECHNICALTASK.Models.MasterTable", "Master")
                        .WithMany("Details")
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Master");
                });

            modelBuilder.Entity("TECHNICALTASK.Models.MasterTable", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}
