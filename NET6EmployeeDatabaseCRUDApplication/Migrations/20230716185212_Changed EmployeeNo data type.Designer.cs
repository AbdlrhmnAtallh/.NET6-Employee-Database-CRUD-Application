﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NET6EmployeeDatabaseCRUDApplication.Models;

#nullable disable

namespace NET6EmployeeDatabaseCRUDApplication.Migrations
{
    [DbContext(typeof(HRDatabaseContext))]
    [Migration("20230716185212_Changed EmployeeNo data type")]
    partial class ChangedEmployeeNodatatype
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NET6EmployeeDatabaseCRUDApplication.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentAbbr")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department", "dbo");
                });

            modelBuilder.Entity("NET6EmployeeDatabaseCRUDApplication.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeNo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<decimal>("GrossSalary")
                        .HasColumnType("decimal(12,2)");

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<decimal>("NetSalary")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee", "dbo");
                });

            modelBuilder.Entity("NET6EmployeeDatabaseCRUDApplication.Models.Employee", b =>
                {
                    b.HasOne("NET6EmployeeDatabaseCRUDApplication.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}