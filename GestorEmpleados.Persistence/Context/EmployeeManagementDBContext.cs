using GestorEmpleados.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
#nullable disable

namespace GestorEmpleados.Persistence.Context
{
    public partial class EmployeeManagementDBContext : DbContext
    {
        public EmployeeManagementDBContext(DbContextOptions<EmployeeManagementDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<EmployeeStatus> EmployeeStatuses { get; set; }

        public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<VwEmployeeDetail> VwEmployeeDetails { get; set; }

        public virtual DbSet<VwUserDetail> VwUserDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new Configurations.DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.EmployeeStatusConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.EmployeeTypeConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.RoleConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.UserConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.VwEmployeeDetailConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.VwUserDetailConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
