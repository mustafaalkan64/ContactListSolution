﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SeturContactList.Repository;

namespace SeturContactList.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220215070025_ID-to-UUID-Converting-v2")]
    partial class IDtoUUIDConvertingv2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("SeturContactList.Core.Entities.PersonContacts", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Info")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<decimal>("Lat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Long")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uuid");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonContacts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d1bbfb72-f58a-4552-8548-026a8c33f395"),
                            Address = "İzmir Çiğli",
                            City = "İzmir",
                            CreatedDate = new DateTime(2022, 2, 15, 10, 0, 25, 94, DateTimeKind.Local).AddTicks(8261),
                            Email = "mustafaalkan64@gmail.com",
                            Info = "Test Info",
                            Lat = 34m,
                            Long = 27m,
                            PersonId = new Guid("a36f226f-bb10-46bb-b4e4-f2e6517b88d7"),
                            Phone = "+905553332211",
                            Town = "Çiğli"
                        },
                        new
                        {
                            Id = new Guid("5da4b2f8-55b0-4d08-8c7a-d7d343ea7109"),
                            Address = "İzmir Bornova",
                            City = "İzmir",
                            CreatedDate = new DateTime(2022, 2, 15, 10, 0, 25, 94, DateTimeKind.Local).AddTicks(8297),
                            Email = "mustafaalkan64@gmail.com",
                            Info = "Test Info",
                            Lat = 34m,
                            Long = 27m,
                            PersonId = new Guid("a36f226f-bb10-46bb-b4e4-f2e6517b88d7"),
                            Phone = "+905553332212",
                            Town = "Bornova"
                        },
                        new
                        {
                            Id = new Guid("c8827037-a183-40b9-a7ab-0e489548c577"),
                            Address = "İzmir Çiğli",
                            City = "İzmir",
                            CreatedDate = new DateTime(2022, 2, 15, 10, 0, 25, 94, DateTimeKind.Local).AddTicks(8305),
                            Email = "mustafaalkan64@gmail.com",
                            Info = "Test Info",
                            Lat = 38m,
                            Long = 26m,
                            PersonId = new Guid("0506db6a-b729-492d-86fd-d44f3bbf51be"),
                            Phone = "+905553332211",
                            Town = "Çiğli"
                        },
                        new
                        {
                            Id = new Guid("51ae353c-14e7-428d-a6a2-d89c4f6a7450"),
                            Address = "İzmir Bornova",
                            City = "İzmir",
                            CreatedDate = new DateTime(2022, 2, 15, 10, 0, 25, 94, DateTimeKind.Local).AddTicks(8309),
                            Email = "mustafaalkan64@gmail.com",
                            Info = "Test Info",
                            Lat = 38m,
                            Long = 26m,
                            PersonId = new Guid("a36f226f-bb10-46bb-b4e4-f2e6517b88d7"),
                            Phone = "+905553332212",
                            Town = "Bornova"
                        });
                });

            modelBuilder.Entity("SeturContactList.Core.Entities.Persons", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a36f226f-bb10-46bb-b4e4-f2e6517b88d7"),
                            Company = "TestCompany",
                            CreatedDate = new DateTime(2022, 2, 15, 10, 0, 25, 89, DateTimeKind.Local).AddTicks(8959),
                            Name = "Mustafa",
                            Surname = "Alkan"
                        },
                        new
                        {
                            Id = new Guid("0506db6a-b729-492d-86fd-d44f3bbf51be"),
                            Company = "TestCompany1",
                            CreatedDate = new DateTime(2022, 2, 15, 10, 0, 25, 94, DateTimeKind.Local).AddTicks(3026),
                            Name = "Ahmet",
                            Surname = "Alkan"
                        });
                });

            modelBuilder.Entity("SeturContactList.Core.Entities.ReportDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Lat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Long")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RegisteredPersonCount")
                        .HasColumnType("integer");

                    b.Property<int>("RegisteredPhoneCount")
                        .HasColumnType("integer");

                    b.Property<Guid>("ReportId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ReportId")
                        .IsUnique();

                    b.ToTable("ReportDetail");
                });

            modelBuilder.Entity("SeturContactList.Core.Entities.Reports", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("ReportStatus")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<DateTime>("RequestedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("SeturContactList.Core.Entities.PersonContacts", b =>
                {
                    b.HasOne("SeturContactList.Core.Entities.Persons", "Person")
                        .WithMany("PersonContacts")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("SeturContactList.Core.Entities.ReportDetail", b =>
                {
                    b.HasOne("SeturContactList.Core.Entities.Reports", "Report")
                        .WithOne("ReportDetail")
                        .HasForeignKey("SeturContactList.Core.Entities.ReportDetail", "ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Report");
                });

            modelBuilder.Entity("SeturContactList.Core.Entities.Persons", b =>
                {
                    b.Navigation("PersonContacts");
                });

            modelBuilder.Entity("SeturContactList.Core.Entities.Reports", b =>
                {
                    b.Navigation("ReportDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
