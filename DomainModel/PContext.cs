using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DomainModel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DomainModel
{
    public class PersonalContext: IdentityDbContext<Users>
    {
        public PersonalContext(DbContextOptions<PersonalContext> options) : base(options)
        {
            
        }
        public DbSet<Users> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Role> Role { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(i =>
            {
                i.HasKey(x => x.Id);
                i.Property(x => x.UserName).HasMaxLength(300);
                i.HasMany(x => x.UserRoles).WithOne(x => x.User).HasForeignKey(x => x.UserID);
            });

            modelBuilder.Entity<Role>(i =>
            {
                i.HasMany(x => x.UserRoles).WithOne(x => x.Role).HasForeignKey(x => x.RoleID);
            });

            modelBuilder.Entity<UserRole>(i =>
            {
                i.HasOne(x => x.User).WithMany(x => x.UserRoles);
                i.HasOne(x => x.Role).WithMany(x => x.UserRoles);
            });

            base.OnModelCreating(modelBuilder);
        }

        
    }
}