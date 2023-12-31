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
        public DbSet<Layouts> Layouts { get; set; }
        public DbSet<Sections> Sections { get; set; }
        public DbSet<UserLayout> UserLayouts { get; set; }
        public DbSet<SectionUserLayout> SectionUserLayouts { get; set; }
        public DbSet<DefaultSection> DefaultSections { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(i =>
            {
                i.HasKey(x => x.Id);
                i.Property(x => x.UserName).HasMaxLength(300);
                i.HasMany(x => x.UserRoles).WithOne(x => x.User).HasForeignKey(x => x.UserID);
            });
            modelBuilder.Entity<UserRole>(i =>
            {
                i.HasKey(x => x.ID);
                i.HasOne(x => x.Role).WithMany(x => x.UserRoles);
                i.HasOne(x => x.User).WithMany(x => x.UserRoles);
            });
            modelBuilder.Entity<Role>(i =>
            {
                i.HasMany(x => x.UserRoles).WithOne(x => x.Role).HasForeignKey(x => x.RoleID);
            });
            modelBuilder.Entity<Sections>(i =>
            {
                i.HasKey(x => x.ID);
                i.HasOne(x => x.defaultSection).WithMany(x => x.Sections);
                i.HasMany(x => x.sectionsMedias).WithOne(x => x.section).HasForeignKey(x => x.SectionID);
            });
            modelBuilder.Entity<DefaultSection>(i =>
            {
                i.HasKey(x => x.ID);
                i.Property(x => x.Name).HasMaxLength(100);
                i.Property(x => x.Title).HasMaxLength(200);
                i.Property(x => x.Description).HasMaxLength(1000);
                i.HasMany(x => x.Sections).WithOne(x => x.defaultSection).HasForeignKey(x => x.DefaultSecctionID);
            });
            modelBuilder.Entity<UserLayout>(i =>
            {
                i.HasKey(x => x.ID);
                i.Property(x => x.Name).HasMaxLength(100);
                i.HasOne(x => x.user).WithMany(x => x._userLayout);
                i.HasOne(x => x.layout).WithMany(x => x._userLayout);
                i.HasMany(x => x.sectionUserLayouts).WithOne(x => x.userLayout).HasForeignKey(x => x.userLayoutID);
            });
            modelBuilder.Entity<SectionUserLayout>(i =>
            {
                i.HasKey(x => x.ID);
                i.HasOne(x => x.userLayout).WithMany(x => x.sectionUserLayouts);
                i.HasOne(x => x.Sections).WithMany(x => x.SectionUserLayouts);
            });
            base.OnModelCreating(modelBuilder);
        }

        
    }
}