using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PayPal.Api;
using System.Configuration;



namespace DatabaseAccess
{
    public class ApplicationDBContext  : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        { 
                
        }

        public DbSet<Room> tbl_Rooms { get; set; }

        public DbSet<RoomNumber> tbl_RoomNumber { get; set; }       
       

        public DbSet<RoomAmenity> tbl_RoomAmenity { get; set; }

        public DbSet<Amenity> tbl_Amenity { get; set; }     

        public DbSet<Booking> tbl_Booking { get; set; }

        public DbSet<ApplicationUser> tbl_User { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region tbl_Rooms

            builder.Entity<Room>().HasData(
            new Room
            {  
                ROOM_ID = 1,
                ROOM_NAME = "Single Room",
                DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                MAX_OCCUPANCY = 1,
                ROOM_PRICE = 85,
                IMAGE_URL = @"\\img\\Rooms\\Single.jpg",
                CREATED_DATE = DateTime.Now,
                UPDATED_DATE = DateTime.Now
            },
            new Room
            {
                ROOM_ID = 2,
                ROOM_NAME = "Double Room",
                DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                MAX_OCCUPANCY = 2,
                ROOM_PRICE = 90,
                IMAGE_URL = @"\\img\\Rooms\\Double.jpg",
                CREATED_DATE = DateTime.Now,
                UPDATED_DATE = DateTime.Now


            },
                new Room
                {
                    ROOM_ID = 3,
                    ROOM_NAME = "Deluxed Room",
                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                    MAX_OCCUPANCY = 3,
                    ROOM_PRICE = 100,
                    IMAGE_URL = @"\\img\\Rooms\\Deluxed.jpg",
                    CREATED_DATE = DateTime.Now,
                    UPDATED_DATE = DateTime.Now
                },

                new Room
                {
                    ROOM_ID = 4,
                    ROOM_NAME = "Queens Room",
                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                    MAX_OCCUPANCY = 4,
                    ROOM_PRICE = 120,
                    IMAGE_URL = @"\\img\\Rooms\\Queens.jpg",
                    CREATED_DATE = DateTime.Now,
                    UPDATED_DATE = DateTime.Now

                },

                new Room
                {
                    ROOM_ID = 5,
                    ROOM_NAME = "Kings Room",
                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                    MAX_OCCUPANCY = 5,
                    ROOM_PRICE = 130,
                    IMAGE_URL = @"\\img\\Rooms\\Kings.jpg",
                    CREATED_DATE = DateTime.Now,
                    UPDATED_DATE = DateTime.Now

                },
                new Room
                {
                    ROOM_ID = 6,
                    ROOM_NAME = "Executive Suite",
                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                    MAX_OCCUPANCY = 10,
                    ROOM_PRICE = 100,
                    IMAGE_URL = @"\\img\\Rooms\\Executive.jpg",
                    CREATED_DATE = DateTime.Now,
                    UPDATED_DATE = DateTime.Now
                },

                 new Room
                 {
                     ROOM_ID = 7,
                     ROOM_NAME = "Super Deluxed",
                     DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                     MAX_OCCUPANCY = 10,
                     ROOM_PRICE = 110,
                     IMAGE_URL = @"\\img\\Rooms\\Super Deluxed.jpg",
                     CREATED_DATE = DateTime.Now,
                     UPDATED_DATE = DateTime.Now

                 },
                  new Room
                  {
                      ROOM_ID = 8,
                      ROOM_NAME = "Diamond Room",
                      DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                      MAX_OCCUPANCY = 10,
                      ROOM_PRICE = 87,
                      IMAGE_URL = @"\\img\\Rooms\\Diamond Room.jpg",
                      CREATED_DATE = DateTime.Now,
                      UPDATED_DATE = DateTime.Now

                  },
                   new Room
                   {
                       ROOM_ID = 9,
                       ROOM_NAME = "Emerald Deluxed",
                       DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                       MAX_OCCUPANCY = 10,
                       ROOM_PRICE = 98,
                       IMAGE_URL = @"\\img\\Rooms\\Emerald Room.jpg",
                       CREATED_DATE = DateTime.Now,
                       UPDATED_DATE = DateTime.Now

                   }

            );

            #endregion

            #region tbl_RoomNumber
            builder.Entity<RoomNumber>().HasData(           
            new RoomNumber
            { 
                ROOM_NUMBER = 101,
                ROOM_ID = 1,
                DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor."
            },
                new RoomNumber
                {
                    ROOM_NUMBER = 102,
                    ROOM_ID = 1,
                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
                },
                new RoomNumber
                {
                    ROOM_NUMBER = 103,
                    ROOM_ID = 1,
                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
                },
                new RoomNumber
                {
                    ROOM_NUMBER = 104,
                    ROOM_ID = 1,
                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
                },
                new RoomNumber
                {
                    ROOM_NUMBER = 201,
                    ROOM_ID = 2,
                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
                },
                    new RoomNumber
                    {
                        ROOM_NUMBER = 202,
                        ROOM_ID = 2,
                        DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
                    },
                    new RoomNumber
                    {
                        ROOM_NUMBER = 203,
                        ROOM_ID = 2,
                        DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
                    },
                    new RoomNumber
                    {
                        ROOM_NUMBER = 204,
                        ROOM_ID = 2,
                        DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
                    },
                    new RoomNumber
                    {
                        ROOM_NUMBER = 301,
                        ROOM_ID = 3,
                        DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
                    },
                        new RoomNumber
                        {
                            ROOM_NUMBER = 302,
                            ROOM_ID = 3,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
                        },
                        new RoomNumber
                        {
                            ROOM_NUMBER = 303,
                            ROOM_ID = 3,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
                        },
                        new RoomNumber
                        {
                            ROOM_NUMBER = 304,
                            ROOM_ID = 3,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
                        },
                        new RoomNumber
                        {
                            ROOM_NUMBER = 401,
                            ROOM_ID = 4,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
                        },
                            new RoomNumber
                            {
                                ROOM_NUMBER = 402,
                            ROOM_ID = 4,
                                DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
                            },
                            new RoomNumber
                            {
                                ROOM_NUMBER = 403,
                                ROOM_ID = 4,
                                DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
                            },
                            new RoomNumber
                            {
                                ROOM_NUMBER = 501,
                                ROOM_ID = 5,
                                DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
                            },
                            new RoomNumber
                            {
                                ROOM_NUMBER = 502,
                                ROOM_ID = 5,
                                DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
                            },
                                new RoomNumber
                                {
                                    ROOM_NUMBER = 503,
                                    ROOM_ID = 5,
                                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
                                },
                                new RoomNumber
                                {
                                    ROOM_NUMBER = 601,
                                    ROOM_ID = 6,
                                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
                                },
                                new RoomNumber
                                {
                                    ROOM_NUMBER = 602,
                                    ROOM_ID = 6,
                                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
                                }
            );


            #endregion

            #region Amenity Only
            builder.Entity<Amenity>().HasData(
                new Amenity
                {
                    AMENITY_ID = 1,
                    AMENITY_NAME = "Washing Machine",
                },
                new Amenity
                {
                    AMENITY_ID = 2,
                    AMENITY_NAME = "Electric Fan",

                },
                new Amenity
                {
                    AMENITY_ID = 3,
                    AMENITY_NAME = "TV",
                },
                new Amenity
                {
                    AMENITY_ID = 4,
                    AMENITY_NAME = "Internet Wifi",
                },
                new Amenity
                {
                    AMENITY_ID = 5,
                    AMENITY_NAME = "Microwave",

                }
             );

            #endregion  

            #region Room Amenity
                builder.Entity<RoomAmenity>().HasData(
                new RoomAmenity { ID = 1, ROOM_ID = 1, AMENITY_ID = 1 },
                new RoomAmenity { ID = 2, ROOM_ID = 1, AMENITY_ID = 2 },
                new RoomAmenity { ID = 3, ROOM_ID = 1, AMENITY_ID = 3 },
                new RoomAmenity { ID = 4, ROOM_ID = 1, AMENITY_ID = 4 },
                new RoomAmenity { ID = 5, ROOM_ID = 1, AMENITY_ID = 5 },
                new RoomAmenity { ID = 6, ROOM_ID = 2, AMENITY_ID = 3 },
                new RoomAmenity { ID = 7, ROOM_ID = 2, AMENITY_ID = 1 },
                new RoomAmenity { ID = 8, ROOM_ID = 3, AMENITY_ID = 5 },
                new RoomAmenity { ID = 9, ROOM_ID = 4, AMENITY_ID = 3 },
                new RoomAmenity { ID = 10, ROOM_ID = 5, AMENITY_ID = 5 });       
            #endregion

        }


    }

}
