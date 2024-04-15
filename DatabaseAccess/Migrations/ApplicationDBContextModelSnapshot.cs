﻿// <auto-generated />
using System;
using DatabaseAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DatabaseAccess.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Model.Amenity", b =>
                {
                    b.Property<int>("AMENITY_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AMENITY_ID"));

                    b.Property<string>("AMENITY_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AMENITY_ID");

                    b.ToTable("tbl_Amenity");

                    b.HasData(
                        new
                        {
                            AMENITY_ID = 1,
                            AMENITY_NAME = "Washing Machine"
                        },
                        new
                        {
                            AMENITY_ID = 2,
                            AMENITY_NAME = "Electric Fan"
                        },
                        new
                        {
                            AMENITY_ID = 3,
                            AMENITY_NAME = "TV"
                        },
                        new
                        {
                            AMENITY_ID = 4,
                            AMENITY_NAME = "Internet Wifi"
                        },
                        new
                        {
                            AMENITY_ID = 5,
                            AMENITY_NAME = "Microwave"
                        });
                });

            modelBuilder.Entity("Model.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CREATED_DATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("USER_NAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Model.Booking", b =>
                {
                    b.Property<int>("BOOKING_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BOOKING_ID"));

                    b.Property<DateTime>("ACTUAL_CHECK_IN_DATE")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ACTUAL_CHECK_OUT_DATE")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BOOKING_DATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("BOOKING_STATUS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("CHECK_IN_DATE")
                        .HasColumnType("date");

                    b.Property<DateOnly>("CHECK_OUT_DATE")
                        .HasColumnType("date");

                    b.Property<bool>("IS_PAYMENT_SUCCESSFULL")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PAYMENT_DATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("PHONE_NUMBER")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ROOM_ID")
                        .HasColumnType("int");

                    b.Property<int>("ROOM_NUMBER")
                        .HasColumnType("int");

                    b.Property<string>("STRIPE_PAYEMENT_INTENT_ID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("STRIPE_SESSION_ID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TOTAL_COST")
                        .HasColumnType("float");

                    b.Property<string>("USER_EMAIL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USER_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("USER_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BOOKING_ID");

                    b.HasIndex("ROOM_ID");

                    b.HasIndex("USER_ID");

                    b.ToTable("tbl_Booking");
                });

            modelBuilder.Entity("Model.Room", b =>
                {
                    b.Property<int>("ROOM_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ROOM_ID"));

                    b.Property<DateTime?>("CREATED_DATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("DESCRIPTION")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IMAGE_URL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MAX_OCCUPANCY")
                        .HasColumnType("int");

                    b.Property<string>("ROOM_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ROOM_PRICE")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UPDATED_DATE")
                        .HasColumnType("datetime2");

                    b.HasKey("ROOM_ID");

                    b.ToTable("tbl_Rooms");

                    b.HasData(
                        new
                        {
                            ROOM_ID = 1,
                            CREATED_DATE = new DateTime(2024, 4, 15, 16, 51, 27, 30, DateTimeKind.Local).AddTicks(270),
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                            IMAGE_URL = "https://placehold.co/600x400/png",
                            MAX_OCCUPANCY = 1,
                            ROOM_NAME = "Single Room",
                            ROOM_PRICE = 85.0,
                            UPDATED_DATE = new DateTime(2024, 4, 15, 16, 51, 27, 30, DateTimeKind.Local).AddTicks(271)
                        },
                        new
                        {
                            ROOM_ID = 2,
                            CREATED_DATE = new DateTime(2024, 4, 15, 16, 51, 27, 30, DateTimeKind.Local).AddTicks(277),
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                            IMAGE_URL = "https://placehold.co/600x400/png",
                            MAX_OCCUPANCY = 2,
                            ROOM_NAME = "Double Room",
                            ROOM_PRICE = 90.0,
                            UPDATED_DATE = new DateTime(2024, 4, 15, 16, 51, 27, 30, DateTimeKind.Local).AddTicks(278)
                        },
                        new
                        {
                            ROOM_ID = 3,
                            CREATED_DATE = new DateTime(2024, 4, 15, 16, 51, 27, 30, DateTimeKind.Local).AddTicks(284),
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                            IMAGE_URL = "https://placehold.co/600x400/png",
                            MAX_OCCUPANCY = 3,
                            ROOM_NAME = "Deluxed Room",
                            ROOM_PRICE = 100.0,
                            UPDATED_DATE = new DateTime(2024, 4, 15, 16, 51, 27, 30, DateTimeKind.Local).AddTicks(285)
                        },
                        new
                        {
                            ROOM_ID = 4,
                            CREATED_DATE = new DateTime(2024, 4, 15, 16, 51, 27, 30, DateTimeKind.Local).AddTicks(291),
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                            IMAGE_URL = "https://placehold.co/600x400/png",
                            MAX_OCCUPANCY = 4,
                            ROOM_NAME = "Queens Room",
                            ROOM_PRICE = 120.0,
                            UPDATED_DATE = new DateTime(2024, 4, 15, 16, 51, 27, 30, DateTimeKind.Local).AddTicks(292)
                        },
                        new
                        {
                            ROOM_ID = 5,
                            CREATED_DATE = new DateTime(2024, 4, 15, 16, 51, 27, 30, DateTimeKind.Local).AddTicks(298),
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                            IMAGE_URL = "https://placehold.co/600x400/png",
                            MAX_OCCUPANCY = 5,
                            ROOM_NAME = "Kings Room",
                            ROOM_PRICE = 130.0,
                            UPDATED_DATE = new DateTime(2024, 4, 15, 16, 51, 27, 30, DateTimeKind.Local).AddTicks(299)
                        },
                        new
                        {
                            ROOM_ID = 6,
                            CREATED_DATE = new DateTime(2024, 4, 15, 16, 51, 27, 30, DateTimeKind.Local).AddTicks(305),
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                            IMAGE_URL = "https://placehold.co/600x400/png",
                            MAX_OCCUPANCY = 10,
                            ROOM_NAME = "Executive Suite",
                            ROOM_PRICE = 180.0,
                            UPDATED_DATE = new DateTime(2024, 4, 15, 16, 51, 27, 30, DateTimeKind.Local).AddTicks(309)
                        });
                });

            modelBuilder.Entity("Model.RoomAmenity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AMENITY_ID")
                        .HasColumnType("int");

                    b.Property<int>("ROOM_ID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AMENITY_ID");

                    b.HasIndex("ROOM_ID");

                    b.ToTable("tbl_RoomAmenity");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AMENITY_ID = 1,
                            ROOM_ID = 1
                        },
                        new
                        {
                            ID = 2,
                            AMENITY_ID = 2,
                            ROOM_ID = 1
                        },
                        new
                        {
                            ID = 3,
                            AMENITY_ID = 3,
                            ROOM_ID = 1
                        },
                        new
                        {
                            ID = 4,
                            AMENITY_ID = 4,
                            ROOM_ID = 1
                        },
                        new
                        {
                            ID = 5,
                            AMENITY_ID = 5,
                            ROOM_ID = 1
                        },
                        new
                        {
                            ID = 6,
                            AMENITY_ID = 3,
                            ROOM_ID = 2
                        },
                        new
                        {
                            ID = 7,
                            AMENITY_ID = 1,
                            ROOM_ID = 2
                        },
                        new
                        {
                            ID = 8,
                            AMENITY_ID = 5,
                            ROOM_ID = 3
                        },
                        new
                        {
                            ID = 9,
                            AMENITY_ID = 3,
                            ROOM_ID = 4
                        },
                        new
                        {
                            ID = 10,
                            AMENITY_ID = 5,
                            ROOM_ID = 5
                        });
                });

            modelBuilder.Entity("Model.RoomNumber", b =>
                {
                    b.Property<int>("ROOM_NUMBER")
                        .HasColumnType("int");

                    b.Property<string>("DESCRIPTION")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ROOM_ID")
                        .HasColumnType("int");

                    b.HasKey("ROOM_NUMBER");

                    b.HasIndex("ROOM_ID");

                    b.ToTable("tbl_RoomNumber");

                    b.HasData(
                        new
                        {
                            ROOM_NUMBER = 101,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor.",
                            ROOM_ID = 1
                        },
                        new
                        {
                            ROOM_NUMBER = 102,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            ROOM_ID = 1
                        },
                        new
                        {
                            ROOM_NUMBER = 103,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            ROOM_ID = 1
                        },
                        new
                        {
                            ROOM_NUMBER = 104,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            ROOM_ID = 1
                        },
                        new
                        {
                            ROOM_NUMBER = 201,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            ROOM_ID = 2
                        },
                        new
                        {
                            ROOM_NUMBER = 202,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            ROOM_ID = 2
                        },
                        new
                        {
                            ROOM_NUMBER = 203,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            ROOM_ID = 2
                        },
                        new
                        {
                            ROOM_NUMBER = 204,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            ROOM_ID = 2
                        },
                        new
                        {
                            ROOM_NUMBER = 301,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            ROOM_ID = 3
                        },
                        new
                        {
                            ROOM_NUMBER = 302,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            ROOM_ID = 3
                        },
                        new
                        {
                            ROOM_NUMBER = 303,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            ROOM_ID = 3
                        },
                        new
                        {
                            ROOM_NUMBER = 304,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            ROOM_ID = 3
                        },
                        new
                        {
                            ROOM_NUMBER = 401,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            ROOM_ID = 4
                        },
                        new
                        {
                            ROOM_NUMBER = 402,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            ROOM_ID = 4
                        },
                        new
                        {
                            ROOM_NUMBER = 403,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            ROOM_ID = 4
                        },
                        new
                        {
                            ROOM_NUMBER = 501,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            ROOM_ID = 5
                        },
                        new
                        {
                            ROOM_NUMBER = 502,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            ROOM_ID = 5
                        },
                        new
                        {
                            ROOM_NUMBER = 503,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            ROOM_ID = 5
                        },
                        new
                        {
                            ROOM_NUMBER = 601,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            ROOM_ID = 6
                        },
                        new
                        {
                            ROOM_NUMBER = 602,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.",
                            ROOM_ID = 6
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Booking", b =>
                {
                    b.HasOne("Model.Room", "ROOM")
                        .WithMany()
                        .HasForeignKey("ROOM_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.ApplicationUser", "USERS")
                        .WithMany()
                        .HasForeignKey("USER_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ROOM");

                    b.Navigation("USERS");
                });

            modelBuilder.Entity("Model.RoomAmenity", b =>
                {
                    b.HasOne("Model.Amenity", "AMENITY")
                        .WithMany()
                        .HasForeignKey("AMENITY_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Room", "ROOMS")
                        .WithMany("ROOM_AMENITIES")
                        .HasForeignKey("ROOM_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AMENITY");

                    b.Navigation("ROOMS");
                });

            modelBuilder.Entity("Model.RoomNumber", b =>
                {
                    b.HasOne("Model.Room", "ROOM")
                        .WithMany()
                        .HasForeignKey("ROOM_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ROOM");
                });

            modelBuilder.Entity("Model.Room", b =>
                {
                    b.Navigation("ROOM_AMENITIES");
                });
#pragma warning restore 612, 618
        }
    }
}
