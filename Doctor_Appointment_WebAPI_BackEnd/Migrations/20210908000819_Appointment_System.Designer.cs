﻿// <auto-generated />
using System;
using Doctor_Appointment_WebAPI_BackEnd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Doctor_Appointment_WebAPI_BackEnd.Migrations
{
    [DbContext(typeof(Doctor_Appointment_WebAPI_BackEndContext))]
    [Migration("20210908000819_Appointment_System")]
    partial class Appointment_System
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Doctor_Appointment_WebAPI_BackEnd.Models.Appointment_Details", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Appointment")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Doctor_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Patient_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Doctor_Id");

                    b.HasIndex("Patient_Id");

                    b.ToTable("Appointment_Details");
                });

            modelBuilder.Entity("Doctor_Appointment_WebAPI_BackEnd.Models.Doctor_Details", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Doctor_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Doctor_Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Doctor_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Doctor_Specialization")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctor_Details");
                });

            modelBuilder.Entity("Doctor_Appointment_WebAPI_BackEnd.Models.Patient_Details", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Patient_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patient_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patient_Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patient_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patient_Details");
                });

            modelBuilder.Entity("Doctor_Appointment_WebAPI_BackEnd.Models.Appointment_Details", b =>
                {
                    b.HasOne("Doctor_Appointment_WebAPI_BackEnd.Models.Doctor_Details", "Doctor_")
                        .WithMany()
                        .HasForeignKey("Doctor_Id");

                    b.HasOne("Doctor_Appointment_WebAPI_BackEnd.Models.Patient_Details", "Patient_")
                        .WithMany()
                        .HasForeignKey("Patient_Id");

                    b.Navigation("Doctor_");

                    b.Navigation("Patient_");
                });
#pragma warning restore 612, 618
        }
    }
}