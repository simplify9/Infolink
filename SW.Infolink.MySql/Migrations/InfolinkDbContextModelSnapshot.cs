﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SW.Infolink;

namespace SW.Infolink.MySql.Migrations
{
    [DbContext(typeof(InfolinkDbContext))]
    partial class InfolinkDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SW.Infolink.Domain.Document", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("BusEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("BusMessageTypeName")
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<int>("DuplicateInterval")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("PromotedProperties")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("BusMessageTypeName")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Documents");

                    b.HasData(
                        new
                        {
                            Id = 10001,
                            BusEnabled = false,
                            DuplicateInterval = 0,
                            Name = "Aggregation Document",
                            PromotedProperties = "{}"
                        });
                });

            modelBuilder.Entity("SW.Infolink.Domain.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Partners");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "SYSTEM"
                        });
                });

            modelBuilder.Entity("SW.Infolink.Domain.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("AggregateOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("AggregationForId")
                        .HasColumnType("int");

                    b.Property<byte>("AggregationTarget")
                        .HasColumnType("tinyint unsigned");

                    b.Property<int>("ConsecutiveFailures")
                        .HasColumnType("int");

                    b.Property<string>("DocumentFilter")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("DocumentId")
                        .HasColumnType("int");

                    b.Property<string>("HandlerId")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("HandlerProperties")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Inactive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastException")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("MapperId")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("MapperProperties")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<int?>("PartnerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReceiveOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ReceiverId")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("ReceiverProperties")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("ResponseSubscriptionId")
                        .HasColumnType("int");

                    b.Property<bool>("Temporary")
                        .HasColumnType("tinyint(1)");

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("ValidatorId")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("ValidatorProperties")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("AggregationForId")
                        .IsUnique();

                    b.HasIndex("DocumentId");

                    b.HasIndex("PartnerId");

                    b.HasIndex("ResponseSubscriptionId")
                        .IsUnique();

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("SW.Infolink.Domain.Xchange", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("DocumentId")
                        .HasColumnType("int");

                    b.Property<string>("HandlerId")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("HandlerProperties")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("InputContentType")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("InputHash")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("InputName")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<int>("InputSize")
                        .HasColumnType("int");

                    b.Property<string>("MapperId")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("MapperProperties")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("References")
                        .HasColumnType("varchar(1024) CHARACTER SET utf8mb4")
                        .HasMaxLength(1024);

                    b.Property<int?>("ResponseSubscriptionId")
                        .HasColumnType("int");

                    b.Property<string>("RetryFor")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime>("StartedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("SubscriptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("InputHash");

                    b.HasIndex("RetryFor");

                    b.HasIndex("StartedOn");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("Xchanges");
                });

            modelBuilder.Entity("SW.Infolink.Domain.XchangeAggregation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime>("AggregatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("AggregationXchangeId")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("AggregationXchangeId");

                    b.ToTable("XchangeAggregations");
                });

            modelBuilder.Entity("SW.Infolink.Domain.XchangeDelivery", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime>("DeliveredOn")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("DeliveredOn");

                    b.ToTable("XchangeDeliveries");
                });

            modelBuilder.Entity("SW.Infolink.Domain.XchangePromotedProperties", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Hits")
                        .HasColumnType("varchar(2000) CHARACTER SET utf8mb4")
                        .HasMaxLength(2000)
                        .IsUnicode(false);

                    b.Property<string>("Properties")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("XchangePromotedProperties");
                });

            modelBuilder.Entity("SW.Infolink.Domain.XchangeResult", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Exception")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("FinishedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("OutputBad")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("OutputContentType")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("OutputHash")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("OutputName")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<int>("OutputSize")
                        .HasColumnType("int");

                    b.Property<bool>("ResponseBad")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ResponseContentType")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("ResponseHash")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("ResponseName")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<int>("ResponseSize")
                        .HasColumnType("int");

                    b.Property<string>("ResponseXchangeId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Success")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("XchangeResults");
                });

            modelBuilder.Entity("SW.Infolink.Domain.Partner", b =>
                {
                    b.OwnsMany("SW.Infolink.Domain.ApiCredential", "ApiCredentials", b1 =>
                        {
                            b1.Property<int>("PartnerId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<string>("Key")
                                .IsRequired()
                                .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                                .HasMaxLength(500)
                                .IsUnicode(false);

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                                .HasMaxLength(500);

                            b1.HasKey("PartnerId", "Id");

                            b1.HasIndex("Key")
                                .IsUnique();

                            b1.ToTable("PartnerApiCredentials");

                            b1.WithOwner()
                                .HasForeignKey("PartnerId");

                            b1.HasData(
                                new
                                {
                                    PartnerId = 1,
                                    Id = 1,
                                    Key = "7facc758283844b49cc4ffd26a75b1de",
                                    Name = "default"
                                });
                        });
                });

            modelBuilder.Entity("SW.Infolink.Domain.Subscription", b =>
                {
                    b.HasOne("SW.Infolink.Domain.Subscription", null)
                        .WithOne()
                        .HasForeignKey("SW.Infolink.Domain.Subscription", "AggregationForId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SW.Infolink.Domain.Document", null)
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SW.Infolink.Domain.Partner", null)
                        .WithMany("Subscriptions")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SW.Infolink.Domain.Subscription", null)
                        .WithOne()
                        .HasForeignKey("SW.Infolink.Domain.Subscription", "ResponseSubscriptionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.OwnsMany("SW.Infolink.Domain.Schedule", "AggregationSchedules", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<bool>("Backwards")
                                .HasColumnType("tinyint(1)");

                            b1.Property<double>("On")
                                .HasColumnType("double");

                            b1.Property<byte>("Recurrence")
                                .HasColumnType("tinyint unsigned");

                            b1.Property<int>("SubscriptionId")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("SubscriptionId");

                            b1.ToTable("SubscriptionAggregationSchedules");

                            b1.WithOwner()
                                .HasForeignKey("SubscriptionId");
                        });

                    b.OwnsMany("SW.Infolink.Domain.Schedule", "ReceiveSchedules", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<bool>("Backwards")
                                .HasColumnType("tinyint(1)");

                            b1.Property<double>("On")
                                .HasColumnType("double");

                            b1.Property<byte>("Recurrence")
                                .HasColumnType("tinyint unsigned");

                            b1.Property<int>("SubscriptionId")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("SubscriptionId");

                            b1.ToTable("SubscriptionReceiveSchedules");

                            b1.WithOwner()
                                .HasForeignKey("SubscriptionId");
                        });
                });

            modelBuilder.Entity("SW.Infolink.Domain.Xchange", b =>
                {
                    b.HasOne("SW.Infolink.Domain.Document", null)
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SW.Infolink.Domain.XchangeAggregation", b =>
                {
                    b.HasOne("SW.Infolink.Domain.Xchange", null)
                        .WithOne()
                        .HasForeignKey("SW.Infolink.Domain.XchangeAggregation", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SW.Infolink.Domain.XchangeDelivery", b =>
                {
                    b.HasOne("SW.Infolink.Domain.Xchange", null)
                        .WithOne()
                        .HasForeignKey("SW.Infolink.Domain.XchangeDelivery", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SW.Infolink.Domain.XchangePromotedProperties", b =>
                {
                    b.HasOne("SW.Infolink.Domain.Xchange", null)
                        .WithOne()
                        .HasForeignKey("SW.Infolink.Domain.XchangePromotedProperties", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SW.Infolink.Domain.XchangeResult", b =>
                {
                    b.HasOne("SW.Infolink.Domain.Xchange", null)
                        .WithOne()
                        .HasForeignKey("SW.Infolink.Domain.XchangeResult", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
