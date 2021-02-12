﻿// <auto-generated />
using System;
using ATKManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ATKManager.Migrations.AppDb
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210210123310_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ATKManager.Models.Court", b =>
                {
                    b.Property<int>("CourtID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourtName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourtID");

                    b.ToTable("Court");
                });

            modelBuilder.Entity("ATKManager.Models.CourtScheduleItem", b =>
                {
                    b.Property<int>("TimeTableID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourtID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("TimeTableID");

                    b.HasIndex("CourtID");

                    b.ToTable("CourtSchedule");
                });

            modelBuilder.Entity("ATKManager.Models.Trainer", b =>
                {
                    b.Property<int>("TrainerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrainerId");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("ATKManager.Models.CourtScheduleItem", b =>
                {
                    b.HasOne("ATKManager.Models.Court", "Court")
                        .WithMany("CourtScheduleItems")
                        .HasForeignKey("CourtID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Court");
                });

            modelBuilder.Entity("ATKManager.Models.Court", b =>
                {
                    b.Navigation("CourtScheduleItems");
                });
#pragma warning restore 612, 618
        }
    }
}
