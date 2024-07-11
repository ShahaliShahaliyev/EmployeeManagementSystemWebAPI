using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementAPI.Domain.Entities;
using EmployeeManagementAPI.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Persistence.Contexts
{
    public class EmployeeManagementAPIDbContext :IdentityDbContext<User,Permission,int>
    {
        public EmployeeManagementAPIDbContext(DbContextOptions<EmployeeManagementAPIDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        //public DbSet<Permission> Permissions { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public  DbSet<Endpoint> Endpoints { get; set; }
       // public DbSet<User> Users { get; set; }
        //public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }
        public DbSet<DepartmentEmployees> DepartmentEmployees { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreateDate = DateTime.Now,
                    _ => DateTime.Now
                };
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            //modelBuilder.Entity<UserPermission>().HasKey(up => new { up.UserId, up.PermissionId });
            modelBuilder.Entity<Department>().HasKey(x => x.Id);
           // modelBuilder.Entity<User>().HasKey(x => x.Id);
            //modelBuilder.Entity<Permission>().HasKey(x => x.Id);
            modelBuilder.Entity<Employee>().HasKey(x => x.Id);
            modelBuilder.Entity<DepartmentEmployees>().HasKey(ep => new { ep.EmployeeId, ep.DepartmentId });
            modelBuilder.Entity<EmployeePosition>().HasKey(ep => new { ep.EmployeeId, ep.PositionId });

            modelBuilder.Entity<EmployeePosition>()
                .HasOne<Employee>(ep => ep.Employee)
                .WithMany(e => e.EmployeePositions)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeePosition>()
                .HasOne<Position>(ep => ep.Position)
                .WithMany(e => e.EmployeePositions)
                .HasForeignKey(e => e.PositionId)
                .OnDelete(DeleteBehavior.NoAction);




            //modelBuilder.Entity<UserPermission>()
            //.HasOne<Permission>(e => e.Permission)
            //.WithMany(up => up.UserPermissions)
            //.HasForeignKey(e => e.PermissionId)
            //.OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<UserPermission>()
            //.HasOne<User>(e => e.User)
            //.WithMany(up => up.UserPermissions)
            //.HasForeignKey(e => e.UserId)
            //.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DepartmentEmployees>()
            .HasOne<Department>(e => e.Department)
            .WithMany(up => up.DepartmentEmployees)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DepartmentEmployees>()
            .HasOne<Employee>(e => e.Employee)
            .WithMany(up => up.DepartmentEmployees)
            .HasForeignKey(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
