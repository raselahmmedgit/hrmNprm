﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using HRMnPRM.Plug.Domain;

namespace HRMnPRM.Plug.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        { }

        public AppDbContext(string connectionString)
            : base(connectionString)
        {

        }

        //Admin
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<UserMenuPermission> UserMenuPermissions { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationModule> ApplicationModules { get; set; }
        public DbSet<ApplicationSetting> ApplicationSettings { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<EmailAccount> EmailAccounts { get; set; }
        public DbSet<CommonSetting> CommonSettings { get; set; }

        //HRM

        //PRM

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Maps to the expected many-to-many join table name for roles to users.
            modelBuilder.Entity<User>()
            .HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .Map(m =>
            {
                m.ToTable("RoleMemberships");
                m.MapLeftKey("UserName");
                m.MapRightKey("RoleName");
            });

            //one to one relationship with user mapping
            modelBuilder.Entity<User>()
            .HasOptional(u => u.Profile)
            .WithMany()
            .HasForeignKey(u => u.ProfileId);

            //one to one relationship with profile mapping
            modelBuilder.Entity<Profile>()
            .HasRequired(u => u.User)
            .WithMany()
            .HasForeignKey(u => u.UserName);

        }

    }

    #region Initial data

    // Change the base class as follows if you want to drop and create the database during development:
    //public class DBInitializer : DropCreateDatabaseAlways<AppDbContext>
    //public class DBInitializer : CreateDatabaseIfNotExists<AppDbContext>
    public class DbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        private static void CreateUserWithRole(string username, string password, string email, string rolename, AppDbContext context)
        {
            var status = new MembershipCreateStatus();

            Membership.CreateUser(username, password, email);
            if (status == MembershipCreateStatus.Success)
            {
                // Add the role.
                var user = context.Users.Find(username);
                var adminRole = context.Roles.Find(rolename);
                user.Roles = new List<Role> { adminRole };
            }
        }

        protected override void Seed(AppDbContext context)
        {
            // Create default roles.
            var roles = new List<Role>
                            {
                                new Role {RoleName = "Admin"},
                                new Role {RoleName = "User"}
                            };

            roles.ForEach(r => context.Roles.Add(r));

            context.SaveChanges();

            // Create some users.
            CreateUserWithRole("Rasel", "@123456", "raselahmmed@gmail.com", "Admin", context);
            CreateUserWithRole("Ahmmed", "@123456", "raselahmmed@gmail.com", "Admin", context);
            CreateUserWithRole("Sohel", "@123456", "sohel@gmail.com", "User", context);
            CreateUserWithRole("Shafin", "@123456", "shafin@gmail.com", "User", context);
            CreateUserWithRole("Tulika", "@123456", "tulika@gmail.com", "User", context);

            context.SaveChanges();

            context.SaveChanges();
        }
    }

    #endregion
}
