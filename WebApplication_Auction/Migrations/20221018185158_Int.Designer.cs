﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication_Auction.Persistence;

#nullable disable

namespace WebApplication_Auction.Migrations
{
    [DbContext(typeof(AuctionDbContext))]
    [Migration("20221018185158_Int")]
    partial class Int
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication_Auction.Persistence.AuctionDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("StartingBid")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AuctionDbs");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Description = "OLED TV from Samsung",
                            ExpirationDate = new DateTime(2023, 12, 12, 2, 30, 50, 0, DateTimeKind.Unspecified),
                            Name = "TV",
                            StartingBid = 150,
                            StartingDate = new DateTime(2022, 10, 18, 20, 51, 58, 209, DateTimeKind.Local).AddTicks(3517),
                            UserId = -1
                        });
                });

            modelBuilder.Entity("WebApplication_Auction.Persistence.BidDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("AuctionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.ToTable("BidDbs");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Amount = 50,
                            AuctionId = -1,
                            Date = new DateTime(2022, 10, 18, 20, 51, 58, 209, DateTimeKind.Local).AddTicks(3596)
                        },
                        new
                        {
                            Id = -2,
                            Amount = 80,
                            AuctionId = -1,
                            Date = new DateTime(2022, 10, 18, 20, 51, 58, 209, DateTimeKind.Local).AddTicks(3601)
                        });
                });

            modelBuilder.Entity("WebApplication_Auction.Persistence.UserDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserDbs");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Name = "the user",
                            Username = "user123"
                        });
                });

            modelBuilder.Entity("WebApplication_Auction.Persistence.AuctionDb", b =>
                {
                    b.HasOne("WebApplication_Auction.Persistence.UserDb", "UserDb")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserDb");
                });

            modelBuilder.Entity("WebApplication_Auction.Persistence.BidDb", b =>
                {
                    b.HasOne("WebApplication_Auction.Persistence.AuctionDb", "AuctionDb")
                        .WithMany("BidDbs")
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuctionDb");
                });

            modelBuilder.Entity("WebApplication_Auction.Persistence.AuctionDb", b =>
                {
                    b.Navigation("BidDbs");
                });
#pragma warning restore 612, 618
        }
    }
}