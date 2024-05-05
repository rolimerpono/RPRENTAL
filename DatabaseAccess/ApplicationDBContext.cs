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
using Microsoft.AspNetCore.Identity;



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

        public DbSet<ResetPassword> tbl_ResetPassword { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Rename Identity default table name    
            builder.Entity<IdentityRole>().ToTable("tbl_Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("tbl_UserRoles");
            builder.Entity<ApplicationUser>().ToTable("tbl_Users");
            builder.Entity<IdentityUserClaim<string>>().ToTable("tbl_UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("tbl_UserLogins");
            builder.Entity<IdentityUserToken<string>>().ToTable("tbl_UserTokens");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("tbl_RoleClaims");
            #endregion

            #region tbl_Rooms

            builder.Entity<Room>().HasData(
            new Room
            {  
                RoomId              = 1,
                RoomName            = "Single Room",
                Description         = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                MaxOccupancy        = 1,
                RoomPrice           = 85,
                ImageUrl            = @"\img\Rooms\Single.jpg",
                CreatedDate         = DateTime.Now,
                UpdatedDate         = DateTime.Now
            },
            new Room
            {
                RoomId              = 2,
                RoomName            = "Double Room",
                Description         = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                MaxOccupancy        = 2,
                RoomPrice           = 90,
                ImageUrl            = @"\img\Rooms\Double.jpg",
                CreatedDate         = DateTime.Now,
                UpdatedDate         = DateTime.Now


            },
            new Room
            {
                RoomId              = 3,
                RoomName            = "Deluxed Room",
                Description         = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                MaxOccupancy        = 3,
                RoomPrice           = 100,
                ImageUrl            = @"\img\Rooms\Deluxed.jpg",
                CreatedDate         = DateTime.Now,
                UpdatedDate         = DateTime.Now
            },

            new Room
            {
                RoomId              = 4,
                RoomName            = "Queens Room",
                Description         = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                MaxOccupancy        = 4,
                RoomPrice           = 120,
                ImageUrl            = @"\img\Rooms\Queens.jpg",
                CreatedDate         = DateTime.Now,
                UpdatedDate         = DateTime.Now

            },

            new Room
            {
                RoomId              = 5,
                RoomName            = "Kings Room",
                Description         = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                MaxOccupancy        = 5,
                RoomPrice           = 130,
                ImageUrl            = @"\img\Rooms\Kings.jpg",
                CreatedDate         = DateTime.Now,
                UpdatedDate         = DateTime.Now

            },
            new Room
            {
                RoomId              = 6,
                RoomName            = "Executive Suite",
                Description         = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                MaxOccupancy        = 10,
                RoomPrice           = 100,
                ImageUrl            = @"\img\Rooms\Executive.jpg",
                CreatedDate         = DateTime.Now,
                UpdatedDate         = DateTime.Now
            },

            new Room
            {
                RoomId              = 7,
                RoomName            = "Super Deluxed",
                Description         = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                MaxOccupancy        = 10,
                RoomPrice           = 110,
                ImageUrl            = @"\img\Rooms\Super Deluxed.jpg",
                CreatedDate         = DateTime.Now,
                UpdatedDate         = DateTime.Now

            },
            new Room
            {
                RoomId              = 8,
                RoomName            = "Diamond Room",
                Description         = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                MaxOccupancy        = 10,
                RoomPrice           = 87,
                ImageUrl            = @"\img\Rooms\Diamond Room.jpg",
                CreatedDate         = DateTime.Now,
                UpdatedDate         = DateTime.Now

            },
            new Room
            {
                RoomId = 9,
                RoomName            = "Emerald Deluxed",
                Description         = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.",
                MaxOccupancy        = 10,
                RoomPrice           = 98,
                ImageUrl            = @"\img\Rooms\Emerald Room.jpg",
                CreatedDate         = DateTime.Now,
                UpdatedDate         = DateTime.Now

            });

            #endregion

            #region tbl_RoomNumber
            builder.Entity<RoomNumber>().HasData(           
            new RoomNumber
            { 
                RoomNo      = 101,
                RoomId      = 1,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor."
            },
            new RoomNumber
            {
                RoomNo      = 102,
                RoomId      = 1,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
            },
            new RoomNumber
            {
                RoomNo      = 103,
                RoomId      = 1,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
            },
            new RoomNumber
            {
                RoomNo = 104,
                RoomId = 1,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
            },
            new RoomNumber
            {
                RoomNo      = 201,
                RoomId      = 2,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
            },
            new RoomNumber
            {
                RoomNo = 202,
                RoomId = 2,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
            },
            new RoomNumber
            {
                RoomNo = 203,
                RoomId = 2,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
            },
            new RoomNumber
            {
                RoomNo = 204,
                RoomId = 2,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
            },
            new RoomNumber
            {
                RoomNo = 301,
                RoomId = 3,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
            },
            new RoomNumber
            {
                RoomNo = 302,
                RoomId = 3,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
            },
            new RoomNumber
            {
                RoomNo = 303,
                RoomId = 3,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
            },
            new RoomNumber
            {
                RoomNo = 304,
                RoomId = 3,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
            },
            new RoomNumber
            {
                RoomNo = 401,
                RoomId = 4,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
            },
            new RoomNumber
            {
                RoomNo = 402,
                RoomId = 4,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
            },
            new RoomNumber
            {
                RoomNo = 403,
                RoomId = 4,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
            },
            new RoomNumber
            {
                RoomNo = 501,
                RoomId = 5,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
            },
            new RoomNumber
            {
                RoomNo = 502,
                RoomId = 5,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
            },
            new RoomNumber
            {
                RoomNo = 503,
                RoomId = 5,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
            },
            new RoomNumber
            {
                RoomNo = 601,
                RoomId = 6,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
            },
            new RoomNumber
            {
                RoomNo = 602,
                RoomId = 6,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor."
            });
            #endregion

            #region Amenity Only
            builder.Entity<Amenity>().HasData(                
            new Amenity
            {
                AmenityId = 1,
                AmenityName = "Washing Machine",
            },
            new Amenity
            {
                AmenityId = 2,
                AmenityName = "Electric Fan",

            },
            new Amenity
            {
                AmenityId = 3,
                AmenityName = "TV",
            },
            new Amenity
            {
                AmenityId = 4,
                AmenityName = "Internet Wifi",
            },
            new Amenity
            {
                AmenityId = 5,
                AmenityName = "Microwave",

            });

            #endregion  

            #region Room Amenity
                builder.Entity<RoomAmenity>().HasData(
                new RoomAmenity { Id  = 1,  RoomId = 1, AmenityId = 1 },
                new RoomAmenity { Id  = 2,  RoomId = 1, AmenityId = 2 },
                new RoomAmenity { Id  = 3,  RoomId = 1, AmenityId = 3 },
                new RoomAmenity { Id  = 4,  RoomId = 1, AmenityId = 4 },
                new RoomAmenity { Id  = 5,  RoomId = 1, AmenityId = 5 },
                new RoomAmenity { Id  = 6,  RoomId = 2, AmenityId = 3 },
                new RoomAmenity { Id  = 7,  RoomId = 2, AmenityId = 1 },
                new RoomAmenity { Id  = 8,  RoomId = 3, AmenityId = 5 },
                new RoomAmenity { Id  = 9,  RoomId = 4, AmenityId = 3 },
                new RoomAmenity { Id  = 10, RoomId = 5, AmenityId = 5 });       
            #endregion

        }


    }

}
