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
        
        public DbSet<Amenity> tbl_Amenity { get; set; }

        public DbSet<RoomAmenity> tbl_RoomAmenity { get; set; }

        public DbSet<AmenityOnly> tbl_AmenityOnly { get; set; }
     

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
                DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus. " +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus, id aliquam ante lacinia. Donec a leo pharetra, venenatis est ut, scelerisque leo. " +
                "Nam vitae ex nec felis suscipit lobortis non sed nisl.",
                MAX_OCCUPANCY = 1,
                ROOM_PRICE = 85,
                IMAGE_URL = "https://placehold.co/600x400/png",
                CREATED_DATE = DateTime.Now,
                UPDATED_DATE = DateTime.Now
            },
            new Room
            {
                ROOM_ID = 2,
                ROOM_NAME = "Double Room",
                DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus. " +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus, id aliquam ante lacinia. Donec a leo pharetra, venenatis est ut, scelerisque leo. " +
                "Nam vitae ex nec felis suscipit lobortis non sed nisl.",
                MAX_OCCUPANCY = 2,
                ROOM_PRICE = 90,
                IMAGE_URL = "https://placehold.co/600x400/png",
                CREATED_DATE = DateTime.Now,
                UPDATED_DATE = DateTime.Now


            },
                new Room
                {
                    ROOM_ID = 3,
                    ROOM_NAME = "Deluxed Room",
                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus. " +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus, id aliquam ante lacinia. Donec a leo pharetra, venenatis est ut, scelerisque leo. " +
                "Nam vitae ex nec felis suscipit lobortis non sed nisl.",
                    MAX_OCCUPANCY = 3,
                    ROOM_PRICE = 100,
                    IMAGE_URL = "https://placehold.co/600x400/png",
                    CREATED_DATE = DateTime.Now,
                    UPDATED_DATE = DateTime.Now
                },

                new Room
                {
                    ROOM_ID = 4,
                    ROOM_NAME = "Queens Room",
                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus. " +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus, id aliquam ante lacinia. Donec a leo pharetra, venenatis est ut, scelerisque leo. " +
                "Nam vitae ex nec felis suscipit lobortis non sed nisl.",
                    MAX_OCCUPANCY = 4,
                    ROOM_PRICE = 120,
                    IMAGE_URL = "https://placehold.co/600x400/png",
                    CREATED_DATE = DateTime.Now,
                    UPDATED_DATE = DateTime.Now

                },

                new Room
                {
                    ROOM_ID = 5,
                    ROOM_NAME = "Kings Room",
                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus. " +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus, id aliquam ante lacinia. Donec a leo pharetra, venenatis est ut, scelerisque leo. " +
                "Nam vitae ex nec felis suscipit lobortis non sed nisl.",
                    MAX_OCCUPANCY = 5,
                    ROOM_PRICE = 130,
                    IMAGE_URL = "https://placehold.co/600x400/png",
                    CREATED_DATE = DateTime.Now,
                    UPDATED_DATE = DateTime.Now

                },
                new Room
                {
                    ROOM_ID = 6,
                    ROOM_NAME = "Executive Suite",
                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus. " +
                    "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus, id aliquam ante lacinia. Donec a leo pharetra, venenatis est ut, scelerisque leo. " +
                    "Nam vitae ex nec felis suscipit lobortis non sed nisl.",
                    MAX_OCCUPANCY = 10,
                    ROOM_PRICE = 180,
                    IMAGE_URL = "https://placehold.co/600x400/png",
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
                DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus." +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus"
            },
                new RoomNumber
                {
                    ROOM_NUMBER = 102,
                    ROOM_ID = 1,
                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus." +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus"
                },
                new RoomNumber
                {
                    ROOM_NUMBER = 103,
                    ROOM_ID = 1,
                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus." +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus"
                },
                new RoomNumber
                {
                    ROOM_NUMBER = 104,
                    ROOM_ID = 1,
                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus." +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus"
                },
                new RoomNumber
                {
                    ROOM_NUMBER = 201,
                    ROOM_ID = 2,
                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus." +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus"
                },
                    new RoomNumber
                    {
                        ROOM_NUMBER = 202,
                        ROOM_ID = 2,
                        DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus." +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus"
                    },
                    new RoomNumber
                    {
                        ROOM_NUMBER = 203,
                        ROOM_ID = 2,
                        DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus." +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus"
                    },
                    new RoomNumber
                    {
                        ROOM_NUMBER = 204,
                        ROOM_ID = 2,
                        DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus." +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus"
                    },
                    new RoomNumber
                    {
                        ROOM_NUMBER = 301,
                        ROOM_ID = 3,
                        DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus." +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus"
                    },
                        new RoomNumber
                        {
                            ROOM_NUMBER = 302,
                            ROOM_ID = 3,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus." +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus"
                        },
                        new RoomNumber
                        {
                            ROOM_NUMBER = 303,
                            ROOM_ID = 3,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus." +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus"
                        },
                        new RoomNumber
                        {
                            ROOM_NUMBER = 304,
                            ROOM_ID = 3,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus." +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus"
                        },
                        new RoomNumber
                        {
                            ROOM_NUMBER = 401,
                            ROOM_ID = 4,
                            DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus." +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus"
                        },
                            new RoomNumber
                            {
                                ROOM_NUMBER = 402,
                            ROOM_ID = 4,
                                DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus." +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus"
                            },
                            new RoomNumber
                            {
                                ROOM_NUMBER = 403,
                                ROOM_ID = 4,
                                DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus." +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus"
                            },
                            new RoomNumber
                            {
                                ROOM_NUMBER = 501,
                                ROOM_ID = 5,
                                DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus." +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus"
                            },
                            new RoomNumber
                            {
                                ROOM_NUMBER = 502,
                                ROOM_ID = 5,
                                DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus." +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus"
                            },
                                new RoomNumber
                                {
                                    ROOM_NUMBER = 503,
                                    ROOM_ID = 5,
                                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus." +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus"
                                },
                                new RoomNumber
                                {
                                    ROOM_NUMBER = 601,
                                    ROOM_ID = 6,
                                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus." +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus"
                                },
                                new RoomNumber
                                {
                                    ROOM_NUMBER = 602,
                                    ROOM_ID = 6,
                                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus." +
                "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus"
                                }
            );


            #endregion

            #region Amenity Only
            builder.Entity<AmenityOnly>().HasData(
                new AmenityOnly
                {
                    ID = 1,
                    AMENITY_NAME = "Washing Machine",
                },
                new AmenityOnly
                {
                    ID = 2,
                    AMENITY_NAME = "Electric Fan",

                },
                new AmenityOnly
                {
                    ID = 3,
                    AMENITY_NAME = "TV",
                },
                new AmenityOnly
                {
                    ID = 4,
                    AMENITY_NAME = "Internet Wifi",
                },
                new AmenityOnly
                {
                    ID = 5,
                    AMENITY_NAME = "Microwave",

                }
             );

            #endregion

         


            #region tbl_Amenity
            builder.Entity<Amenity>().HasData (
            new Amenity
            { 
                
                AMENITY_ID = 1,
                ROOM_ID = 1,
                DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                AMENITY_NAME = "Microwave"
            },
             new Amenity
             {

                 AMENITY_ID = 2,
                 ROOM_ID = 1,
                 DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                 AMENITY_NAME = "Electric Fan"
             },
              new Amenity
              {

                  AMENITY_ID = 3,
                  ROOM_ID = 1,
                  DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                  AMENITY_NAME = "Aircon"
              },
               new Amenity
               {

                   AMENITY_ID = 4,
                   ROOM_ID = 1,
                   DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                   AMENITY_NAME = "Netflix"
               },
                new Amenity
                {

                    AMENITY_ID = 5,
                    ROOM_ID = 1,
                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                    AMENITY_NAME = "Washing Machine"
                },


                 new Amenity
                 {

                     AMENITY_ID = 6,
                     ROOM_ID = 2,
                     DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                     AMENITY_NAME = "Microwave"
                 },
             new Amenity
             {

                 AMENITY_ID = 7,
                 ROOM_ID = 2,
                 DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                 AMENITY_NAME = "Electric Fan"
             },
              new Amenity
              {

                  AMENITY_ID = 8,
                  ROOM_ID = 2,
                  DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                  AMENITY_NAME = "Aircon"
              },
               new Amenity
               {

                   AMENITY_ID = 9,
                   ROOM_ID = 2,
                   DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                   AMENITY_NAME = "Netflix"
               },
                new Amenity
                {

                    AMENITY_ID = 10,
                    ROOM_ID = 2,
                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                    AMENITY_NAME = "Washing Machine"
                },

                 new Amenity
                 {

                     AMENITY_ID = 11,
                     ROOM_ID = 3,
                     DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                     AMENITY_NAME = "Microwave"
                 },
             new Amenity
             {

                 AMENITY_ID = 12,
                 ROOM_ID = 3,
                 DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                 AMENITY_NAME = "Electric Fan"
             },
              new Amenity
              {

                  AMENITY_ID = 13,
                  ROOM_ID = 3,
                  DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                  AMENITY_NAME = "Aircon"
              },
               new Amenity
               {

                   AMENITY_ID = 14,
                   ROOM_ID = 3,
                   DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                   AMENITY_NAME = "Netflix"
               },
                new Amenity
                {

                    AMENITY_ID = 15,
                    ROOM_ID = 3,
                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                    AMENITY_NAME = "Washing Machine"
                },
                 new Amenity
                 {

                     AMENITY_ID = 16,
                     ROOM_ID = 4,
                     DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                     AMENITY_NAME = "Microwave"
                 },
             new Amenity
             {

                 AMENITY_ID = 17,
                 ROOM_ID = 4,
                 DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                 AMENITY_NAME = "Electric Fan"
             },
              new Amenity
              {

                  AMENITY_ID = 18,
                  ROOM_ID = 4,
                  DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                  AMENITY_NAME = "Aircon"
              },
               new Amenity
               {

                   AMENITY_ID = 19,
                   ROOM_ID = 4,
                   DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                   AMENITY_NAME = "Netflix"
               },
                new Amenity
                {

                    AMENITY_ID = 20,
                    ROOM_ID = 4,
                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                    AMENITY_NAME = "Washing Machine"
                },


                 new Amenity
                 {

                     AMENITY_ID = 21,
                     ROOM_ID = 5,
                     DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                     AMENITY_NAME = "Microwave"
                 },
             new Amenity
             {

                 AMENITY_ID = 22,
                 ROOM_ID = 5,
                 DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                 AMENITY_NAME = "Electric Fan"
             },
              new Amenity
              {

                  AMENITY_ID = 23,
                  ROOM_ID = 5,
                  DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                  AMENITY_NAME = "Aircon"
              },
               new Amenity
               {

                   AMENITY_ID = 24,
                   ROOM_ID = 5,
                   DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                   AMENITY_NAME = "Netflix"
               },
                new Amenity
                {

                    AMENITY_ID = 25,
                    ROOM_ID = 5,
                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                    AMENITY_NAME = "Washing Machine"
                },

                 new Amenity
                 {

                     AMENITY_ID = 26,
                     ROOM_ID = 6,
                     DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                     AMENITY_NAME = "Microwave"
                 },
             new Amenity
             {

                 AMENITY_ID = 27,
                 ROOM_ID = 6,
                 DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                 AMENITY_NAME = "Electric Fan"
             },
              new Amenity
              {

                  AMENITY_ID = 28,
                  ROOM_ID = 6,
                  DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                  AMENITY_NAME = "Aircon"
              },
               new Amenity
               {

                   AMENITY_ID = 29,
                   ROOM_ID = 6,
                   DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                   AMENITY_NAME = "Netflix"
               },
                new Amenity
                {

                    AMENITY_ID = 30,
                    ROOM_ID = 6,
                    DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.",
                    AMENITY_NAME = "Washing Machine"
                }

            );

            #endregion

            #region Room Amenity
                builder.Entity<RoomAmenity>().HasData(
                new RoomAmenity { ID = 1, ROOM_ID = 1, AMENITY_ID = 1 },
                new RoomAmenity { ID = 2, ROOM_ID = 1, AMENITY_ID = 2 },
                new RoomAmenity { ID = 3, ROOM_ID = 1, AMENITY_ID = 3 },
                new RoomAmenity { ID = 4, ROOM_ID = 1, AMENITY_ID = 4 },
                new RoomAmenity { ID = 5, ROOM_ID = 1, AMENITY_ID = 5 });       
            #endregion

        }


    }

}
