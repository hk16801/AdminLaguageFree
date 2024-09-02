using BusinessObject.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DBContext : DbContext
    {
        public DBContext()
        {
        }
        public DBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
        public virtual DbSet<Users> User { get; set; }
        public virtual DbSet<TranslationHistorys> TranslationHistory { get; set; }
        public virtual DbSet<Settings> Setting { get; set; }
        public virtual DbSet<Pages> Page { get; set; }
        public virtual DbSet<LanguageLogs> LanguageLog { get; set; }
        public virtual DbSet<Comments> Comment { get; set; }
        public virtual DbSet<Rates> Rate { get; set; }
        public virtual DbSet<Roles> Role { get; set; }
        public virtual DbSet<Accounts> Account { get; set; }
        public virtual DbSet<AccessLogs> AccessLog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pages>().HasData(
                new Pages { PageId = 1, PageName = "Intro Screen" },
                new Pages { PageId = 2, PageName = "Login SDT" },
                new Pages { PageId = 3, PageName = "Login Gmail" },
                new Pages { PageId = 4, PageName = "Home" },
                new Pages { PageId = 5, PageName = "Translate Text" },
                new Pages { PageId = 6, PageName = "Translate Speech" },
                new Pages { PageId = 7, PageName = "Translate Image" },
                new Pages { PageId = 8, PageName = "News" },
                new Pages { PageId = 9, PageName = "Weather" },
                new Pages { PageId = 10, PageName = "Weather Detail" },
                new Pages { PageId = 11, PageName = "Profile" },
                new Pages { PageId = 12, PageName = "Welcome" },
                new Pages { PageId = 13, PageName = "About Us" },
                new Pages { PageId = 14, PageName = "Chat Bot" },
                new Pages { PageId = 15, PageName = "Help" },
                new Pages { PageId = 16, PageName = "QR Scan" },
                new Pages { PageId = 17, PageName = "User Guide" },
                new Pages { PageId = 18, PageName = "Favourite" }
                );
            modelBuilder.Entity<Roles>().HasData(
                new Roles { RoleId = 1, RoleName = "User" },
                new Roles { RoleId = 2, RoleName = "Admin"},
                new Roles { RoleId = 3, RoleName = "ParentAdmin" }
                );
            modelBuilder.Entity<Accounts>().HasData(
                new Accounts
                {
                    AccountId = 1,
                    UserId = 1,
                    Username = "huyntce160121@fpt.edu.vn",
                    Password = "838fe7f16147b11480b17f9fcc345414b5e5706c427263a86538b65f3a4c2a64",
                    RoleId = "3",
                    Timestamp = DateTime.Now,
                    Status = 1 
                }
            );
            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    UserId = 1,
                    FullName = "Thanh Huy Admin",
                    Email = "huyntce160121@fpt.edu.vn",
                    ImageUser = "1.png",
                    Phone = "12345671",
                    DateOfBirth = DateTime.Now.AddYears(-20).AddDays(10),
                    Gender = "Male",
                    Timestamp = DateTime.Now,
                    National = "Vietnamese"
                }
            );
        }
    }


}
