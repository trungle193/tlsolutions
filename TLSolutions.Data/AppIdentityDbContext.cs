using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TLSolutions.Entities;
using TLSolutions.Entities.Identity;

namespace TLSolutions.Data
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser, AppRole, Guid, IdentityUserClaim<Guid>, AppUserRoles,
    IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public DbSet<PermissionClaim> PermissionClaims { get; set; }
        public DbSet<Category> Categories { get; set; }
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //modelBuilder.ApplyConfiguration(new EntityConfiguration());
            base.OnModelCreating(builder);

            builder.Entity<AppUser>().ToTable("Users");
            builder.Entity<AppRole>().ToTable("Roles");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");
            builder.Entity<AppUserRoles>(entity =>
            {
                entity.ToTable("UserRoles");
                entity.HasKey(x => new { x.UserId, x.RoleId });
                entity.HasOne(x => x.User).WithMany(y => y.UserRoles).HasForeignKey(x => x.UserId);
                entity.HasOne(x => x.Role).WithMany(y => y.UserRoles).HasForeignKey(x => x.RoleId);
            });

            builder.Entity<PermissionClaim>(entity =>
            {
                entity.ToTable("PermissionClaim");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).HasMaxLength(100);
                entity.Property(x => x.Name).HasMaxLength(250).IsRequired();
                entity.HasIndex(x => x.Name).IsUnique();
            });

            builder.Entity<AppRole>().HasData(
                new AppRole()
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    NormalizedName = "Admin"
                },
                new AppRole()
                {
                    Id = Guid.NewGuid(),
                    Name = "Manager",
                    NormalizedName = "Manager"
                });


            builder.Entity<PermissionClaim>().HasData(new List<PermissionClaim>()
            {
                new PermissionClaim()
                {
                    Id = "role.view",
                    Name = "Danh sách nhóm quyền"
                },
                new PermissionClaim()
                {
                    Id = "role.create",
                    Name = "Tạo nhóm quyền"
                },
                new PermissionClaim()
                {
                    Id = "role.edit",
                    Name = "Sửa nhóm quyền"
                },new PermissionClaim()
                {
                    Id = "role.delete",
                    Name = "Xoá nhóm quyền"
                },
                new PermissionClaim()
                {
                    Id = "user.view",
                    Name = "Xem người dùng"
                },
                new PermissionClaim()
                {
                    Id = "user.create",
                    Name = "Tạo người dùng"
                },
                new PermissionClaim()
                {
                    Id = "user.edit",
                    Name = "Sửa người dùng"
                },new PermissionClaim()
                {
                    Id = "user.delete",
                    Name = "Xoá người dùng"
                }
            });


            builder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).HasMaxLength(250).IsRequired();
                entity.Property(x => x.Alias).HasMaxLength(250);
            });
        }
    }
}
